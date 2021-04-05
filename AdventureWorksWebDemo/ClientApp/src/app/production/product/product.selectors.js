"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.getLoadingProcess = exports.getIsLoading = exports.getProductColumnMetadata = exports.getSelectedProduct = exports.getProducts = void 0;
var store_1 = require("@ngrx/store");
var getProductFeatureState = store_1.createFeatureSelector('product');
exports.getProducts = store_1.createSelector(getProductFeatureState, function (state) { return state.products; });
exports.getSelectedProduct = store_1.createSelector(getProductFeatureState, function (state) { return state.selectedProduct; });
exports.getProductColumnMetadata = store_1.createSelector(getProductFeatureState, function (state) { return state.metadata; });
exports.getIsLoading = store_1.createSelector(getProductFeatureState, function (state) { return state.isLoading; });
exports.getLoadingProcess = store_1.createSelector(getProductFeatureState, function (state) { return state.loadingProcess; });
//# sourceMappingURL=product.selectors.js.map