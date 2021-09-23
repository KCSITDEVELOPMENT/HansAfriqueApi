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

const routes: Routes = [
  {path: '', component: HomeComponent },
   {
     path: '',
     runGuardsAndResolvers: 'always',
     canActivate: [AuthGuard],
     children: [
     
      {path: 'products', component: ProductsComponent },
      {path: 'products/id', component: ProductsDetailsComponent },
      {path: 'cart', component: CartComponent },
      {path: 'cart/simplecartjs-basic-sample.html', component: CartComponent },
     ]
   },

    {path: 'about', component: AboutComponent },
    {path: 'login', component:  LoginComponent },
    {path: '**', component: HomeComponent, pathMatch:'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
