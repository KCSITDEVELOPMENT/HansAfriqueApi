import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
 
  amount : any =   'https://sandbox.payfast.co.za​/eng/process';

  constructor() { }

  ngOnInit(): void {
  }

  onNavigate(){
    // your logic here.... like set the url 
    const url = 'simplecartjs-basic-sample.html';
    window.open(url);
}
}
