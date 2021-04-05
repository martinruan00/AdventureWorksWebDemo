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
exports.appReducer = void 0;
var store_1 = require("@ngrx/store");
var app_actions_1 = require("./app.actions");
var initialState = {
    config: {}
};
exports.appReducer = store_1.createReducer(initialState, store_1.on(app_actions_1.appAction, function (state) {
    return state;
}), store_1.on(app_actions_1.loadAppConfig, function (state) {
    return state;
}), store_1.on(app_actions_1.loadAppConfigSuccess, function (state, action) {
    return __assign(__assign({}, state), { config: action.config });
}));
//# sourceMappingURL=app.reducer.js.map