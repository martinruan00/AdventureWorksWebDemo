import { Injectable } from '@angular/core';
import { RestBaseService } from '../../core/rest-base.service';
import { Product } from '../../model/production/product';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/config.service';
import { AppState } from '../../app/app.reducer';
import { Store } from '@ngrx/store';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends RestBaseService<Product> {

  constructor(http: HttpClient, store: Store<AppState>) {
    super(http, store);
  }

  protected getApiPath(): string {
    return "product";
  }
  protected getId(model: Product): number {
    return model.productId;
  }

}
