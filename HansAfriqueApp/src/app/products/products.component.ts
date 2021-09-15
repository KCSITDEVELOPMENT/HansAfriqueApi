import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { wallet } from '../models/wallet';
import { AccountService } from '../services/account.service';
import { PayfastService } from '../services/payfast.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products : any = [];
  walletAmount : wallet;


  constructor(private accountService: AccountService, private payfastService: PayfastService, private http: HttpClient,  private router: Router) { 
    this.walletAmount = new wallet()
  }
  
  ngOnInit(): void {


    this.http.get('https://localhost:5001/api/products').subscribe((response: any) => {
      this.products =  response;
      console.log(response);
   
    });
   
    }

  

}
