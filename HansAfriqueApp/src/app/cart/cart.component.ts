import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart',
  template: '<form action="https://sandbox.payfast.co.za​/eng/process" method="post"><input type="hidden" name="merchant_id" value="10000100"><input type="hidden" name="merchant_key" value="46f0cd694581a"><input type="hidden" name="amount" value="100.00"><input type="hidden" name="item_name" value="Test Product"><input type="submit"></form>',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
 

  constructor() { }

  ngOnInit(): void {
  }

}
