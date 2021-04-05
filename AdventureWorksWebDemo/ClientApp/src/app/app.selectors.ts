import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AppState } from "./app.reducer";

const appRootSelector = createFeatureSelector<AppState>('root');
export const getConfig = createSelector(appRootSelector, state => state.config);
