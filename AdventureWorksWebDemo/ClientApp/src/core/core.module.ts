import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BaseTableViewComponent } from './components/core/base-table-view/base-table-view.component';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [BaseTableViewComponent],
  exports: [BaseTableViewComponent],
  imports: [
    CommonModule,
    MatTableModule
  ]
})
export class CoreModule { }
