import { Component, Input, OnInit } from '@angular/core';
import { Part } from 'src/app/_models/part';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {
  @Input() product: Part;

  constructor() {
    this.product = new Part;
   }

  ngOnInit(): void {
  }

}
