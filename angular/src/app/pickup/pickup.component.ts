import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-pickup',
  templateUrl: './pickup.component.html',
  styleUrls: ['./pickup.component.scss']
})
export class PickupComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  public clickRequestPickup(): void {
    this.router.navigate(['/request']);
  }

}
