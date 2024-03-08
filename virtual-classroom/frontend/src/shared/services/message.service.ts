import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FormControl, FormGroup } from '@angular/forms';

import { Router } from '@angular/router';
import { Messages } from '../Model/message'; 
@Injectable({
  providedIn: 'root',
})
export class MessageService {
  detailsForms: FormGroup;

  constructor(private http: HttpClient, private router: Router) {
    this.detailsForms = new FormGroup({
      id: new FormControl(''),
    });
  }

  sendMessage(
    UserName: string,
    MessageContent: string,
    CourseId: number
  ): Observable<Messages> {
    const messageurl = 'https://localhost:7233/api/Messages/CreateMessage';
    return this.http.post<Messages>(messageurl, {
      UserName,
      MessageContent,
      CourseId,
    });
  }
  getMessagesByCourseId(CourseId: number): Observable<Messages[]> {
    const url = `https://localhost:7233/api/Messages/${CourseId}`;
    return this.http.get<Messages[]>(url);
  }
}
