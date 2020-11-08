import { Component, OnInit } from '@angular/core';
import { Employee } from '../../../model/humanresources/employee';
import { EmployeeService } from '../../../service/humanresources/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  displayedColumns: String[] = ['jobTitle', 'birthDate', 'maritalStatus', 'gender', 'hireDate', 'vacationHours', 'sickLeaveHours'];
  employees: Employee[];

  constructor(private service: EmployeeService) { }

  ngOnInit(): void {
    this.service.get().subscribe(response => {
      this.employees = response;
    });
  }

}
