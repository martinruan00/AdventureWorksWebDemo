import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BaseTableViewComponent } from './components/base-table-view/base-table-view.component';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatDialogModule } from '@angular/material/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [BaseTableViewComponent],
  exports: [BaseTableViewComponent],
  imports: [
    CommonModule,
    MatTableModule,
    BrowserAnimationsModule,
    MatProgressSpinnerModule,
    MatDialogModule,
    MatGridListModule,
    MatButtonModule,
    MatDialogModule
  ]
})
export class CoreModule { }
