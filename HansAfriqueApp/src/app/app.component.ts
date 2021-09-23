import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'HansAfriqueApp';

  constructor(private accountService: AccountService){}

  ngOnInit() {
  this.setCurrentUser();
  }


  setCurrentUser() {
    const user : User = JSON.parse(localStorage.getItem('user') as string);
    this.accountService.setCurrentUser(user);
  }

}
