import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  ngOnInit() {

  }

  //addNewProduct() {
  //  console.log("pressed button");
  //  this.http.post<ApiResponse<AddDeleteResponse>>('/api/products', {
  //    id: 0,
  //    name: "Avocado",
  //    description: "Good to Compliment some meals",
  //    price: 5000
  //  }).subscribe(
  //    (result) => {
  //      console.log(result);
  //      //if (result.ok == true)
  //    },
  //    (error) => {
  //      console.error(error);
  //    }
  //  );
  //}

  title = 'UnoSquare WebApplication';
}
