import { Component } from '@angular/core';
import { Order } from '../../../model/sales/order';
import { OrderService } from '../../../service/sales/order.service';
import { BaseAdventureWorksComponent } from '../../../core/components/base-adventure-works/base-adventure-works.component';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent extends BaseAdventureWorksComponent<Order> {

  constructor(service: OrderService) {
    super(service);
  }
}
