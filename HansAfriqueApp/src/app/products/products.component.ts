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
import { Pagination } from '../_models/pagination';
import { ProductParams } from '../_models/productParams';

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
  productParams = new ProductParams();
  totalCount : number = 0;

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
   this.getvehicle_Brands();
   
    }

    getProducts(){
      this.productService.getProducts(this.productParams).subscribe((part : any) => {
        this.parts = part.data;
        this.productParams.pageNumber = part.pageIndex;
        this.productParams.pageSize = part.pageSize;
        this.totalCount = part.count;
      },error => {
        console.error();
        this.toastrService.error(error.error);
      });
    }
    
    getvehicle_Suppliers(){
      this.productService.getBysuplliers().subscribe((supplier : Supplier[]) =>{
       this.suppliers = supplier;
      },error => {
        console.error();
        this.toastrService.error(error.error);
      });
    }

    getpartscategory(){
      this.productService.getByPartCategory().subscribe(response =>{
       this.partcategorys = [{id: 0, name: 'All'}, ...response];
       console.log(this.partcategorys);

      },error => {
        console.error();
        this.toastrService.error(error.error);
      });
    }

    getvehicle_Brands(){
      this.productService.getByBrands().subscribe( response =>{
       this.brands = [{id: 0, name: 'All'}, ...response];
       console.log(this.brands);
      },error => {
        console.error();
        this.toastrService.error(error.error);
      });
    }

    getvehicle_Models(){
      this.productService.getByVehicleModels().subscribe(response =>{
       this.vehiclemodels = [{id: 0, vehicle_Model: 'All'}, ...response];
      },error => {
        console.error();
        this.toastrService.error(error.error);
      });
    }

    onBrandsSelected(brandId: number){
     this.productParams.brandId = brandId;
     this.getProducts();
    }

    
    onvehicleCategorySelected(vehicleCategoryId: number){
      this.productParams.vehicleCategoryId = vehicleCategoryId;
      this.getProducts();
     }

     onPageChange(event: any){
       this.productParams.pageNumber = event.page;
       this.getProducts();
     }
}
