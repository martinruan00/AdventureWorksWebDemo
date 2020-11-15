import { Component, OnInit } from '@angular/core';
import { Employee } from '../../../model/humanresources/employee';
import { EmployeeService } from '../../../service/humanresources/employee.service';
import { ColumnDefinition } from '../../../core/components/base-table-view/base-table-view.component';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  loading: boolean;
  employees: Employee[];
  columnDefinitions: ColumnDefinition[] = [
    { key: 'nationalIdnumber', header: 'Id number' },
    { key: 'title', header: 'Title' },
    { key: 'firstName', header: 'First name' },
    { key: 'middleName', header: 'Middle name' },
    { key: 'lastName', header: 'Last name' },
    { key: 'jobTitle', header: 'Job title' },
    { key: 'birthDate', header: 'Birth date' },
    { key: 'maritalStatus', header: 'Marital status' },
    { key: 'gender', header: 'Gender' },
    { key: 'hireDate', header: 'HireDate' },
    { key: 'vacationHours', header: 'Vacation hours' },
    { key: 'sickLeaveHours', header: 'Sickleave hours' },
    { key: 'additionalContactInfo', header: 'Additional contact info' }];
    

  constructor(private service: EmployeeService) { }

  ngOnInit(): void {
    this.loading = true;
    this.service.get().subscribe(response => {
      this.employees = response;
      this.loading = false;
    });
  }

}
