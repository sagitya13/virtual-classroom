import { Component, OnInit } from '@angular/core';
import { CoursesService } from 'src/shared/services/courses.service';
import { Course } from 'src/shared/Model/course';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
 
import { ReactiveFormsModule } from '@angular/forms';
import { SchoolService } from 'src/shared/services/school.service';

import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  courses: Course[] = [];
  courseForm!: FormGroup;
  showForm = false;
  role: string;
  student: string;
  teacher:string;
  signupForm!: FormGroup;
  errorMessage: string = '';
  public showSignupForm= false;

  constructor(
    private cs: CoursesService,
    private router: Router,
    private schoolService: SchoolService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.courseForm = this.formBuilder.group({
      id: ['', Validators.required],
      name: ['', Validators.required],
      description: ['', Validators.required],
      type: ['', Validators.required],
      date: ['', Validators.required],});

      this.signupForm = this.formBuilder.group({
        id: ['', Validators.required],
        name: ['', Validators.required],
        
        password: ['', [Validators.required, Validators.minLength(6)]],
        role: ['', Validators.required],
      });
    
    this.role = sessionStorage.getItem('role');
    this.student = sessionStorage.getItem('student');
    this.teacher = sessionStorage.getItem('teacher');
    this.loadCourses();
  }
  toggleSignupForm() {
    this.showSignupForm = !this.showSignupForm;
  }

  onSignup() {
    if (this.signupForm.valid) {
      const formData = this.signupForm.value;
      this.schoolService.signupUser(formData).subscribe(
        (response) => this.handleResponse(response),
        (error) => this.handleError(error)
      );
    }
  }
  dashboard(){
    this.router.navigate(['/register']);
  }

  handleResponse(response: any): void {
    console.log(response);
    this.router.navigate(['/dashboard']);
    if (this.signupForm && this.signupForm.valid) { 
      sessionStorage.setItem('student', this.signupForm.get('student')?.value); 
    } else {
      this.errorMessage = 'Error occurred during login. Please try again.';
    }
  }

  handleError(error: HttpErrorResponse): void {
    console.error(error);
    this.errorMessage = 'An error occurred. Please try again later.';
  }


  loadCourses() {
    this.cs.getAllCourses().subscribe((data) => {
      this.courses = data;
    });
  }
  more_details(courseid: number, course: Course) {
    this.router.navigateByUrl('/course/' + courseid, { state: { course } });
  }

  toggleForm() {
    this.showForm = !this.showForm;
  }
 
  deleteCourse(id: number): void {
    this.cs.deleteCourse(id).subscribe(
      () => {
        this.courses = this.courses.filter((course) => course.id !== id);
      },
      (error) => {
        console.error('Error deleting course:', error);
      }
    );
  }

  createCourse(): void {
    if (this.courseForm.valid) {
      this.cs.createCourse(this.courseForm.value).subscribe(() => {
        this.loadCourses();
        this.courseForm.reset();
      });
    }
  }
 
  signout() {
    this.router.navigate(['/sign-in']);
  }
}
