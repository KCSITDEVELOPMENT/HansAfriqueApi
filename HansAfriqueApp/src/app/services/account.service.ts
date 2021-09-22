import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map } from 'rxjs/operators';
import { User } from '../_models/user';
import { ReplaySubject } from 'rxjs';
import { isNull } from '@angular/compiler/src/output/output_ast';
import { environment } from 'src/environments/environment';




@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();
  getProducts: any;

  
  constructor( private http: HttpClient) { }


  
  login(model: any) {
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response : User) => {
        const user = response;

        if (user){
         localStorage.setItem('user', JSON.stringify(user));
         this.currentUserSource.next(user);
        }

      })
    )
  }

  setCurrentUser(user: User){
    this.currentUserSource.next(user);
  }

  register(model: any)
  {
    return this.http.post(this.baseUrl + 'account/register', model);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next();
  }
}
