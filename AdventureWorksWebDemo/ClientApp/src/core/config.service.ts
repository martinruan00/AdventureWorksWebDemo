import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../model/app-config';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  config: AppConfig;

  constructor(private http: HttpClient) {
    
  }

  loadConfig(): void {
    this.http.get<AppConfig>('../assets/app-config.json')
      .subscribe(c => {
        this.config = c;
      });
  }
}
