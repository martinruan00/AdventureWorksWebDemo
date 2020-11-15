import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root'
})
export abstract class RestBaseService<TModel> {
  private url: string;

  constructor(private http: HttpClient, private configService: ConfigService) {
    if (configService.configObservable.getValue() != null) {
      this.url = `${this.configService.config.apiEndpoint}/${this.getApiPath()}`;
    }

    configService.configObservable.subscribe(c => this.url = `${this.configService.config.apiEndpoint}/${this.getApiPath()}`);
  }

  get(): Observable<Array<TModel>> {
    return this.http.get<Array<TModel>>(this.url);
  }

  post(model: TModel) : Observable<TModel> {
    return this.http.post<TModel>(this.url, model);
  }

  put(id: number, model: TModel): Observable<TModel> {
    return this.http.put<TModel>(`${this.url}/${id}`, model);
  }

  delete(id: number, model: TModel): Observable<TModel> {
    return this.http.delete<TModel>(`${this.url}/${id}`);
  }

  protected abstract getApiPath(): string;
}
