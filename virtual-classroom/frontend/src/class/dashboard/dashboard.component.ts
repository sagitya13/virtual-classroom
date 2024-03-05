import { Component, OnInit } from '@angular/core';
import { CoursesService } from 'src/shared/services/courses.service';
import { Course } from 'src/shared/Model/course';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
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
  loadCourses() {
    this.cs.getAllCourses().subscribe(data => {
      this.courses=data;
    });
  }
  more_details(courseid:number,course:Course){
    this.router.navigateByUrl("/course/"+ courseid, { state: { course } })
  
  
   }
}