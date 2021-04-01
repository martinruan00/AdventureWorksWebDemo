import { RestBaseService } from '../../rest-base.service';
import { ColumnDefinition } from '../base-table-view/base-table-view.component';
import { OnInit, Component } from '@angular/core';
import { forkJoin } from 'rxjs';
import { PageEvent } from '@angular/material/paginator';

@Component({
  template: ''
})
export class BaseAdventureWorksComponent<TModel> implements OnInit {
  items: TModel[];
  currentPageItems: TModel[];
  columnMetadata: ColumnDefinition[];
  pageSize: number = 10;
  pageSizeOptions = [5, 10, 25, 100];
  isLoading: boolean;

  constructor(private service: RestBaseService<TModel>) { }

  ngOnInit(): void {
    this.isLoading = true;
    forkJoin(this.service.get(), this.service.getColumnMetadata())
      .subscribe(
        responses => {
          this.items = responses[0];
          this.currentPageItems = this.items.slice(0, this.pageSize);
          this.columnMetadata = responses[1];

          this.afterInit();
        },
        err => {

        },
        () => this.isLoading = false);
  }

  protected afterInit(): void {

  }

  onPageChanged(env: PageEvent): void {
    this.currentPageItems = this.items.slice(env.pageIndex * env.pageSize, env.pageIndex * env.pageSize + env.pageSize);
  }
}
