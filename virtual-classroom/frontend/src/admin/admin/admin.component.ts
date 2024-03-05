import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Course } from 'src/shared/Model/course';
import { CoursesService } from 'src/shared/services/courses.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
    courses: Course[]=[];
    courseForm!: FormGroup; 
    showForm = false;

  
    constructor(private cs: CoursesService, private router: Router, private formBuilder: FormBuilder) { }
  
    ngOnInit(): void {
      this.courseForm = this.formBuilder.group({
        id:['',Validators.required],
        name: ['', Validators.required],
        description: ['', Validators.required],
        type: ['', Validators.required],
        date: ['', Validators.required]
      });
      this.loadCourses();
    }
 
  
  toggleForm() {
    this.showForm = !this.showForm; // Toggle the visibility of the form
 }
 
 

 loadCourses() {
   this.cs.getAllCourses().subscribe(data => {
     this.courses=data;
   });
 }
 
 deleteCourse(id: number): void {
  this.cs.deleteCourse(id).subscribe(
    () => {
      this.courses = this.courses.filter(course => course.id !== id);
    },
    error => {
      console.error('Error deleting course:', error);
    }
  );
}

  

   
 
 createCourse(): void {
   if (this.courseForm.valid) {
    // const courseData= this.courseForm.value as Course;
     this.cs.createCourse(this.courseForm.value).subscribe(() => {
       this.loadCourses();
       this.courseForm.reset(); 
     });
   }
 }

 more_details(courseid:number,course:Course){
  this.router.navigateByUrl("/course/"+ courseid, { state: { course } })


 }
}


