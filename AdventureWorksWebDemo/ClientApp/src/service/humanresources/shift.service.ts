import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/config.service';
import { RestBaseService } from '../../core/rest-base.service';
import { Shift } from '../../model/humanresources/shift';

@Injectable({
  providedIn: 'root'
})
export class ShiftService extends RestBaseService<Shift> {

  constructor(http: HttpClient, configService: ConfigService) {
    super(http, configService);
  }

  protected getApiPath(): string {
    return "shift";
  }}
