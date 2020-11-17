import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/config.service';
import { Menu } from '../../model/metadata/menu';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MetadataService {
  url: string;

  constructor(private httpClient: HttpClient, configService: ConfigService) {
    this.url = `${configService.config?.apiEndpoint}/metadata`;
  }

  getMenu(): Observable<Array<Menu>> {
    return this.httpClient.get<Array<Menu>>(`${this.url}/menu`);
  }
}
