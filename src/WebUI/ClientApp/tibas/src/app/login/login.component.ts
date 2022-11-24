import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  form!: FormGroup;
  loading = false;
  submitted = false;
  hasLoginError:boolean=false;
  errorMessage:string='';

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService
  ) {}


  get username() { return this.form.get('username'); }

  get password() { return this.form.get('password'); }

  ngOnInit() {
    this.form = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  onSubmit() {

    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    this.loading = true;

    this.hasLoginError=false;
    this.errorMessage='';

    this.accountService
      .login(this.username?.value, this.password?.value)
      .subscribe({
        next: (data) => {
          if(data.errorCode==0){
            const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
            this.router.navigateByUrl(returnUrl);
          }
          else{
            this.hasLoginError=true;
            this.errorMessage=data.error;
          }
        },
        error: (error) => {
          console.error(error);
        },
        complete:() => {
          this.loading = false;
        }
      });
  }
}
