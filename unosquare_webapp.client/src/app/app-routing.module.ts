import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManageProductComponent } from './manage-product/manage-product.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: 'Index', component: HomeComponent },
  { path: 'Product', component: ManageProductComponent },
  { path: 'Product/:id', component: ManageProductComponent },
  { path: '', redirectTo: "Index", pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
