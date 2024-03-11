


import { Injectable } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthGaurdService } from 'src/shared/services/auth-gaurd.service';
 
@Injectable({
 providedIn: 'root'
})
export class AuthsecGuard implements CanActivate {
 
 constructor(private as:AuthGaurdService, private router: Router) {}
 
 canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if (this.as.isAuthenticated) {
      return true;
    } else {
      // Redirect to login page if not authenticated
      this.router.navigate(['/sign-in']);
      return false;
    }
 }
}
 