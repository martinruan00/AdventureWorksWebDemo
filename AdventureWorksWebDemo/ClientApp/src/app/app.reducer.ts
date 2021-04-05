import { createReducer, on } from "@ngrx/store";
import { AppConfig } from "../model/app-config";
import { appAction, loadAppConfig, loadAppConfigSuccess } from "./app.actions";

export interface AppState {
  config: AppConfig;
}

const initialState = <AppState>{
  config: <AppConfig>{}
}

export const appReducer = createReducer(
  initialState,
  on(appAction, state => {
    return state;
  }),
  on(loadAppConfig, (state) : AppState => {
    return state;
  }),
  on(loadAppConfigSuccess, (state, action): AppState => {
    return {
      ...state,
      config: action.config
    };
  })
);
