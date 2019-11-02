import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-pickup',
  templateUrl: './request-map.component.html',
  styleUrls: ['./request-map.component.scss']
})
export class RequestMapComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {

  }

  public clickRequestPickup(): void {
    this.router.navigate(['/f19-a-team/request']);
  }

}
