import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AccountService } from '../services/account.service';
import { BasketService } from '../services/basket.service';
import { IBasket } from '../_models/basket';
import { User } from '../_models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {}
  loggedIn: boolean = false;
  currentUser$: Observable<User> | undefined;
  basket$: Observable<IBasket> | undefined;
  


  constructor( private accountService: AccountService,
    private basketService : BasketService,
     private toastrService: ToastrService) 
     { }

  ngOnInit(): void {
 this.currentUser$ = this.accountService.currentUser$;

 this.basket$ = this.basketService.basket$;
  }

  login(){
   this.accountService.login(this.model).subscribe(response => {
     console.log(response);
     this.loggedIn = true;

   }, error =>{
     console.log(error);
     this.toastrService.error(error.error);
     
  })
  }


  logout() {
    this.accountService.logout();
  }

}
 
