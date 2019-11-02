import { Component, OnInit } from '@angular/core';
import {Map, View} from 'ol';
import TileLayer from 'ol/layer/Tile';
import OSM from 'ol/source/OSM';
import {transform, transformExtent} from 'ol/proj';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent implements OnInit {

  public map: Map;

  constructor() { }

  ngOnInit(): void {
    this.initMap();
  }

  private initMap(): void {
    this.map = new Map({
      target: 'map',
      layers: [
        new TileLayer({
          source: new OSM()
        })
      ],
      view: new View({
        center: transform([-104.6189, 50.4452], 'EPSG:4326', 'EPSG:3857'),
        zoom: 11.5,
        extent: transformExtent([-104.4189, 50.3452, -104.8189, 50.5452], 'EPSG:4326', 'EPSG:3857')
      })
    });
  }

}
