import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
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
  selector: 'app-editproduct',
  templateUrl: './editproduct.component.html',
  styleUrls: ['./editproduct.component.css']
})
export class EditproductComponent implements OnInit {


  parts: Part[] = [];
  partData: Part = new Part;
  brands : Brand[] = [];
  vehiclemodels : Vehicle[] = [];
  suppliers : Supplier[] = [];
  partcategorys : PartCategory [] = [];
  partnumbers : Partnumber [] = [];


  id!: number;  
  bankAccountForms: FormArray = this.formBuilder.array([]);
  editForm: FormGroup;


  constructor(private productService: ProductService,private productoperationService: ProductOperationsService, 
    private toastrService: ToastrService,  private formBuilder: FormBuilder,  private route: ActivatedRoute) { 

      this.editForm = this.formBuilder.group({
        id: ['',  Validators.required],

        name: ['', Validators.required],
        partCode: ['', Validators.required],
        partNumberid: ['', Validators.required],
        price: ['', Validators.required],
        vehicleid: ['', Validators.required],
        vehicleModel: ['', Validators.required],
        supplierid: ['', Validators.required],
        partCategoryid: ['', Validators.required],
    
        brandid: [''],

      
      });
    }

      
 
  ngOnInit(): void {
    
    this.getPartscategory();
    this.getVehicle_Brands();
    this.getPartCategoryCodeType();
    this.getVehicle();
    this.getSuppliers();
    
    this.id = this.route.snapshot.params.id;

    this.productService.getProductsByid(this.id).subscribe((part: Part[]) => {
      this.parts = part;
      this.editForm.patchValue(part);
    });




  }



  
  //getProducts(){
   // this.productService.getProducts().subscribe((part : Part[]) => {
    //  this.parts = part;
   // },error => {
   //   console.error();
  //    this.toastrService.error(error.error);
  //  });
 // }

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
  //updateProducts(){
   //this.productoperationService.putProducts(this.partData).subscribe(() => {
    //console.log(this.partData);
    //this.getProducts();
   //});

  //}

  onSubmit(formData: { value: any; }) {
    this.productoperationService.putProducts(this.id , formData.value).subscribe(res => {
  
    });
  }

  recordSubmit(fg: FormGroup){}

//populateForm(SelectedPerson : Part)
//{
 // this.partData = Object.assign({}, SelectedPerson)
//}

}
