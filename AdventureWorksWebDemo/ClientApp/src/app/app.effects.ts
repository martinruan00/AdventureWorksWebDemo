import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { mergeMap, map } from "rxjs/operators";
import { ConfigService } from "../core/config.service";
import { loadAppConfig, loadAppConfigSuccess } from "./app.actions";

@Injectable()
export class AppEffects {
  constructor(private action$: Actions, private service: ConfigService) {

  }

  loadConfig$ = createEffect(() => this.action$.pipe(
    ofType(loadAppConfig),
    mergeMap(() => {
      return this.service.loadAppConfig().pipe(
        map(config => {
          return loadAppConfigSuccess({ config });
        }));
    }
    ))
  );
}
