import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './services/account.service';
import { BasketService } from './services/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'HansAfriqueApp';

  constructor(private accountService: AccountService, private basketService: BasketService){}

  ngOnInit(): void {
  this.setCurrentUser();
   const basketId = localStorage.getItem('basket_Id');

   if(basketId)
   {
     this.basketService.getBasket(basketId).subscribe(() => {
      console.log('initialised basket');
     },error => {
       console.log(error);
     })
    }
  }


  setCurrentUser() {
    const user : User = JSON.parse(localStorage.getItem('user') as string);
    this.accountService.setCurrentUser(user);
  }

}
