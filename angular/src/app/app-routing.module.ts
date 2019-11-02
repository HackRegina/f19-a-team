import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {RequestMapComponent} from "./user/request-map/request-map.component";
import {PickupRequestComponent} from "./user/pickup-request/pickup-request.component";
import {AdminMapComponent} from "./admin/admin-map/admin-map.component";
import {NeedlePickupComponent} from "./admin/needle-pickup/needle-pickup.component";
import {LoginComponent} from "./admin/login/login.component";

const routes: Routes = [
  { path: 'map', component: RequestMapComponent },
  { path: 'request', component: PickupRequestComponent },
  { path: 'admin' , children: [
      { path: 'login', component: LoginComponent },
      { path: 'pickup-map', component: AdminMapComponent },
      { path: 'needle-pickup', component: NeedlePickupComponent },
      { path: '', redirectTo: '/admin/pickup-map', pathMatch: 'full' }
    ]},
  { path: '', redirectTo: '/map', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
