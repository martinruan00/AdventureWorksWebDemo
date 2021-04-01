import { Injectable } from '@angular/core';
import { RestBaseService } from '../../core/rest-base.service';
import { Order } from '../../model/sales/order';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/config.service';

@Injectable({
  providedIn: 'root'
})
export class OrderService extends RestBaseService<Order> {

  constructor(http: HttpClient, configService: ConfigService) {
    super(http, configService);
  }

  protected getApiPath(): string {
      return "order"
  }
  protected getId(model: Order): number {
    return model.salesOrderId;
  }

}
