import { NgModule } from '@angular/core';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
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
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { SectionHeaderComponent } from './section-header/section-header.component';
import { NgxSpinnerModule } from "ngx-spinner";
import { provideRoutes } from '@angular/router';
import { LoadingInterceptor } from './interceptor/loading.interceptor';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { OrderTotalsComponent } from './order-totals/order-totals.component';
import { CheckoutTotalsComponent } from './order-totals/checkout-totals/checkout-totals.component';
import { StepperFormComponent } from './order-totals/stepper-form/stepper-form.component';

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
    PicturesofproductComponent,
    SectionHeaderComponent,
    OrderTotalsComponent,
    CheckoutTotalsComponent,
    StepperFormComponent
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
    PaginationModule.forRoot(),
    NgxSpinnerModule,
    CdkStepperModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
   
  ],
  exports: [PaginationModule],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
