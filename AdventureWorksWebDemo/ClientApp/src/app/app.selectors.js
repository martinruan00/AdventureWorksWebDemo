"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.getConfig = void 0;
var store_1 = require("@ngrx/store");
var appRootSelector = store_1.createFeatureSelector('root');
exports.getConfig = store_1.createSelector(appRootSelector, function (state) { return state.config; });
//# sourceMappingURL=app.selectors.js.map