import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { MatSidenavModule } from '@angular/material/sidenav';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatListModule } from '@angular/material/list';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { MatExpansionModule } from '@angular/material/expansion';
import { HumanresourcesModule } from './humanresources/humanresources.module';
import { HttpClientModule } from '@angular/common/http';
import { ConfigService } from '../core/config.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProductionModule } from './production/production.module';
import { SalesModule } from './sales/sales.module';
import { StoreModule } from '@ngrx/store';
import { appReducer } from './app.reducer';
import { EffectsModule } from '@ngrx/effects';
import { AppEffects } from './app.effects';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatSidenavModule,
    MatListModule,
    RouterModule,
    MatExpansionModule,
    HttpClientModule,
    MatProgressSpinnerModule,
    NgbModule,
    HumanresourcesModule,
    ProductionModule,
    SalesModule,
    StoreModule.forRoot({ root: appReducer }),
    EffectsModule.forRoot([AppEffects])
  ],
  providers: [

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
