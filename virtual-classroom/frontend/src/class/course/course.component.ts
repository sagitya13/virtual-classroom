import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/shared/Model/course';
import { CoursesService } from 'src/shared/services/courses.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss'],
})
export class CourseComponent implements OnInit {
  courses: Course[];
  selectedCourse: Course;
  courseId: number;
  student: string;
  role: string;
  teacher: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private cs: CoursesService
  ) {
    console.log(this.route.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    const state = this.route.snapshot.paramMap.get('course');
    this.selectedCourse = history.state.course;
    console.log(this.selectedCourse);
    this.role = sessionStorage.getItem('role');
    this.student = sessionStorage.getItem('student');
    this.teacher = sessionStorage.getItem('teacher');
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

  openchat() {
    this.router.navigate(['chat', this.route.snapshot.paramMap.get('id')]);
  }
  material() {
    this.router.navigate(['material', this.route.snapshot.paramMap.get('id')]);
  }
  dashboard() {
    this.router.navigate(['dashboard']);
  }

  video() {
    this.router.navigate(['/video', this.route.snapshot.paramMap.get('id')]);
  }
  Quiz() {
    
    this.router.navigate(['/quiz']);
  }
}
