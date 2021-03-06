import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { wallet } from '../_models/wallet';
import { BasketService } from '../services/basket.service';
import { IBasket, IBasketItem } from '../_models/basket';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  products : any = {}; 
  walletAmount : wallet;
  basket$: Observable<IBasket> | undefined;

  constructor(private http: HttpClient,  private basketService : BasketService,  private router: Router) { 

    this.walletAmount = new wallet();
  }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
  }


  
  removeBasketItem(item: IBasketItem) {
    this.basketService.removeItemFromBasket(item);
  }

  incrementItemQuantity(item: IBasketItem) {
    this.basketService.incrementItemQuantity(item);
  }

  decrementItemQuantity(item: IBasketItem) {
    this.basketService.decrementItemQuantity(item);
  }
}
