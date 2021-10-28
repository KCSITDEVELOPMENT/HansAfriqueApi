import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ProductsComponent } from './products/products.component';
import { ProductsDetailsComponent } from './products-details/products-details.component';
import { HomeComponent } from './home/home.component';
import { CartComponent } from './cart/cart.component';
import { AuthGuard } from './_gaurds/auth.guard';
import { AboutComponent } from './about/about.component';
import { EditproductComponent } from './products/editproduct/editproduct.component';
import { ProductOperationsComponent } from './products/product-operations/product-operations.component';
import { AddproductComponent } from './products/addproduct/addproduct.component';
import { PicturesofproductComponent } from './products/picturesofproduct/picturesofproduct.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {path: '', component: HomeComponent },
   {
     path: '',
     runGuardsAndResolvers: 'always',
     canActivate: [AuthGuard],
     children: [

      {path: 'editproduct/:id', component: EditproductComponent },
      {path: 'productoperations', component: ProductOperationsComponent },
      {path: 'products', component: ProductsComponent },
      {path: 'products/:id', component: ProductsDetailsComponent },
      {path: 'cart', component: CartComponent },

     ]
   },

    {path: 'about', component: AboutComponent },
    {path: 'addproduct', component: AddproductComponent },
    {path: 'register', component: RegisterComponent },
    {path: 'picturesofproduct/:id', component: PicturesofproductComponent },
    {path: 'login', component:  LoginComponent },
    {path: '**', component: HomeComponent, pathMatch:'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
