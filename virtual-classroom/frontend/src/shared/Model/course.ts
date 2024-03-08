import { Time } from '@angular/common';

export interface Course {
  id: number;
  name: string;
  description: string;
  teacher_id: number;
  material_id: number;
  start_time: string;
  student_id: number;
  type: string;
  date: Date;
  time: Time;
}
