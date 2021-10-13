import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductOperationsService } from 'src/app/services/product-operations.service';
import { ProductService } from 'src/app/services/product.service';
import { Brand } from 'src/app/_models/brand';
import { Part } from 'src/app/_models/part';
import { PartCategory } from 'src/app/_models/PartCategory';
import { Partnumber } from 'src/app/_models/partnumber';
import { Supplier } from 'src/app/_models/supplier';
import { Vehicle } from 'src/app/_models/vehicle';

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrls: ['./addproduct.component.css']
})
export class AddproductComponent implements OnInit {
  parts: Part[] = [];
  partData: Part = new Part;
  brands : Brand[] = [];
  vehiclemodels : Vehicle[] = [];
  suppliers : Supplier[] = [];
  partcategorys : PartCategory [] = [];
  partnumbers : Partnumber [] = [];

  editForm: FormGroup;


  constructor(private productService: ProductService,private productoperationService: ProductOperationsService, 
    private toastrService: ToastrService,  private formBuilder: FormBuilder, private router: Router) { 

      this.editForm = this.formBuilder.group({
        name: ['', Validators.required],
        partCode: ['', Validators.required],
        partNumber: ['', Validators.required],
        price: ['', Validators.required],
        vehicle: ['', Validators.required],
        vehicleModel: ['', Validators.required],
        supplier: ['', Validators.required],
        partCategory: ['', Validators.required],
        brand: [''],
      });
    }

  ngOnInit(): void {
    this.getVehicle_Brands();
    this.getPartscategory();
    this.getPartCategoryCodeType();
    this.getSuppliers();
    this.getVehicle();

    

  }


  getVehicle_Brands(){
    this.productService.getByBrands().subscribe((brand : Brand[]) =>{
     this.brands = brand;
    },error => {
      console.error();
      this.toastrService.error(error.error);
    });
  }

  getPartscategory(){
    this.productService.getByPartCategory().subscribe((partscategory : PartCategory[]) =>{
     this.partcategorys = partscategory;
    },error => {
      console.error();
      this.toastrService.error(error.error);
    });
  }

  getPartCategoryCodeType(){
    this.productService.getByPartnamber().subscribe((partnumber : Partnumber[]) =>{
     this.partnumbers = partnumber;
    },error => {
      console.error();
      this.toastrService.error(error.error);
    });
  }

  getVehicle(){
    this.productService.getVehicleTypes().subscribe((vehicle : Vehicle[]) =>{
     this.vehiclemodels = vehicle;
    },error => {
      console.error();
      this.toastrService.error(error.error);
    });
  }

  getSuppliers(){
    this.productService.getSupplierNames().subscribe((supplier : Supplier[]) =>{
     this.suppliers = supplier;
    },error => {
      console.error();
      this.toastrService.error(error.error);
    });
  }

  getPartTypes(){
    this.productService.getByPartCategory().subscribe((partCategory : PartCategory[]) =>{
     this.partcategorys = partCategory;
    },error => {
      console.error();
      this.toastrService.error(error.error);
    });
  }

  onSubmit(formData: { value: any; }) {
    this.productoperationService.postProducts(formData.value).subscribe(res => {
      this.router.navigateByUrl('products');
    });
  }
}
