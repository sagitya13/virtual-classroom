import { Time } from "@angular/common";

export interface Course {
    id: number;
    name: string;
    description: string;
    teacher_id:number;
    material_id:number;
    start_time:string;
    student_id:number;
    type: string;
    date: Date;
    time :Time;
  }
  

  export interface Material {
    Id: number;
    fileName: string;
    filePath: string;
    courseId: number;
    // Add more properties as per your material data structure
  }
   
  export interface Question {
    id: number;
    question: string;
    opt1: string;
    opt2: string;
    opt3: string;
    opt4: string;
    answer: string;
  }

  export interface chats{
    UserName:string;
   
  MessageContent :string;
  CourseId: number;
  }