import { Injectable } from '@angular/core';
import {BehaviorSubject, Observable} from "rxjs";
import {MapLocation} from "../../data/map-location";
import {Map} from 'ol';

@Injectable({
  providedIn: 'root'
})
export class MapService {

  private _currentLocation$: BehaviorSubject<MapLocation> = new BehaviorSubject<MapLocation>(null);
  public currentLocation$: Observable<MapLocation> = this._currentLocation$.asObservable();

  // TODO: think about how to redesign this archtecture
  private _map$: BehaviorSubject<Map> = new BehaviorSubject<Map>(null);
  public map$: Observable<Map> = this._map$.asObservable();

  constructor() { }

  public setCurrentLocation(needleLocation: MapLocation): void {
    this._currentLocation$.next(needleLocation);
  }

  public setMap(map: Map) {
    this._map$.next(map);
  }
}
