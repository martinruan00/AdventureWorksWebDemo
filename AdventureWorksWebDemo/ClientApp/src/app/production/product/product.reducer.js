"use strict";
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.productReducer = void 0;
var store_1 = require("@ngrx/store");
var product_actions_1 = require("./product.actions");
var initialState = {
    products: [],
    selectedProduct: undefined,
    metadata: [],
    isLoading: false,
    loadingProcess: 0
};
exports.productReducer = store_1.createReducer(initialState, store_1.on(product_actions_1.loadProducts, function (state) {
    return state;
}), store_1.on(product_actions_1.loadProductsSuccess, function (state, action) {
    return __assign(__assign({}, state), { products: action.products });
}), store_1.on(product_actions_1.selectProduct, function (state, action) {
    return __assign(__assign({}, state), { selectedProduct: action.product });
}), store_1.on(product_actions_1.loadProductColumnMetadata, function (state) {
    return state;
}), store_1.on(product_actions_1.loadProductColumnMetadataSuccess, function (state, action) {
    return __assign(__assign({}, state), { metadata: action.metadata });
}), store_1.on(product_actions_1.toggleIsLoading, function (state) {
    return __assign(__assign({}, state), { isLoading: !state.isLoading });
}), store_1.on(product_actions_1.startLoad, function (state) {
    return __assign(__assign({}, state), { loadingProcess: state.loadingProcess + 1 });
}), store_1.on(product_actions_1.endLoad, function (state) {
    return __assign(__assign({}, state), { loadingProcess: state.loadingProcess - 1 });
}));
//# sourceMappingURL=product.reducer.js.map