import { Component, OnInit } from '@angular/core';
import { User } from './_models/account/user.type';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent  implements OnInit {

  user: User | undefined | null;

  constructor(private accountService:AccountService){
  }

  ngOnInit(): void {
    this.accountService.user.subscribe(x => this.user = x);
  }
}
