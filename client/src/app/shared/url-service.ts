import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlService {
  baseUrl='https://localhost:7239/api/';
  constructor() { }
}
