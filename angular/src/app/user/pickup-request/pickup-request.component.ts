import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {PickupRequestService} from "../../services/pickup-request/pickup-request.service";
import {PickupRequest} from "../../data/pickup-request";
import {MapLocation} from "../../data/map-location";
import {Subscription} from "rxjs";
import {MapService} from "../../services/map/map.service";

@Component({
  selector: 'app-pickup-request',
  templateUrl: './pickup-request.component.html',
  styleUrls: ['./pickup-request.component.scss']
})
export class PickupRequestComponent implements OnInit, OnDestroy {

  public requestFormGroup: FormGroup;

  private locationSubscription: Subscription = Subscription.EMPTY;

  constructor(private fb: FormBuilder,
              private pickupRequestService: PickupRequestService,
              private mapService: MapService) { }

  ngOnInit() {
    this.requestFormGroup = this.initFormGroup();
    this.mapService.currentLocation$.subscribe((location: MapLocation) => {
      console.log("current location: ", location);
      this.requestFormGroup.patchValue({
        latitude: location ? location.latitude : null,
        longitude: location ? location.longitude : null
      })
    });
  }

  public submitRequest(): void {
    console.log(this.requestFormGroup.getRawValue() as PickupRequest);
    this.pickupRequestService.requestNeedlePickup(this.requestFormGroup.getRawValue() as PickupRequest);
  }

  private initFormGroup(): FormGroup {
    return this.fb.group({
      description: null,
      phoneNumber: null,
      count: 0,
      latitude: null,
      longitude: null
    });
  }

  ngOnDestroy(): void {
    this.locationSubscription.unsubscribe();
  }

}
