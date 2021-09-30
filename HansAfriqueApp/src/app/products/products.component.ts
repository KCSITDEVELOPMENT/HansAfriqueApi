import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Part } from '../_models/part';
import { wallet } from '../_models/wallet';
import { AccountService } from '../services/account.service';
import { ProductService } from '../services/product.service';
import { ToastrService } from 'ngx-toastr';
import { Vehicle } from '../_models/vehicle';
import { Supplier } from '../_models/supplier';
import { PartCategory } from '../_models/PartCategory';
import { Brand } from '../_models/brand';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  parts: Part[] = [];
  vehiclemodels : Vehicle[] = [];
  suppliers : Supplier[] = [];
  partcategorys : PartCategory [] = [];
  brands : Brand[] = [];

  constructor(private accountService: AccountService, private productService: ProductService, 
    private http: HttpClient,  
    private router: Router, 
    private toastrService: ToastrService ) 
    { 
      
    }
  
  ngOnInit(): void {

   this.getProducts();
   this.getvehicle_Models();
   this.getvehicle_Suppliers();
   
    }

    getProducts(){
      this.productService.getProducts().subscribe((part : Part[]) => {
        this.parts = part;
      },error => {
        console.error();
        this.toastrService.error(error.error);
      });
    }

    getvehicle_Models(){
      this.productService.getByVehicleModels().subscribe((vehiclemodel : Vehicle[]) =>{
       this.vehiclemodels = vehiclemodel;

      },error => {
        console.error();
        this.toastrService.error(error.error);
      });
    }

    
    getvehicle_Suppliers(){
      this.productService.getBysuplliers().subscribe((supplier : Supplier[]) =>{
       this.suppliers = supplier;
       console.log(this.suppliers);
      },error => {
        console.error();
        this.toastrService.error(error.error);
      });
    }

    getpartscategory(){
      this.productService.getByPartCategory().subscribe((partscategory : PartCategory[]) =>{
       this.partcategorys = partscategory;
       console.log(this.partcategorys);

      },error => {
        console.error();
        this.toastrService.error(error.error);
      });
    }

    getvehicle_Brands(){
      this.productService.getByBrands().subscribe((brand : Brand[]) =>{
       this.brands = brand;
       console.log(this.brands);
      },error => {
        console.error();
        this.toastrService.error(error.error);
      });
    }
}
