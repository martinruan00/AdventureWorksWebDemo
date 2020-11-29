import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../service/production/product.service';
import { Product } from '../../../model/production/product';
import { ColumnDefinition } from '../../../core/components/base-table-view/base-table-view.component';
import { forkJoin } from 'rxjs';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  isLoading: boolean;
  items: Product[];
  columnMetadata: ColumnDefinition[];

  constructor(private service: ProductService, private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.isLoading = true;
    forkJoin(this.service.get(), this.service.getColumnMetadata())
      .subscribe(
        responses => {
          this.items = responses[0];
          this.columnMetadata = responses[1];

          this.items.forEach(i => {
            i.safeResourcePhotos = i.photos.map(p => this.transformUrl(p));
          });
        },
        err => {

        },
        () => this.isLoading = false);
  }

  transformUrl(url: string): SafeResourceUrl {
    return this.sanitizer.bypassSecurityTrustResourceUrl(`data:image/png;base64, ${url}`);
  }
}
