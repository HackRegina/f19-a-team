import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {PickupRequestService} from "../services/pickup-request/pickup-request.service";
import {PickupRequest} from "../data/pickup-request";

@Component({
  selector: 'app-pickup-request',
  templateUrl: './pickup-request.component.html',
  styleUrls: ['./pickup-request.component.scss']
})
export class PickupRequestComponent implements OnInit {

  public requestFormGroup: FormGroup;

  constructor(private fb: FormBuilder, private pickupRequestService: PickupRequestService) { }

  ngOnInit() {
    this.requestFormGroup = this.initFormGroup();
  }

  public submitRequest(): void {
    console.log(this.requestFormGroup.getRawValue() as PickupRequest);
    this.pickupRequestService.requestNeedlePickup();
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

}
