import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/enviroment';
import { Favourite } from '../_models/favourite/favourite.type';
import { FavouriteResponse } from '../_models/favourite/favourite-response.type';

@Injectable({ providedIn: 'root' })
export class FavouritesService {

  private _requestUrl:string='';

    constructor(
        private http: HttpClient
    ) {
        this._requestUrl=`${environment.apiUrl}/Favourite`;
    }

    getFavourites()  : Observable<FavouriteResponse>{
      return this.http.get<FavouriteResponse>(this._requestUrl);
    }

    create(requestParameters:any) : Observable<Favourite> {
        return this.http.post<Favourite>(this._requestUrl, requestParameters);
    }

    delete(id:number) : Observable<any> {
      return this.http.delete(this._requestUrl+"?id="+id);
    }
}
