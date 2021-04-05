import { createAction, props } from "@ngrx/store";
import { AppConfig } from "../model/app-config";

export const appAction = createAction('[App] app action');
export const loadAppConfig = createAction('[App] load app config');
export const loadAppConfigSuccess = createAction('[App] load app config success', props<{ config: AppConfig }>());
