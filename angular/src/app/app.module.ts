import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {MapComponent} from './common/map/map.component';
import {HeaderComponent} from './common/header/header.component';
import {PickupComponent} from './user/pickup/pickup.component';
import {PickupRequestComponent} from './user/pickup-request/pickup-request.component';
import {ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";

@NgModule({
  declarations: [
    AppComponent,
    MapComponent,
    HeaderComponent,
    PickupComponent,
    PickupRequestComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
