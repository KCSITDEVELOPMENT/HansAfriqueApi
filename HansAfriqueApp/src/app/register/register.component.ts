import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
 model: any = {};

  constructor( private accountService: AccountService,  private router: Router ) { }

  ngOnInit(): void {
  }

  register(){
    this.accountService.register(this.model).subscribe(response => {
      this.router.navigateByUrl('/products');
      console.log(response);
     }, error => {
       console.log(error);
       })
     }

  cancel() {
    
  }

}
