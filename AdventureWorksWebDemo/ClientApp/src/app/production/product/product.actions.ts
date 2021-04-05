import { createAction, props } from "@ngrx/store";
import { ColumnDefinition } from "../../../core/components/base-table-view/base-table-view.component";
import { Product } from "../../../model/production/product";

export const loadProducts = createAction('[Product] load products');
export const loadProductsSuccess = createAction('[Product] load products success', props<{ products: Array<Product> }>());
export const loadProductsError = createAction('[Product] load products error');
export const selectProduct = createAction('[Product] select product', props<{ product: Product }>());
export const loadProductColumnMetadata = createAction('[Product] load product column metadata');
export const loadProductColumnMetadataSuccess = createAction('[Product] load product column metadata success', props<{ metadata: Array<ColumnDefinition> }>());
export const toggleIsLoading = createAction('[Product] is loading');
export const startLoad = createAction('[Product] start load');
export const endLoad = createAction('[Product] end load');
