"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.endLoad = exports.startLoad = exports.toggleIsLoading = exports.loadProductColumnMetadataSuccess = exports.loadProductColumnMetadata = exports.selectProduct = exports.loadProductsError = exports.loadProductsSuccess = exports.loadProducts = void 0;
var store_1 = require("@ngrx/store");
exports.loadProducts = store_1.createAction('[Product] load products');
exports.loadProductsSuccess = store_1.createAction('[Product] load products success', store_1.props());
exports.loadProductsError = store_1.createAction('[Product] load products error');
exports.selectProduct = store_1.createAction('[Product] select product', store_1.props());
exports.loadProductColumnMetadata = store_1.createAction('[Product] load product column metadata');
exports.loadProductColumnMetadataSuccess = store_1.createAction('[Product] load product column metadata success', store_1.props());
exports.toggleIsLoading = store_1.createAction('[Product] is loading');
exports.startLoad = store_1.createAction('[Product] start load');
exports.endLoad = store_1.createAction('[Product] end load');
//# sourceMappingURL=product.actions.js.map