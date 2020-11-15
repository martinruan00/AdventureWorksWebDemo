import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../model/app-config';
import { Observable, Subject, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  config: AppConfig;
  configObservable = new BehaviorSubject<AppConfig>(null);

  constructor(private http: HttpClient) {
  }

  loadConfig(): void {
    this.http.get<AppConfig>('../assets/app-config.json')
      .subscribe(c => {
        this.config = c;
        this.configObservable.next(this.config);
        console.log('app config loaded');
      });
  }
}
