import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/config.service';
import { Department } from '../../model/humanresources/department';
import { Employee } from '../../model/humanresources/employee';
import { RestBaseService } from '../../core/rest-base.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends RestBaseService<Employee> {

  constructor(http: HttpClient, configService: ConfigService) {
    super(http, configService);
  }

  protected getApiPath(): string {
    return "employees";
  }
}