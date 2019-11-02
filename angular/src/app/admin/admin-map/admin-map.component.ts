import { Component, OnInit } from '@angular/core';
import {MapService} from "../../services/map/map.service";
import OlVector from 'ol/layer/Vector';
import {PickupRequest} from "../../data/pickup-request";
import {PickupRequestService} from "../../services/pickup-request/pickup-request.service";
import {Feature, Geolocation, Map, View} from 'ol';
import OSM from 'ol/source/OSM';
import {transform, transformExtent} from 'ol/proj';
import VectorSource from 'ol/source/Vector';
import {Point} from 'ol/geom';
import {Circle, Fill, Stroke, Style} from 'ol/style';

@Component({
  selector: 'app-admin-map',
  templateUrl: './admin-map.component.html',
  styleUrls: ['./admin-map.component.scss']
})
export class AdminMapComponent implements OnInit {

  private pickupRequestLayer: OlVector;

  constructor(private mapService: MapService,
              private pickupRequestService: PickupRequestService) { }

  ngOnInit() {
    this.mapService.map$.subscribe((map: Map) => {
      if(map) {
        this.initPickupRequestLayer(map);
      }
    });
  }

  public initPickupRequestLayer(map: Map) {
    const pickupRequests: Array<PickupRequest> = this.pickupRequestService.getPickupRequests();
    const requestPoints: Array<Feature> = pickupRequests.map(pickupRequest => {
      return this.createNewMapPoint(pickupRequest.latitude,pickupRequest.longitude);
    });

    this.pickupRequestLayer = new OlVector({
      source: new VectorSource({features: requestPoints})
    });
    map.addLayer(this.pickupRequestLayer);
  }

  private createNewMapPoint(latitude: number, longitude: number): Feature {
    const mapPoint: Feature = new Feature({
      geometry: new Point(transform([longitude, latitude], 'EPSG:4326', 'EPSG:3857'))
    });
    mapPoint.setStyle(
      new Style({
        image: new Circle({
          fill: new Fill({ color: [255,0,0,1] }),
          stroke: new Stroke({ color: [0,0,0,1] }),
          radius: 5
        })
      })
    );

    return mapPoint;
  }

}
