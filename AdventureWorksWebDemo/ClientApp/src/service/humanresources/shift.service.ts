import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/config.service';
import { RestBaseService } from '../../core/rest-base.service';
import { Shift } from '../../model/humanresources/shift';
import { Store } from '@ngrx/store';
import { AppState } from '../../app/app.reducer';

@Injectable({
  providedIn: 'root'
})
export class ShiftService extends RestBaseService<Shift> {
  

  constructor(http: HttpClient, store: Store<AppState>) {
    super(http, store);
  }

  protected getApiPath(): string {
    return "shifts";
  }

  protected getId(model: Shift): number {
    return model.shiftId;
  }
}
