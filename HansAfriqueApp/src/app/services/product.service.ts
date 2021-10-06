import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import {map } from 'rxjs/operators';
import { User } from '../_models/user';
import { Observable, ReplaySubject } from 'rxjs';
import { Part } from '../_models/part';
import { environment } from 'src/environments/environment';
import { PartCategory } from '../_models/PartCategory';
import { Vehicle } from '../_models/vehicle';
import { Supplier } from '../_models/supplier';
import { Brand } from '../_models/brand';




@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl;
  parts: Part[] = [];


  
  constructor( private http: HttpClient) { }

  getProducts(): Observable<Part[]> {
    return this.http.get<Part[]>(this.baseUrl + 'products');
  }
  
  getByPartCategory() {
    return this.http.get<PartCategory[]>(this.baseUrl + 'products/category');
  }

  getByVehicleModels(): Observable<Vehicle[]> {
    return this.http.get<Vehicle[]>(this.baseUrl + 'products/vehicles');
  }
  
  getBysuplliers(): Observable<Supplier[]> {
    return this.http.get<Supplier[]>(this.baseUrl + 'products/supplier');
  }

  getByBrands() {
    return this.http.get<Brand[]>(this.baseUrl + 'products/brands');
  }
}
