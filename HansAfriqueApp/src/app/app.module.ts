import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProductsComponent } from './products/products.component';
import { AppRoutingModule } from './app-routing.module';
import { ProductsDetailsComponent } from './products-details/products-details.component';
import { CartComponent } from './cart/cart.component';
import { PayfastFormComponent } from './payfast-form/payfast-form.component';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastRef, ToastrModule } from 'ngx-toastr';
import { AboutComponent } from './about/about.component';
import { ProductItemComponent } from './products/product-item/product-item.component';
import { AddproductComponent } from './products/addproduct/addproduct.component';
import { EditproductComponent } from './products/editproduct/editproduct.component';
import { ProductOperationsComponent } from './products/product-operations/product-operations.component';
import { PicturesofproductComponent } from './products/picturesofproduct/picturesofproduct.component';
import { CarouselModule } from 'ngx-owl-carousel-o';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    LoginComponent,
    ProductsComponent,
    ProductsDetailsComponent,
    CartComponent,
    PayfastFormComponent,
    TextInputComponent,
    AboutComponent,
    ProductItemComponent,
    AddproductComponent,
    EditproductComponent,
    ProductOperationsComponent,
    PicturesofproductComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    CarouselModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
