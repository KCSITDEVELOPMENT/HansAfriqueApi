import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { wallet } from '../models/wallet';

@Injectable({
  providedIn: 'root'
})
export class PayfastService {

  products : any = [];

  constructor(private http: HttpClient) { }


  
  getProducts(Wallet : wallet) {
    return this.http.post<wallet>('https://sandbox.payfast.co.za​/eng/process' , Wallet);
  }
}
