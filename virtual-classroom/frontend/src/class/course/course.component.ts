import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/shared/Model/course';
import { CoursesService } from 'src/shared/services/courses.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit{

  courses:Course[];
  selectedCourse:Course;
  courseId:number;
  constructor(private route: ActivatedRoute,private router :Router,private cs:CoursesService) {
    console.log(this.route.snapshot.paramMap.get("id"));
    
  }

  ngOnInit(): void {
    const state = this.route.snapshot.paramMap.get('course');
    this.selectedCourse =history.state.course;
    console.log(this.selectedCourse);
  }
  // loadCourses(): void {
  //   this.cs.getCourses().subscribe(
  //     (response: Course[]) => {
  //       this.courses = response;
  //     },
  //     (error) => {
  //       console.log('Error loading courses:', error);
  //     }
  //   );
  // }
  openchat(){
    this.router.navigate(["chat",this.route.snapshot.paramMap.get("id")]);


  }

  showCourseDetails(courseId: number): void {
    this.cs.getCourseById(courseId).subscribe(
      (response: Course) => {
        this.selectedCourse = response;
      },
      (error) => {
        console.log('Error loading course details:', error);
      }
    );
  }
 
 



}
