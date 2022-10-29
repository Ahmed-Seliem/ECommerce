import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: any;

  constructor( private shopService: ShopService) { }

  ngOnInit() {
    this.shopService.getProducts().subscribe(response =>
      {
        console.log(response);
        this.products= response;
      },error =>{
        console.log(error);
      })
  }

}
