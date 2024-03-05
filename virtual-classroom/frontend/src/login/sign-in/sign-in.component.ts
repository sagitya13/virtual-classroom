import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SchoolService} from 'src/shared/services/school.service';
import { ReactiveFormsModule} from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  loginForm!: FormGroup ;
errorMessage: string = '';
  constructor(
    private formBuilder: FormBuilder,
    private schoolService: SchoolService,
    private router: Router
  ) { }
 
 

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      Name: ['', Validators.required],
      password: ['', Validators.required],
       Role: ['', Validators.required]
    });
  }
 
  onLogin() {
    if (this.loginForm.valid) {
      const formData = this.loginForm.value;
      this.schoolService.loginUser(formData).subscribe(
        response => this.handleResponse(response),
        error => this.handleError(error)
      );
    }
  }

  Signup(){
    this.router.navigate(['/register']);
  }


 
  handleResponse(response: any): void {
    // Handle successful login response
    console.log(response);
    this.router.navigate(['/dashboard']); // Adjust the route as necessary
  }
 
  handleError(error: HttpErrorResponse): void {
    // Handle error response
    console.error(error);
    this.errorMessage = 'Error occurred during login. Please try again.';
  }
}


