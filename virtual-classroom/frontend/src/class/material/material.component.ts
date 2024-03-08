import {  HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl,  FormGroup, Validators} from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Material } from 'src/shared/Model/material';
import { MaterialService } from 'src/shared/services/material.service';

@Component({
  selector: 'app-material',
  templateUrl: './material.component.html',
  styleUrls: ['./material.component.scss'],
})
export class MaterialComponent implements OnInit {
  materialForm: FormGroup;
  materials: Material[];
  courseId: number;
  base64Image: string;
  role: string;

  constructor(
    private ms: MaterialService,
    private ar: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.materialForm = new FormGroup({
      fileName: new FormControl('', Validators.required),
      filePath: new FormControl('', Validators.required),
      courseId: new FormControl('', Validators.required),
    });
    this.role = sessionStorage.getItem('role');

    this.ar.paramMap.subscribe((map) => {
      this.courseId = +map.get('id');
    });

    this.fetchMaterials(this.courseId);
  }

  handleFileInput(event: any): void {
    const file = event.target.files[0];
    const reader = new FileReader();

    reader.onload = () => {
      const base64String = reader.result as string;
      this.materialForm.get('filePath').setValue(base64String);
      this.base64Image = base64String;
    };

    reader.readAsDataURL(file);
  }

  fetchMaterials(courseId: number): void {
    this.ms.getMaterials(courseId).subscribe({
      next: (response) => {
        console.log(response);
        this.materials = response;
      },
      error: (error: HttpErrorResponse) => {
        console.log(error);
      },
    });
  }

  getFileUrl(filePath: string): string {
    return filePath;
  }

  uploadMaterial(): void {
    if (this.materialForm.valid) {
      const formData = this.materialForm.value;
      console.log('File data', formData);

      const payload = {
        fileName: formData.fileName,
        filePath: this.base64Image,
        courseId: formData.courseId,
      };
 
      this.ms.uploadMaterial(this.courseId, payload).subscribe(
        (response: { message: string }) => {
          console.log('Upload successful:', response.message);

          this.materialForm.reset();
        },
        (error) => {
          console.error('Error uploading material:', error);
        }
      );
    }
  }
  dashboard(){
    this.router.navigate(['dashboard']);
  }
  
   
}
