import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Material } from '../Model/material';

@Injectable({
  providedIn: 'root',
})
export class MaterialService {
  constructor(private http: HttpClient, private router: Router) {}

  getMaterials(courseId: number): Observable<Material[]> {
    const mat = `https://localhost:7233/api/Materials/${courseId}`;

    return this.http.get<Material[]>(mat);
  }

  uploadMaterial(courseId: number, payload: any): Observable<object> {
    const apiUrl = 'https://localhost:7233/api/Materials';
    return this.http.post<object>(apiUrl, payload);
  }
}
