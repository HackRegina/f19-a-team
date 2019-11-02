import { Injectable } from '@angular/core';
import {BehaviorSubject, Observable} from "rxjs";
import {MapLocation} from "../../data/map-location";

@Injectable({
  providedIn: 'root'
})
export class MapService {

  private _currentLocation$: BehaviorSubject<MapLocation> = new BehaviorSubject<MapLocation>(null);
  public currentLocation: Observable<MapLocation> = this._currentLocation$.asObservable();

  constructor() { }

  public setCurrentLocation(needleLocation: MapLocation): void {
    this._currentLocation$.next(needleLocation);
  }
}
