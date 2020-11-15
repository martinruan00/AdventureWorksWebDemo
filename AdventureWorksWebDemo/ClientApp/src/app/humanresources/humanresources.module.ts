import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeComponent } from './employee/employee.component';
import { ShiftComponent } from './shift/shift.component';
import { JobCandidateComponent } from './job-candidate/job-candidate.component';
import { DepartmentComponent } from './department/department.component';
import { MatTableModule } from '@angular/material/table';
import { CoreModule } from '../../core/core.module';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [EmployeeComponent, ShiftComponent, JobCandidateComponent, DepartmentComponent],
  exports: [EmployeeComponent, ShiftComponent, JobCandidateComponent, DepartmentComponent],
  imports: [
    BrowserAnimationsModule,
    MatProgressSpinnerModule,
    CommonModule,
    MatTableModule,
    CoreModule
  ]
})
export class HumanresourcesModule { }
