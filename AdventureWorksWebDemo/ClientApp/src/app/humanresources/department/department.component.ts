import { Component, OnInit } from '@angular/core';
import { Department } from '../../../model/humanresources/department';
import { DepartmentService } from '../../../service/humanresources/department.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {
  displayedColumns: String[] = ['name', 'groupName'];
  departments: Array<Department>;

  constructor(private service: DepartmentService) {    
  }

  ngOnInit(): void {
    this.service.get().subscribe(response => {
      this.departments = response;
    });
  }
}
