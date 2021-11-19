import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../services/account.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  constructor(private accountService: AccountService, private router: Router,  private toastrService: ToastrService ) { }

  ngOnInit(): void {
  }

  login(){
   this.accountService.login(this.model).subscribe(response => {
     this.router.navigateByUrl('/products')
     this.toastrService.success("Logged in Successfully");
    console.log(response);
   }, error => {
     console.log(error);
     this.toastrService.error(error.error);
     })
   }

   register(){
    this.accountService.register(this.model).subscribe(response => {
      this.router.navigateByUrl('/cart')
      this.toastrService.success("Logged in Successfully");
      console.log(response);
     }, error => {
       console.log(error);
       this.toastrService.error(error.error);
       })
     }

  cancel() {}
}
