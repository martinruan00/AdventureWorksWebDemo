import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ProductState } from "./product.reducer";

const getProductFeatureState = createFeatureSelector<ProductState>('product');
export const getProducts = createSelector(getProductFeatureState, state => state.products);
export const getSelectedProduct = createSelector(getProductFeatureState, state => state.selectedProduct);
export const getProductColumnMetadata = createSelector(getProductFeatureState, state => state.metadata);
export const getIsLoading = createSelector(getProductFeatureState, state => state.isLoading);
export const getLoadingProcess = createSelector(getProductFeatureState, state => state.loadingProcess);
