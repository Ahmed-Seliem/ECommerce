import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import { IProduct } from '../shared/models/product';
import { UrlService } from '../shared/url-service';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  constructor(private http:HttpClient,private urlService:UrlService) { }
  getProducts() {
return this.http.get<IPagination>(`${this.urlService.baseUrl}Products/brands`);
  }
}
