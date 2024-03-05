import { Injectable } from '@angular/core';
import { HttpClient  } from '@angular/common/http';
import { Observable } from 'rxjs';  
import { Course  } from '../Model/course';
import {Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CoursesService {

  constructor(private http:HttpClient,private router:Router) { }

  getAllCourses(): Observable<Course[]> {
    const backendUrl = 'https://localhost:7233/api/course/course';
     return this.http.get<Course[]>(backendUrl);
  }
  createCourse(course: Course): Observable<Course> {
    
    const addcourse='https://localhost:7233/api/course/course';
    return this.http.post<Course>(addcourse,course);
  }
  
  deleteCourse(id: number): Observable<Course> {
    // console.log(id);
    
    const delete_course = `https://localhost:7233/api/course/courses/${id}`;
    return this.http.delete<Course>(delete_course);
  }

  // getCourses(): Observable<Course[]> {
  //   return this.http.get<Course[]>(this.baseUrl);
  // }

  getCourseById(courseId: number): Observable<Course> {
    const courseid = 'https://localhost:7233/api/course/courses/${id}';
    return this.http.get<Course>(courseid);
  }

}

