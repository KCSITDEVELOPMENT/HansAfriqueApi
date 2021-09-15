import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map } from 'rxjs/operators';
import { User } from '../models/user';
import { ReplaySubject } from 'rxjs';




@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/';


  
  constructor( private http: HttpClient) { }

  getProducts() {
    return this.http.get(this.baseUrl + 'products');
  }
  
  
}
