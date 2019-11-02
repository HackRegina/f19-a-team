import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {User} from "../data/user";
import {BehaviorSubject, Observable} from "rxjs";
import {map} from "rxjs/operators";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private currentUserSubject: BehaviorSubject<User> = new BehaviorSubject<User>(null);
  public currentUser: Observable<User> = this.currentUserSubject.asObservable();

  constructor(private httpClient: HttpClient) { }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  login(username: string, password: string) {
    return this.httpClient.post<any>(`${environment.baseUrl}/Users/auth`, { username, password })
      .pipe(map(user => {
        if (user && user.token) {
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject.next(user);
        }

        return user;
      }));
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
