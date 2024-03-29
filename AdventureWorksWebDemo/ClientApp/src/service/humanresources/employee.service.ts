import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/config.service';
import { Employee } from '../../model/humanresources/employee';
import { RestBaseService } from '../../core/rest-base.service';
import { AppState } from '../../app/app.reducer';
import { Store } from '@ngrx/store';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends RestBaseService<Employee> {

  constructor(http: HttpClient, store: Store<AppState>) {
    super(http, store);
  }

  protected getApiPath(): string {
    return "employees";
  }

  protected getId(model: Employee): number {
    return model.employeeId;
  }
}
