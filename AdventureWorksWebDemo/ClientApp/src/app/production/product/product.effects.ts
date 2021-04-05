import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { ProductService } from "../../../service/production/product.service";
import { loadProductColumnMetadata, loadProductColumnMetadataSuccess, loadProducts, loadProductsSuccess } from "./product.actions";
import { mergeMap, map } from "rxjs/operators"
import { DomSanitizer, SafeResourceUrl } from "@angular/platform-browser";

@Injectable()
export class ProductEffects {
  constructor(private action$: Actions, private service: ProductService, private sanitizer: DomSanitizer) {

  }

  loadProducts$ = createEffect(() => this.action$.pipe(
    ofType(loadProducts),
    mergeMap(() => {
      return this.service.get().pipe(
        map(products => {
          products.forEach(i => {
            i.safeResourcePhotos = i.photos.map(p => this.transformUrl(p));
          });
          return loadProductsSuccess({ products });
        })
      );
    })
  ));

  loadProductColumnMetadata$ = createEffect(() => this.action$.pipe(
    ofType(loadProductColumnMetadata),
    mergeMap(() => {
      return this.service.getColumnMetadata().pipe(
        map(metadata => loadProductColumnMetadataSuccess({ metadata }))
        );
    }))
  );


  transformUrl(url: string): SafeResourceUrl {
    return this.sanitizer.bypassSecurityTrustResourceUrl(`data:image/png;base64, ${url}`);
  }

}
