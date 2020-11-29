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

export function initConfig(configService: ConfigService) {
  return () => configService.loadConfig();
}

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
    ProductionModule
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: initConfig,
      deps: [ConfigService],
      multi: true
    }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
