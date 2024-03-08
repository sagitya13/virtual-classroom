import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FormControl, FormGroup } from '@angular/forms';
import { login, signup } from '../Model/login';

import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root',
})
export class SchoolService { 
  constructor(private http: HttpClient, private router: Router) { 
  }

  loginUser(formData: login): Observable<login> {
    const loginurl = 'https://localhost:7233/api/Users/login';
    return this.http.post<login>(loginurl, formData, {
      headers: {
        'Content-Type': 'application/json',
      },
    });
  }

  signupUser(formData: signup): Observable<signup> {
    const signupurl = 'https://localhost:7233/api/Users/signup';
    return this.http.post<signup>(signupurl, formData,{
      headers: {
        'Content-Type': 'application/json',
      },
    });
  }
}
