import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class PickupRequestService {

  constructor(private httpClient: HttpClient) { }

  public requestNeedlePickup(): void { // TODO: return object

  }

}
