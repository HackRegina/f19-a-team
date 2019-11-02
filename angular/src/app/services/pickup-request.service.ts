import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {PickupRequest} from "../data/pickup-request";

@Injectable({
  providedIn: 'root'
})
export class PickupRequestService {

  constructor(private httpClient: HttpClient) { }

  public requestNeedlePickup(pickupRequest: PickupRequest): void {
    console.log("Requesting pickup: ", pickupRequest);
  }

  public getPickupRequests(): Array<PickupRequest> {
    // mock data for now
    return [
      {
        description: "near the dumpster",
        count: 4,
        phoneNumber: 3065555555,
        latitude: 50.4412,
        longitude: -104.6200,
      } as PickupRequest,
      {
        description: "at the end of the alley",
        count: 1,
        phoneNumber: 3065555555,
        latitude: 50.4452,
        longitude: -104.6189,
      } as PickupRequest,
      {
        description: "under the stairs",
        count: 4,
        phoneNumber: 3065555555,
        latitude: 50.4482,
        longitude: -104.6169,
      } as PickupRequest,
    ];
  }

}
