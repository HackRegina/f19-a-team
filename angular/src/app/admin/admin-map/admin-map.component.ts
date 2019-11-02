import { Component, OnInit } from '@angular/core';
import {MapService} from "../../services/map/map.service";
import OlVector from 'ol/layer/Vector';

@Component({
  selector: 'app-admin-map',
  templateUrl: './admin-map.component.html',
  styleUrls: ['./admin-map.component.scss']
})
export class AdminMapComponent implements OnInit {

  private pickupRequestLayer: OlVector;

  constructor(private mapService: MapService) { }

  ngOnInit() {
    this.initPickupRequestLayer();
  }

  public initPickupRequestLayer() {
    this.pickupRequestLayer = null;
  }

}
