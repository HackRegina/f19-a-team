import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {Pickup} from "../../data/pickup";

@Component({
  selector: 'app-needle-pickup',
  templateUrl: './needle-pickup.component.html',
  styleUrls: ['./needle-pickup.component.scss']
})
export class NeedlePickupComponent implements OnInit {

  public formGroup: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.formGroup = this.initFormGroup(null);
  }

  public submitPickup() {
    console.log("submitted pickup: ", this.formGroup.getRawValue() as Pickup);
  }

  private initFormGroup(requestId: number): FormGroup {
    return this.fb.group({
      id: requestId,
      count: 0
    });
  }

}
