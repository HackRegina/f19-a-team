import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {PickupRequest} from "../data/pickup-request";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class PickupRequestService {

  httpOptions = {
    headers: new HttpHeaders({
      'Access-Control-Allow-Origin':'*'
    })
  };

  constructor(private httpClient: HttpClient) { }

  public requestNeedlePickup(pickupRequest: PickupRequest): void {
    this.httpClient.post(`${environment.baseUrl}/PickUpRequests?Phone_Number=${pickupRequest.phone_Number}&Description=${pickupRequest.description}&Location_Lat=${pickupRequest.location_Lat}&Location_Long=${pickupRequest.location_Long}`, pickupRequest, this.httpOptions).subscribe(
      response => console.log(response),
      err => console.log(err)
    );
    console.log("Requesting pickup: ", pickupRequest);
  }

  public getPickupRequests(): Array<PickupRequest> {
    this.httpClient.get(`${environment.baseUrl}/PickUpRequests/list`).subscribe(
      response => console.log("response from get: ", response),
      err => console.log(err)
    );
    // mock data for now
    return [
      {
        description: "near the dumpster",
        count: 4,
        phone_Number: 3065555555,
        location_Lat: 50.4412,
        location_Long: -104.6200,
      } as PickupRequest,
      {
        description: "at the end of the alley",
        count: 1,
        phone_Number: 3065555555,
        location_Lat: 50.4452,
        location_Long: -104.6189,
      } as PickupRequest,
      {
        description: "under the stairs",
        count: 4,
        phone_Number: 3065555555,
        location_Lat: 50.4482,
        location_Long: -104.6169,
      } as PickupRequest,
    ];
  }

}
