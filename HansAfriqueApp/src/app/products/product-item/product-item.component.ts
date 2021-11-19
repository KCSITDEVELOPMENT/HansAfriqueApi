import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BasketService } from 'src/app/services/basket.service';
import { Part } from 'src/app/_models/part';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {
  @Input() product: Part;

  constructor( private basketService : BasketService,   private toastrService: ToastrService  ) {
    this.product = new Part;
   }

  ngOnInit(): void {
  }


  addItemToBasket(){
    this.basketService.addItemToBasket(this.product);
    this.toastrService.success("Item Added to basket");
  }
}
