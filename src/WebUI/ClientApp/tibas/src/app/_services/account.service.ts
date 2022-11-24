import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../_models/account/user.type';
import { environment } from 'src/environments/enviroment';
import { LoginResponse } from '../_models/account/login-response.type';

@Injectable({ providedIn: 'root' })
export class AccountService {
    private userSubject: BehaviorSubject<User | null>;
    public user: Observable<User | null>;
    private _requestUrl:string='';

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.userSubject = new BehaviorSubject<User | null>(JSON.parse(localStorage.getItem('user')!));
        this.user = this.userSubject.asObservable();
        this._requestUrl=`${environment.apiUrl}/Auth`;
    }

    public get userValue(): User | null{
        return this.userSubject.value;
    }

    login(username:string, password:string) {
        return this.http.post<LoginResponse>(this._requestUrl, { "loginName":username, "password":password })
            .pipe(map(res => {
                localStorage.setItem('user', JSON.stringify(res.user));
                this.userSubject.next(res.user);
                return res;
            }));
    }

    logout() {

      this.http.post(this._requestUrl+"/Logout",{}).subscribe({
         next :()=>{
            // remove user from local storage and set current user to null
            localStorage.removeItem('user');
            this.userSubject.next(null);
            this.router.navigate(['/login']);
         },
         error: (err)=>{
          console.error(err);
         }
      })


    }
}
