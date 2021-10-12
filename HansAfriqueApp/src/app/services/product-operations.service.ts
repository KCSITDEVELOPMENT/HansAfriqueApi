import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Part } from '../_models/part';

@Injectable({
  providedIn: 'root'
})
export class ProductOperationsService {
  baseUrl = environment.apiUrl;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  

  constructor(private http: HttpClient) { }

  postProducts(part: Part) {
    return this.http.post<Part>(this.baseUrl + 'ProductOperations/save', part);
  }

  putProducts( id: number | undefined,formData : any) {
    return this.http.put(this.baseUrl + 'ProductOperations/' + id, JSON.stringify(formData), this.httpOptions );
  }
}
