import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SchoolService } from 'src/shared/services/school.service'; // Make sure this path is correct
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  signupForm!: FormGroup;
  errorMessage: string = ''; // Initialize errorMessage variable

  constructor(
    private formBuilder: FormBuilder,
    private schoolService: SchoolService, // Inject SchoolService
    private router: Router
  ) { }

  ngOnInit(): void {
    this.signupForm = this.formBuilder.group({
      id: ['', Validators.required],
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      role: ['', Validators.required]
    });
  }

  onSignup() {
    if (this.signupForm.valid) {
      const formData = this.signupForm.value;
      this.schoolService.signupUser(formData).subscribe(
        response => this.handleResponse(response),
        error => this.handleError(error)
      );
    }
  }

  handleResponse(response: any) :void{
          // Redirect user to dashboard
      this.router.navigate(['dashboard']);
    } 
  

  handleError(error: HttpErrorResponse):void {
    console.error(error);
    this.errorMessage = 'An error occurred. Please try again later.';
  }
}


