import { Component, OnInit } from '@angular/core';
import { wallet } from 'src/app/_models/wallet';

@Component({
  selector: 'app-checkout-totals',
  templateUrl: './checkout-totals.component.html',
  styleUrls: ['./checkout-totals.component.css']
})
export class CheckoutTotalsComponent implements OnInit {
  walletAmount : wallet;
  
  constructor() {     this.walletAmount = new wallet();}

  ngOnInit(): void {
  }

}
