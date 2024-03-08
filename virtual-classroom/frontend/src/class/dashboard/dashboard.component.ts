import { Component, OnInit } from '@angular/core';
import { CoursesService } from 'src/shared/services/courses.service';
import { Course } from 'src/shared/Model/course';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

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

  constructor(
    private cs: CoursesService,
    private router: Router,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.courseForm = this.formBuilder.group({
      id: ['', Validators.required],
      name: ['', Validators.required],
      description: ['', Validators.required],
      type: ['', Validators.required],
      date: ['', Validators.required],
    });
    this.role = sessionStorage.getItem('role');
    this.student = sessionStorage.getItem('student');
    this.teacher = sessionStorage.getItem('teacher');
    this.loadCourses();
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
