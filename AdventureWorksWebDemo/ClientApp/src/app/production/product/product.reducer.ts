import { createReducer, on } from "@ngrx/store";
import { ColumnDefinition } from "../../../core/components/base-table-view/base-table-view.component";
import { Product } from "../../../model/production/product";
import { endLoad, loadProductColumnMetadata, loadProductColumnMetadataSuccess, loadProducts, loadProductsSuccess, selectProduct, startLoad, toggleIsLoading } from "./product.actions";

export interface ProductState {
  products: Array<Product>;
  selectedProduct: Product;
  metadata: Array<ColumnDefinition>;
  isLoading: boolean;
  loadingProcess: number;
}

const initialState = <ProductState>{
  products: [],
  selectedProduct: undefined,
  metadata: [],
  isLoading: false,
  loadingProcess: 0
};

export const productReducer = createReducer<ProductState>(
  initialState,
  on(loadProducts, (state): ProductState => {
    return state;
  }),
  on(loadProductsSuccess, (state, action): ProductState => {
    return {
      ...state,
      products: action.products
    };
  }),
  on(selectProduct, (state, action): ProductState => {
    return {
      ...state,
      selectedProduct: action.product
    };
  }),
  on(loadProductColumnMetadata, (state): ProductState => {
    return state;
  }),
  on(loadProductColumnMetadataSuccess, (state, action) : ProductState => {
    return {
      ...state,
      metadata: action.metadata
    };
  }),
  on(toggleIsLoading, (state): ProductState => {
    return {
      ...state,
      isLoading: !state.isLoading
    };
  }),
  on(startLoad, (state): ProductState => {
    return {
      ...state,
      loadingProcess: state.loadingProcess + 1
    };
  }),
  on(endLoad, (state): ProductState => {
    return {
      ...state,
      loadingProcess: state.loadingProcess - 1
    };
  })
);
