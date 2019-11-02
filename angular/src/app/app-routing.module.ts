import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {MapComponent} from "./map/map.component";
import {PickupComponent} from "./pickup/pickup.component";
import {PickupRequestComponent} from "./pickup-request/pickup-request.component";

const routes: Routes = [
  { path: 'map', component: PickupComponent },
  { path: 'request', component: PickupRequestComponent },
  { path: '', redirectTo: '/map', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
