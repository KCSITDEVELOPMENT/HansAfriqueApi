import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map } from 'rxjs/operators';
import { User } from '../_models/user';
import { Observable, ReplaySubject } from 'rxjs';
import { Part } from '../_models/part';
import { Brand } from '../_models/brand';
import { environment } from 'src/environments/environment';




@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl;


  
  constructor( private http: HttpClient) { }

  getProducts(): Observable<Part[]> {
    return this.http.get<Part[]>(this.baseUrl + 'products');
  }
  
  
  getBrands(): Observable<Brand[]> {
    return this.http.get<Brand[]>(this.baseUrl + 'brands');
  }
  
}
