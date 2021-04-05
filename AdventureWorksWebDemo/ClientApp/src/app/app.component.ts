import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { loadAppConfig } from './app.actions';
import { AppState } from './app.reducer';
import { getConfig } from './app.selectors';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Adventure works web demo';

  configLoaded: boolean

  constructor(private store: Store<AppState>) {
    this.store.select(getConfig).subscribe(cfg => {
      this.configLoaded = cfg != undefined;
    });

    this.store.dispatch(loadAppConfig());
  }
}
