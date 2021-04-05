import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ColumnDefinition } from './components/base-table-view/base-table-view.component';
import { AppState } from '../app/app.reducer';
import { Store } from '@ngrx/store';
import { getConfig } from '../app/app.selectors';

@Injectable({
  providedIn: 'root'
})
export abstract class RestBaseService<TModel> {
  private url: string;

  constructor(private http: HttpClient, private store: Store<AppState>) {
    this.store.select(getConfig).subscribe(cfg => {
      this.url = `${cfg.apiEndpoint}/${this.getApiPath()}`;
    });
  }

  get(): Observable<Array<TModel>> {
    return this.http.get<Array<TModel>>(this.url);
  }

  post(model: TModel) : Observable<TModel> {
    return this.http.post<TModel>(this.url, model);
  }

  put(model: TModel): Observable<TModel> {
    return this.http.put<TModel>(`${this.url}/${this.getId(model)}`, model);
  }

  delete(model: TModel): Observable<TModel> {
    return this.http.delete<TModel>(`${this.url}/${this.getId(model)}`);
  }

  getColumnMetadata(): Observable<Array<ColumnDefinition>> {
    return this.http.get<Array<ColumnDefinition>>(`${this.url}/columnmetadata`);
  }

  protected abstract getApiPath(): string;
  protected abstract getId(model: TModel): number;
}
