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

  constructor(public service: EmployeeService) { }

  ngOnInit(): void {
  }

}
