import { Injectable } from '@angular/core';
import { CanActivate, CanLoad } from '@angular/router';
import { Observable, of } from 'rxjs';

@Injectable()
export class AuthGuard implements CanLoad, CanActivate {
  constructor(
  ) { }

  canLoad(): Observable<boolean> | Promise<boolean> | boolean {
    return true;
  }

  canActivate(): Observable<boolean> {
    return of(true);
  }
}