import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map } from 'rxjs/operators';
import { User } from '../models/user';
import { Observable, ReplaySubject } from 'rxjs';
import { Part } from '../models/part';




@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = 'https://localhost:5001/api/';


  
  constructor( private http: HttpClient) { }

  getProducts(): Observable<Part[]> {
    return this.http.get<Part[]>(this.baseUrl + 'products');
  }
  
  
}
