import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {PickupRequest} from "../../data/pickup-request";

@Injectable({
  providedIn: 'root'
})
export class PickupRequestService {

  constructor(private httpClient: HttpClient) { }

  public requestNeedlePickup(pickupRequest: PickupRequest): void {
    console.log("Requesting pickup: ", pickupRequest);
  }

}
