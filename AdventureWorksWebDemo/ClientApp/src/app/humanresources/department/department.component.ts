import { Component, OnInit } from '@angular/core';
import { Department } from '../../../model/humanresources/department';
import { DepartmentService } from '../../../service/humanresources/department.service';
import { ColumnDefinition } from '../../../core/components/base-table-view/base-table-view.component';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {
  loading: boolean;
  departments: Array<Department>;
  columnDefinitions: ColumnDefinition[] = [
    { key: 'name', header: 'Name'},
    { key: 'groupName', header: 'Group name'}
  ];

  constructor(private service: DepartmentService) {    
  }

  ngOnInit(): void {
    this.loading = true;
    this.service.get().subscribe(response => {
      this.departments = response;
      this.loading = false;
    });
  }
}
