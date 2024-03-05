 
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, map } from 'rxjs';
import { FormControl, FormGroup } from '@angular/forms';
import { login, signup } from '../Model/login_Interface';
import {  Question } from '../Model/course';
import {Router} from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class SchoolService {

  student: login[] = [];
 detailsForms: FormGroup;
  constructor(private http:HttpClient,private router:Router) {
    this.detailsForms = new FormGroup({
      id: new FormControl(''),
   });
  }


  // loginUser(Name: string, password: string): Observable<any> {
  //   const loginurl = 'https://localhost:7233/api/Users/users/signin';
  //   return this.http.post(loginurl, { Name, password });
  // }
  loginUser(formData: login): Observable<login> {
    const loginurl = 'https://localhost:7233/api/Users/login';
    return this.http.post<login>(loginurl, formData);
  }

  signupUser(formData:signup):Observable<signup>{
    const signupurl='https://localhost:7233/api/Users/users/signup';
    return this.http.post<signup>(signupurl,formData);
  }

  sendMessage(UserName: string, MessageContent: string, CourseId :number): Observable<any> {
    const messageurl='https://localhost:7233/api/Messages/CreateMessage';
    return this.http.post<any>(messageurl, { UserName, MessageContent,CourseId });
 
}
getMessagesByCourseId(CourseId: number): Observable<any> {
  const url = `https://localhost:7233/api/Messages/${CourseId}`;
  return this.http.get<any>(url);
}

  
  
}