import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthGaurdService {
  isAuthenticated = false;

  constructor() {
    if(sessionStorage.getItem('role')==='student'|| sessionStorage.getItem('role')==='admin'|| sessionStorage.getItem('role')==='teacher')
    this.isAuthenticated =true;
  }

  signin(): void {
    this.isAuthenticated = true;
  }

  logout(): void {
    this.isAuthenticated = false;
  }

  setAuthenticated(isAuthenticated: boolean): void {
    this.isAuthenticated = isAuthenticated;
  }
}
