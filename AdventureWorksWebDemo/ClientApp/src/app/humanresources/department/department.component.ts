import { Component, OnInit } from '@angular/core';
import { Department } from '../../../model/humanresources/department';
import { DepartmentService } from '../../../service/humanresources/department.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {

  constructor(public service: DepartmentService) {
  }

  ngOnInit(): void {
  }

  createItem(): object {
    return <Department>{};
  }

  getId(item: object): number {
    return (<Department>item).departmentId;
  }
}
