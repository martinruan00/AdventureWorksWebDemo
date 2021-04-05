import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/config.service';
import { Menu } from '../../model/metadata/menu';
import { Observable } from 'rxjs';
import { AppState } from '../../app/app.reducer';
import { Store } from '@ngrx/store';
import { getConfig } from '../../app/app.selectors';

@Injectable({
  providedIn: 'root'
})
export class MetadataService {
  url: string;

  constructor(private httpClient: HttpClient, private store: Store<AppState>) {
    this.store.select(getConfig).subscribe(cfg => {
      this.url = `${cfg.apiEndpoint}/metadata`;
    });
  }

  getMenu(): Observable<Array<Menu>> {
    return this.httpClient.get<Array<Menu>>(`${this.url}/menu`);
  }
}
