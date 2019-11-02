import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MapComponent } from './map/map.component';
import { HeaderComponent } from './header/header.component';
import { PickupComponent } from './pickup/pickup.component';
import { PickupRequestComponent } from './pickup-request/pickup-request.component';

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
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
