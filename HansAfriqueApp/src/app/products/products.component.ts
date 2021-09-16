import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Part } from '../models/part';
import { wallet } from '../models/wallet';
import { AccountService } from '../services/account.service';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  walletAmount : wallet;
  parts: Part[] = [];

  constructor(private accountService: AccountService, private productService: ProductService, private http: HttpClient,  private router: Router) { 
    this.walletAmount = new wallet();

  }
  
  ngOnInit(): void {
   this.getProducts();
   
    }

    getProducts(){
      this.productService.getProducts().subscribe((parts : Part[]) => {
        this.parts = parts;
        console.log(this.parts);
      },error => {
        console.error();
      });
    }
}
