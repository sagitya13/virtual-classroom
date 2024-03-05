import { Injectable } from '@angular/core';
import {Router} from '@angular/router';
import { Observable } from 'rxjs';  
import { HttpClient  } from '@angular/common/http';
import { Material } from '../Model/course';

@Injectable({
  providedIn: 'root'
})
export class MaterialService {

  constructor(private http:HttpClient,private router:Router) { }
 
    
  

 getMaterials(courseId:number): Observable<any[]> {
  const mat = `https://localhost:7233/api/Materials/${courseId}`;

    return this.http.get<any[]>(mat);
 }
  
   
  
   uploadMaterial(payload: any): Observable<any> {
    const apiUrl = 'https://localhost:7233/api/Materials'; 
      return this.http.post<any>(apiUrl,payload);
   }
  }
  
      // getMaterialsById(id): Observable<Material[]> {
      //   const Url = 'https://localhost:7233/api/Materials';
      //   return this.http.get<Material[]>(Url);
      // }
    
      // uploadFile(formData: FormData): Observable<any> {
      //   const Url = 'https://localhost:7233/api/Materials';


      //   return this.http.post<any>(Url, formData);
      // }
    
      // getMaterialFileUrl(filePath: string): string {
      //   return `${this.baseUrl}/file?path=${encodeURIComponent(filePath)}`;
      // }
