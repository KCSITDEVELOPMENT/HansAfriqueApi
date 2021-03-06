import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
 model: any = {};

  constructor( private accountService: AccountService , private router: Router,  private toastrService: ToastrService ) { }

  ngOnInit(): void {
  }

  register(){
    this.accountService.register(this.model).subscribe(response => {
      this.router.navigateByUrl('/cart')
      console.log(response);
     }, error => {
       console.log(error);
       this.toastrService.error(error.error);
       })
     }

  cancel() {
    
  }

}
