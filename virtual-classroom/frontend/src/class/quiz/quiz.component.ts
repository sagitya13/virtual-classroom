import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { interval } from 'rxjs';
import { Question } from 'src/shared/Model/question';
import { QuestionListService } from 'src/shared/services/question-list.service';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss'],
})
export class QuizComponent implements OnInit {
  public name: string = '';
  public questionList: Question[] = [];
  public currentQuestion: Question | undefined;
  public points: number = 0;
  counter = 60;
  correctAnswer: number = 0;
  inCorrectAnswer: number = 0;
  progress: string = '0';
  isQuizCompleted: boolean = false;

  constructor(private qs: QuestionListService, private router: Router) {}

  ngOnInit(): void {
    this.getAllQuestions();
  }

  getAllQuestions(): void {
    this.qs.getQuestionList().subscribe((data: Question[]) => {
      this.questionList = data;
      this.currentQuestion = this.questionList[0];
    });
  }

  nextQuestion() {
    if (
      this.currentQuestion &&
      this.currentQuestion.id < this.questionList.length
    ) {
      const currentQuestionIndex = this.questionList.findIndex(
        (question) => question.id === this.currentQuestion?.id
      );
      if (currentQuestionIndex >= 0) {
        this.currentQuestion = this.questionList[currentQuestionIndex + 1];
        console.log(this.currentQuestion);
      }
    }
  }

  previousQuestion() {
    if (this.currentQuestion && this.currentQuestion.id > 1) {
      const currentQuestionIndex = this.questionList.findIndex(
        (question) => question.id === this.currentQuestion?.id
      );
      if (currentQuestionIndex >= 0) {
        this.currentQuestion = this.questionList[currentQuestionIndex - 1];
      }
    }
  }
 

  answer(currentQno: number, option: any) {
    if (currentQno === this.questionList.length) {
      this.isQuizCompleted = true;
    }
    if (option.correct) {
      this.points += 10;
      this.correctAnswer++;
      
    } else {
      setTimeout(() => {
        this.nextQuestion();
        this.inCorrectAnswer++;
        this.getProgressPercent();
      }, 1000);
      this.points = 10;
    }
  }



  resetQuiz() {
    this.getAllQuestions();
    this.points = 0;
    this.currentQuestion = this.questionList[0];
    this.progress = '0';
    this.correctAnswer = 0;
    this.inCorrectAnswer = 0;
    this.isQuizCompleted = false;
  }
 
  getProgressPercent() {
    if (this.currentQuestion) {
      this.progress = (
        (this.currentQuestion.id / this.questionList.length) *
        100
      ).toString();
    }
    return this.progress;
  }

   
  dashboard(){
    this.router.navigate(['dashboard']);
  }
}
