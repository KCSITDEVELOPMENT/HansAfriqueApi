import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AccountService } from '../services/account.service';
import { User } from '../_models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {}
  loggedIn: boolean = false;
  currentUser$: Observable<User> | undefined;


  constructor( private accountService: AccountService, private toastrService: ToastrService) { }

  ngOnInit(): void {
 this.currentUser$ = this.accountService.currentUser$;
  }

  login(){
   this.accountService.login(this.model).subscribe(response => {
     console.log(response);
     this.loggedIn = true;

   }, error =>{
     console.log(error);
     this.toastrService.error(error.error);
     
  })
  }


  logout() {
    this.accountService.logout();
  }

}
 
