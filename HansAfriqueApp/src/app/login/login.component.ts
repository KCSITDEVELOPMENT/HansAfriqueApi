import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  constructor(private accountService: AccountService, private router: Router ) { }

  ngOnInit(): void {
  }

  login(){
   this.accountService.login(this.model).subscribe(response => {
     this.router.navigateByUrl('/cart')
    console.log(response);
   }, error => {
     console.log(error);
     })
   }

  cancel() {}
}
