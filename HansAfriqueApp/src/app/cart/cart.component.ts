import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { wallet } from '../models/wallet';
import { PayfastService } from '../services/payfast.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  products : any = {}; 
  walletAmount : wallet;

  constructor(private http: HttpClient, private payfastService : PayfastService,  private router: Router) { 

    this.walletAmount = new wallet()
  }

  ngOnInit(): void {

  }


  send(){
     
    

    this.payfastService.getProducts(this.walletAmount).subscribe(() => {
      this.router.navigateByUrl('/https://sandbox.payfast.co.za​/eng/process' + this.walletAmount);
    });
  }
}
