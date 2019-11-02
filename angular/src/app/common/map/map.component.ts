import {Component, OnInit} from '@angular/core';
import {Feature, Geolocation, Map, View} from 'ol';
import TileLayer from 'ol/layer/Tile';
import OSM from 'ol/source/OSM';
import {transform, transformExtent} from 'ol/proj';
import VectorSource from 'ol/source/Vector';
import OlVector from 'ol/layer/Vector';
import {Point} from 'ol/geom';
import {Circle as CircleStyle, Fill, Stroke, Style} from 'ol/style';
import {MapService} from "../../services/map/map.service";
import {MapLocation} from "../../data/map-location";

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent implements OnInit {

  public map: Map;

  private view: View;
  private geolocation: Geolocation;
  private currentLocationMarker: Feature;
  private currentPositionLayer: OlVector;

  private geoLocationFirstFound: boolean;

  constructor(private mapService: MapService) { }

  ngOnInit(): void {
    this.initMap();
    this.initGeolocation();
  }

  private initMap(): void {
    this.view = new View({
      center: transform([-104.6189, 50.4452], 'EPSG:4326', 'EPSG:3857'),
      zoom: 11.5,
      extent: transformExtent([-104.4189, 50.3452, -104.8189, 50.5452], 'EPSG:4326', 'EPSG:3857')
    });

    this.map = new Map({
      target: 'map',
      layers: [
        new TileLayer({
          source: new OSM()
        })
      ],
      view: this.view
    });

    this.currentLocationMarker = new Feature({geometry: null});
    this.currentLocationMarker.setStyle(new Style({
      image: new CircleStyle({
        radius: 6,
        fill: new Fill({color: '#3399CC'}),
        stroke: new Stroke({ color: '#fff', width: 2 })
      })
    }));

    this.currentPositionLayer = new OlVector({
      map: this.map,
      source: new VectorSource({
        features: [this.currentLocationMarker]
      })
    });

    this.mapService.setMap(this.map);
  }

  private initGeolocation() {
    this.geolocation = new Geolocation({
      trackingOptions: {
        enableHighAccuracy: true
      },
      projection: 'EPSG:4326'
    });

    this.geolocation.setTracking(true);

    this.geolocation.on('change:position', () => {
      const mapLocation: MapLocation = this.geolocation.getPosition() ?
        {longitude: this.geolocation.getPosition()[0], latitude: this.geolocation.getPosition()[1], } as MapLocation
        : null;
      this.mapService.setCurrentLocation(mapLocation);
      const coordinates = transform(this.geolocation.getPosition(), 'EPSG:4326', 'EPSG:3857');

      this.currentLocationMarker.setGeometry(coordinates ? new Point(coordinates) : null);
      if(!this.geoLocationFirstFound) {
        this.map.getView().animate({
          center: coordinates,
          duration: 2000,
          zoom:12
        });
        this.geoLocationFirstFound = true;
      }

    });
  }

}
