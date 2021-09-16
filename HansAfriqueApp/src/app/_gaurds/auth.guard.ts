import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import { observable,Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accountService: AccountService, private router: Router,  private toastrService: ToastrService ) { }

  canActivate() :Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map(user => {
        if (user)
         return true;
        this.toastrService.error('Your Have No access Here!');
        return false;
      })
    )
  }
  
}
