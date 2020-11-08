import { Injectable } from '@angular/core';
import { Department } from '../../model/humanresources/department';
import { RestBaseService } from '../../core/rest-base.service';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/config.service';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService extends RestBaseService<Department> {

  constructor(http: HttpClient, configService: ConfigService) {
    super(http, configService);
  }

  protected getApiPath(): string {
    return "departments";
  }
}
