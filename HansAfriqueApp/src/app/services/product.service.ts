import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import {delay, map } from 'rxjs/operators';
import { User } from '../_models/user';
import { Observable, ReplaySubject } from 'rxjs';
import { Part } from '../_models/part';
import { environment } from 'src/environments/environment';
import { PartCategory } from '../_models/PartCategory';
import { Vehicle } from '../_models/vehicle';
import { Supplier } from '../_models/supplier';
import { Brand } from '../_models/brand';
import { Partnumber } from '../_models/partnumber';
import { Pagination } from '../_models/pagination';
import { ProductParams } from '../_models/productParams';




@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor( private http: HttpClient) { }

  getProducts(productParams: ProductParams) {
    let params = new HttpParams();

    if(productParams.brandId !== 0){
      params = params.append('brandId', productParams.brandId.toString())
    }

    if(productParams.vehicleCategoryId !== 0){
      params = params.append('vehicleCategoryId', productParams.vehicleCategoryId.toString())
    }

    params = params.append('pageIndex', productParams.pageNumber.toString());
    params = params.append('pageIndex', productParams.pageSize.toString());

    return this.http.get<Pagination>(this.baseUrl + 'products', {observe: 'response', params})
     .pipe(
           map(response => {
             return response.body;

         })
     );
  }


  
  getProductsByid(id: any): Observable<Part[]> {
    return this.http.get<Part[]>(this.baseUrl + `products/${id}`);
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
   
  getByPartnamber() {
    return this.http.get<Partnumber[]>(this.baseUrl + 'products/partnamber');
  }

   
  getVehicleTypes() {
    return this.http.get<Vehicle[]>(this.baseUrl + 'products/vehicles');
  }

   
  getSupplierNames() {
    return this.http.get<Supplier[]>(this.baseUrl + 'products/supplier');
  }

}
