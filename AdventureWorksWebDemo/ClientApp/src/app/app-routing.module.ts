import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { HumanresourcesComponent } from './humanresources/humanresources.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'humanresources', component: HumanresourcesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
