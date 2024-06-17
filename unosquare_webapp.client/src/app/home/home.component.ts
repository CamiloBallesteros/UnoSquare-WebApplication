import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from '../../Models/Product';
import { ApiResponse } from '../../Models/HttpResponses/ApiResponse';
import { AddDeleteResponse } from '../../Models/HttpResponses/AddDeleteResponse';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  public products: Product[] = [];

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.getProductsList();
  }

  getProductsList() {
    this.http.get<ApiResponse<Product[]>>('/api/products').subscribe(
      (result) => {
        if (result.ok)
          this.products = result.data;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  deleteProduct(id: number) {
    this.http.delete<ApiResponse<AddDeleteResponse>>(`/api/products/${id}`).subscribe(
      (result) => {
        console.log(result);
        if (result.ok) {
          window.location.reload();
        } else {
          alert(result.data.errorMessage);
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
