import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EmployeeComponent } from './humanresources/employee/employee.component';
import { JobCandidateComponent } from './humanresources/job-candidate/job-candidate.component';
import { DepartmentComponent } from './humanresources/department/department.component';
import { ShiftComponent } from './humanresources/shift/shift.component';
import { ProductComponent } from './production/product/product.component';
import { OrderComponent } from './sales/order/order.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'humanresources/employee', component: EmployeeComponent },
  { path: 'humanresources/job-candidate', component: JobCandidateComponent },
  { path: 'humanresources/shift', component: ShiftComponent },
  { path: 'humanresources/department', component: DepartmentComponent },
  { path: 'production/products', component: ProductComponent },
  { path: 'sales/orders', component: OrderComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
