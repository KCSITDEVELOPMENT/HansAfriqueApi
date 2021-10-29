import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductOperationsService } from 'src/app/services/product-operations.service';
import { ProductService } from 'src/app/services/product.service';
import { Brand } from 'src/app/_models/brand';
import { Pagination } from 'src/app/_models/pagination';
import { Part } from 'src/app/_models/part';
import { PartCategory } from 'src/app/_models/PartCategory';
import { Partnumber } from 'src/app/_models/partnumber';

@Component({
  selector: 'app-product-operations',
  templateUrl: './product-operations.component.html',
  styleUrls: ['./product-operations.component.css']
})
export class ProductOperationsComponent implements OnInit {
  
  parts: Part[] = [];
  partData: Part = new Part;
  brands: Brand[] = [];
  partcategorys: PartCategory[] = [];
  partnumbers: Partnumber[] = [];
  public dropDownIdPartCategory: number = 0;
  public dropDownIdPartPartnumber: number = 0;
  public dropDownIdPartBrand: number = 0;
  editForm: any;
  id: number | undefined;



  constructor(private productService: ProductService, private toastrService: ToastrService,
     private productoperationService: ProductOperationsService,
      private router: Router, private route: ActivatedRoute, private productOperationsService: ProductOperationsService) { 

  }

  ngOnInit(): void {
    this.getProducts();
    this.getVehicle_Brands();
    this.getPartscategory();
    this.getPartCategoryCodeType();

  }


  getProducts(){
    this.productService.getProducts().subscribe((part : Pagination) => {
      this.parts = part.data;
    },error => {
      console.error();
      this.toastrService.error(error.error);
    });
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

  
onDelete(id: number)
 {
  this.productOperationsService.DeleteUser(id).subscribe(() => {
    this.getProducts();
 }, error => {
  console.error();
  this.toastrService.error(error.error);
 });

}  

postParts(){}

onSubmit(formData : FormGroup) {
  this.productoperationService.putProducts(this.id , formData.value).subscribe(res => {

  });
}

}
