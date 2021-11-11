import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Basket, IBasket, IBasketItem, IBasketTotals } from '../_models/basket';
import { Part } from '../_models/part';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>((null) as any);
  basket$ = this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<IBasketTotals>((null) as any);
  basketTotal$ = this.basketTotalSource.asObservable();


  constructor( private http: HttpClient) { }

  getBasket(id : string){
    return this.http.get<IBasket>(this.baseUrl + 'basket?id=' + id)
    .pipe(
      map((basket : IBasket) =>{
         this.basketSource.next(basket);
        this.calculateTotals();
      })
    );
  }

  setBasket( basket: IBasket){
    return this.http.post<IBasket>(this.baseUrl + 'basket', basket).subscribe((response: IBasket) => {
      this.basketSource.next(response);
      this.calculateTotals();
    }, error =>{
      console.log(error);
    });
  }

  getCurrentBasketValue(){
    return this.basketSource.value;
  }

  addItemToBasket(item: Part, quantity = 1) {
    const itemToAdd: IBasketItem = this.mapPartItemToBasket(item, quantity);
    let basket = this.getCurrentBasketValue();
    if (basket === null) {
      basket = this.createBasket();
    }
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.setBasket(basket);
  }

  private calculateTotals(){
    const basket = this.getCurrentBasketValue();
    const shipping = 0;
    const subtotal = basket.items.reduce((a, b) => (b.price * b.quantity) +a, 0);
    const total = subtotal + shipping;
    this.basketTotalSource.next({shipping, total, subtotal});
  }

  addOrUpdateItem(items: IBasketItem[], ItemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    const index = items.findIndex(i => i.id === ItemToAdd.id);

    if(index === -1){
      ItemToAdd.quantity = quantity;
      items.push(ItemToAdd);
    }
    else
    {
        items[index].quantity += quantity;
    }
    return items;
  }

  private createBasket() : IBasket {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id)
    return basket;
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
      quantity,
      partCategory: item.partCategory,
      partCode: item.partCode,
      vehicleModel: item.VehicleModel,
      partNumber: item.partNumber
    };
  }
}