import { HttpClient } from '@angular/common/http';
import { isNull } from '@angular/compiler/src/output/output_ast';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IBasket, IBasketItem } from '../_models/basket';
import { Part } from '../_models/part';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>((null) as any);
  basket$ = this.basketSource.asObservable();


  constructor( private http: HttpClient) { }

  getBasket(id : string){
    return this.http.get<IBasket>(this.baseUrl + 'basket?id' + id)
    .pipe(
      map((basket : IBasket) =>{
         this.basketSource.next(basket);
      })
    )
  }

  setBasket( basket: IBasket){
    return this.http.post<IBasket>(this.baseUrl + 'basket', basket).subscribe((response: IBasket) => {
      this.basketSource.next(response);
    }, error =>{
      console.log(error);
    });
  }

  getCurrentBasketValue(){
    return this.basketSource.value;
  }

  addItemToBasket(item: Part, quantity = 1){
    const ItemToAdd: IBasketItem = this.mapPartItemToBasket(item, quantity);
  }
  mapPartItemToBasket(item: Part, quantity: number): IBasketItem {
    return{
      id: item.id,
      name: item.name,
      brand: item.brand,
      vehicle: item.vehicle,
      supplier: item.supplier,
      price: item.price,
      pictureULR: item.pictureULR,
      partCategory: item.partCategory,
      partCode: item.partCode,
      vehicleModel: item.VehicleModel,
      partNumber: item.partNumber
    };
  }
}
