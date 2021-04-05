import { Injectable } from '@angular/core';
import { Department } from '../../model/humanresources/department';
import { RestBaseService } from '../../core/rest-base.service';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/config.service';
import { AppState } from '../../app/app.reducer';
import { Store } from '@ngrx/store';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService extends RestBaseService<Department> {

  constructor(http: HttpClient, store: Store<AppState>) {
    super(http, store);
  }

  protected getApiPath(): string {
    return "departments";
  }

  protected getId(model: Department): number {
    return model.departmentId;
  }
}
