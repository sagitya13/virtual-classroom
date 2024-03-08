import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SchoolService } from 'src/shared/services/school.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  signupForm!: FormGroup;
  errorMessage: string = '';

  constructor(
    private formBuilder: FormBuilder,
    private schoolService: SchoolService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.signupForm = this.formBuilder.group({
      id: ['', Validators.required],
      name: ['', Validators.required],
      
      password: ['', [Validators.required, Validators.minLength(6)]],
      role: ['', Validators.required],
    });
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

  handleResponse(response: any): void {
    console.log(response);
    this.router.navigate(['/dashboard']);
    if (this.signupForm && this.signupForm.valid) {
      sessionStorage.setItem('role', this.signupForm.get('Role')?.value);
      sessionStorage.setItem('student', this.signupForm.get('student')?.value);
      sessionStorage.setItem('teacher', this.signupForm.get('teacher')?.value);
    } else {
      this.errorMessage = 'Error occurred during login. Please try again.';
    }
  }

  handleError(error: HttpErrorResponse): void {
    console.error(error);
    this.errorMessage = 'An error occurred. Please try again later.';
  }
}
