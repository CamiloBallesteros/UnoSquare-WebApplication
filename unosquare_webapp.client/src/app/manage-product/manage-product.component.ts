import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiResponse } from '../../Models/HttpResponses/ApiResponse';
import { Product } from '../../Models/Product';
import { HttpClient } from '@angular/common/http';
import { AddDeleteResponse } from '../../Models/HttpResponses/AddDeleteResponse';

@Component({
  selector: 'app-manage-product',
  templateUrl: './manage-product.component.html',
  styleUrl: './manage-product.component.css'
})
export class ManageProductComponent implements OnInit {
  viewProduct: Product = { id: 0, name: '', description: '', price: 0 };
  Id: any;

  constructor(
    private http: HttpClient,
    private _routeParams: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.Id = this._routeParams.snapshot.params['id'];
    if (this.Id != undefined) {
      this.getProduct();
    }
  }

  getProduct() {
    this.http.get<ApiResponse<Product>>(`/api/products/${this.Id}`).subscribe(
      (result) => {
        console.log(result);
        if (result.ok)
          this.viewProduct = result.data;
      },
      (error) => {
        console.error(error);
        alert('Internal error');
      }
    );
  }

  addNewProduct() {
    this.http.post<ApiResponse<AddDeleteResponse>>('/api/products', {
      id: this.viewProduct.id,
      name: this.viewProduct.name,
      description: this.viewProduct.description,
      price: this.viewProduct.price
    }).subscribe(
      (result) => {
        console.log(result);
        if (result.ok) {
          alert(result.data.successMessage);
          this.router.navigate([''])
        } else {
          alert(result.data.errorMessage);
        }
      },
      (error) => {
        console.error(error);
        alert('Internal error');
      }
    );
  }

  updateProduct() {
    this.http.put<ApiResponse<AddDeleteResponse>>('/api/products', {
      id: this.viewProduct.id,
      name: this.viewProduct.name,
      description: this.viewProduct.description,
      price: this.viewProduct.price
    }).subscribe(
      (result) => {
        console.log(result);
        if (result.ok) {
          alert(result.data.successMessage);
          this.router.navigate(['']);
        } else {
          alert(result.data.errorMessage);
        }
      },
      (error) => {
        console.error(error);
        alert('Internal error');
      }
    );
  }
}
