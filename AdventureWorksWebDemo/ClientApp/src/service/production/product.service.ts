import { Injectable } from '@angular/core';
import { RestBaseService } from '../../core/rest-base.service';
import { Product } from '../../model/production/product';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/config.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends RestBaseService<Product> {

  constructor(http: HttpClient, configService: ConfigService) {
    super(http, configService);
  }

  protected getApiPath(): string {
    return "product";
  }
  protected getId(model: Product): number {
    return model.productId;
  }

}
