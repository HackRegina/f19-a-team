import { Component, OnInit } from '@angular/core';
import {MapService} from "../../services/map.service";
import OlVector from 'ol/layer/Vector';
import {PickupRequest} from "../../data/pickup-request";
import {PickupRequestService} from "../../services/pickup-request.service";
import {Feature, Geolocation, Map, View} from 'ol';
import OSM from 'ol/source/OSM';
import {transform, transformExtent} from 'ol/proj';
import VectorSource from 'ol/source/Vector';
import {Point} from 'ol/geom';
import {Circle, Fill, Stroke, Style} from 'ol/style';
import {Router} from "@angular/router";

@Component({
  selector: 'app-admin-map',
  templateUrl: './admin-map.component.html',
  styleUrls: ['./admin-map.component.scss']
})
export class AdminMapComponent implements OnInit {

  private pickupRequestLayer: OlVector;
  private map: Map;

  constructor(private mapService: MapService,
              private pickupRequestService: PickupRequestService,
              private router: Router) { }

  ngOnInit() {
    this.mapService.map$.subscribe((map: Map) => {
      if(map) {
        this.map = map;
        this.map.on("click", event => {
          map.forEachFeatureAtPixel(event.pixel, (feature, layer) => {
            this.router.navigate(['/admin/needle-pickup']);
          })
        });
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
    map.on("moveend", event => {
      this.pickupRequestLayer.getSource().getFeatures().forEach((feature) => {
        const radius = this.valueRange(18 - map.getView().getResolution(), 5, 15);
        feature.getStyle().getImage().setRadius(radius)
      });

      this.pickupRequestLayer.getSource().changed();
    });
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

  private valueRange(value: number, min: number, max: number) {
    if(value < min) {
      return min;
    } else if (value > max) {
      return max;
    }
    return value;
  }

}
