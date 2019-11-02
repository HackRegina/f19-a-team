import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {PickupComponent} from "./user/pickup/pickup.component";
import {PickupRequestComponent} from "./user/pickup-request/pickup-request.component";
import {AdminMapComponent} from "./admin/admin-map/admin-map.component";

const routes: Routes = [
  { path: 'map', component: PickupComponent },
  { path: 'request', component: PickupRequestComponent },
  { path: 'admin' , children: [
      { path: 'pickup', component: AdminMapComponent },
      { path: '', redirectTo: '/admin/pickup', pathMatch: 'full' }
    ]},
  { path: '', redirectTo: '/map', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
