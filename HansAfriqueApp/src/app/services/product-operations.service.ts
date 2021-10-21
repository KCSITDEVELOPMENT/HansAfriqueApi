import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
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

  postProducts(formData : any): Observable<Part> {
    return this.http.post<Part>(this.baseUrl + 'ProductOperations/save', JSON.stringify(formData), this.httpOptions );
  
  }

  putProducts( id: number | undefined,formData : any) {
    return this.http.put(this.baseUrl + 'ProductOperations/' + id, JSON.stringify(formData), this.httpOptions );
  }

  DeleteUser(id: number) {
    return this.http.delete<Part>( this.baseUrl +'ProductOperations/' + id);
  }

  postPhotos( id: number | undefined,formData : any) {
    return this.http.post(this.baseUrl + 'Photos/' + id, JSON.stringify(formData), this.httpOptions );
  }
}
