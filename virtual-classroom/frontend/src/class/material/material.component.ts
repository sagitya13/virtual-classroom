import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators,FormBuilder } from '@angular/forms';
import { Material } from 'src/shared/Model/course';
import { MaterialService } from 'src/shared/services/material.service';

@Component({
  selector: 'app-material',
  templateUrl: './material.component.html',
  styleUrls: ['./material.component.scss']
})
export class MaterialComponent   implements OnInit {
 materialForm: FormGroup;
 materials: any[] = [];
 constructor(private ms: MaterialService) { }
 ngOnInit(): void {
    this.materialForm = new FormGroup({
      fileName: new FormControl('', Validators.required),
      filePath: new FormControl('', Validators.required)
    });
 }

 handleFileInput(event: any): void {
    const file = event.target.files[0];
    const reader = new FileReader();

    reader.onload = () => {
      const base64String = reader.result as string;
      this.materialForm.get('filePath').setValue(base64String);
    };

    reader.readAsDataURL(file);
 }

 fetchMaterials(courseId:number): void {
  this.ms.getMaterials(courseId).subscribe(
    (materials: any[]) => {
      this.materials = materials;
    },
    error => {
      console.error('Error fetching materials:', error);
    }
  );
}

getFileUrl(filePath: string): string {
  // Assuming the filePath is a URL or a path that can be directly used in an <a> tag's href
  return filePath;
}
 uploadMaterial(): void {
    if (this.materialForm.valid) {
      const formData = this.materialForm.value;
      const payload = {
        fileName: formData.fileName,
        fileContent: formData.filePath
      };

      console.log(payload);
      // Replace this with your actual API call
      // this.yourService.uploadMaterial(payload).subscribe(response => {
      //   // Handle the response
      // });
    }
 }
}

    //materialForm: FormGroup;
   

//     constructor(private http: HttpClient,private ms: MaterialService){
//       this.materialForm = new FormGroup({
//         fileName: new FormControl('', Validators.required),
//         filePath: new FormControl('', Validators.required),
//       });
//     }
  
//     handleFileInput(event: any) {
//       if (event.target.files && event.target.files.length) {
//         this.materialForm.patchValue({
//           filePath: event.target.files[0]
//         });
//       }
//     }
  
//     uploadMaterial() {
//       if (this.materialForm.valid) {
//         const { fileName, filePath } = this.materialForm.value;
//         this.ms.uploadFile(filePath).subscribe(response => {
//           if (response.success) {
//             // File uploaded successfully, save the file path in the SQL database
//             const filePathString = response.filePath.toString(); // Convert the file path to string
//             // Call your Backend API to save the filePathString in the Database
//           }
//         });
//       }
   
//   }
// }

  
  //   constructor(private http: HttpClient, private formBuilder: FormBuilder,private ms:MaterialService) {
       
  //   }
  
  //   ngOnInit():void {
  //     this.materialForm = this.formBuilder.group({
  //       name: ['', Validators.required],
  //       file: [null, Validators.required]
  //     });
     
  //   }
  
  //   uploadMaterial() {
  //     const formData = new FormData();
  //     formData.append('name', this.materialForm.get('name').value);
  //     formData.append('file', this.selectedFile);
  
  //     this.http.post('/api/materials/upload', formData).subscribe(
  //       (response: any) => {
  //         this.loadMaterials();
  //       },
  //       (error) => {
  //         console.log('Error uploading material:', error);
  //       }
  //     );
  //   }
  
  //   handleFileInput(event: any) {
  //     this.selectedFile = event.target.files[0];
  
  //     const reader = new FileReader();
  //     reader.onload = (e: any) => {
  //       const base64String = e.target.result.split(',')[1]; // Extract base64 string from the data URL
  //       this.materialForm.get('file').setValue(base64String);
  //     };
  //     reader.readAsDataURL(this.selectedFile);
  //   }
  //   getMaterialById(id: number) {
  //     this.ms.getMaterialBycourseId(courseId).subscribe(
  //       (response: any) => {
  //         this.selectedMaterial = response;
  //       },
  //       (error) => {
  //         console.log('Error loading material:', error);
  //       }
  //     );
  //   }
    
  
  //   getFileUrl(filePath: string): string {
  //     return `/api/materials/file?path=${encodeURIComponent(filePath)}`;
  //   }
  // }

 

