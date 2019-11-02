import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {MapComponent} from './common/map/map.component';
import {HeaderComponent} from './common/header/header.component';
import {RequestMapComponent} from './user/request-map/request-map.component';
import {PickupRequestComponent} from './user/pickup-request/pickup-request.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import { AdminMapComponent } from './admin/admin-map/admin-map.component';
import { NeedlePickupComponent } from './admin/needle-pickup/needle-pickup.component';
import { LoginComponent } from './admin/login/login.component';
import {ErrorInterceptor} from "./interceptors/error.interceptor";
import {JwtInterceptor} from "./interceptors/jwt.interceptor";

@NgModule({
  declarations: [
    AppComponent,
    MapComponent,
    HeaderComponent,
    RequestMapComponent,
    PickupRequestComponent,
    AdminMapComponent,
    NeedlePickupComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
