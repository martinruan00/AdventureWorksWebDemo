import { Component, OnInit } from '@angular/core';
import { Product } from '../../../model/production/product';
import { ColumnDefinition } from '../../../core/components/base-table-view/base-table-view.component';
import { forkJoin, merge, Observable, zip } from 'rxjs';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { PageEvent } from '@angular/material/paginator';
import { ProductState } from './product.reducer';
import { Store } from '@ngrx/store';
import { getIsLoading, getLoadingProcess, getProductColumnMetadata, getProducts } from './product.selectors';
import { endLoad, loadProductColumnMetadata, loadProducts, startLoad, toggleIsLoading } from './product.actions';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  isLoading: boolean;
  items: Product[];
  columnMetadata: ColumnDefinition[];
  pageSize: number = 10;
  currentPageItems: Product[];
  products$: Observable<Product[]>;
  columnMetadata$: Observable<ColumnDefinition[]>;



  constructor(private sanitizer: DomSanitizer, private store: Store<ProductState>) { }

  ngOnInit(): void {
    this.store.select(getIsLoading).subscribe(result => {
    //  this.isLoading = result;
    });

    this.store.select(getLoadingProcess).subscribe(loadingProcess => {
      this.isLoading = loadingProcess == 0;
    });

    this.products$ = this.store.select(getProducts);

    this.store.select(getProducts).subscribe(products => {
      this.items = products;
      this.currentPageItems = this.items.slice(0, this.pageSize);
      //this.items.forEach(i => {
      //  i.safeResourcePhotos = i.photos.map(p => this.transformUrl(p));
      //});
    },
    error => console.log(error),
    () => {
      this.store.dispatch(endLoad());
    });

    this.columnMetadata$ = this.store.select(getProductColumnMetadata);
    this.columnMetadata$.subscribe(metadata => {
      this.columnMetadata = metadata;
    },
    error => console.log(error),
    () => {
      this.store.dispatch(endLoad());
    });

    this.store.dispatch(toggleIsLoading());

    this.store.dispatch(startLoad());
    this.store.dispatch(loadProducts());

    this.store.dispatch(startLoad());
    this.store.dispatch(loadProductColumnMetadata());
  }

  transformUrl(url: string): SafeResourceUrl {
    return this.sanitizer.bypassSecurityTrustResourceUrl(`data:image/png;base64, ${url}`);
  }

  onPageChanged(env: PageEvent): void {
    this.currentPageItems = this.items.slice(env.pageIndex * env.pageSize, env.pageIndex * env.pageSize + env.pageSize);
  }
}
