import { Injectable } from '@angular/core';
import { HttpClient  } from '@angular/common/http';
import { Observable } from 'rxjs';  
import { Question  } from '../Model/question';
import {Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class QuestionListService {

  constructor(private http:HttpClient,private router:Router) { }

  getQuestionList()  : Observable<Question[]>{
    const apiUrl = 'https://localhost:7233/api/Questions';
    return this.http.get<Question[]>(apiUrl);
  }
}
