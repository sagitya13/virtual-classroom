import { Component, OnInit } from '@angular/core';
import { interval } from 'rxjs';
import { Question } from 'src/shared/Model/course';
 import { QuestionListService }  from 'src/shared/services/question-list.service';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss']
})
export class QuizComponent implements OnInit {
  public name: string = "";
  public questionList: Question[] = [];
  public currentQuestion: Question | undefined;
  public points: number = 0;
  counter = 60;
  correctAnswer: number = 0;
  inCorrectAnswer: number = 0;
  interval$: any;
  progress: string = "0";
  isQuizCompleted: boolean = false;

  constructor(private qs: QuestionListService) {}

  ngOnInit(): void {
    // Rest of the code
    this.getAllQuestions();
  }

  getAllQuestions(): void {
    this.qs.getQuestionList().subscribe((data: Question[]) => {
      this.questionList = data;
      this.currentQuestion = this.questionList[0];
      
    });
  }

  nextQuestion() {
    if (this.currentQuestion && this.currentQuestion.id < this.questionList.length) {
      const currentQuestionIndex = this.questionList.findIndex(question => question.id === this.currentQuestion?.id);
      if (currentQuestionIndex >= 0) {
        this.currentQuestion = this.questionList[currentQuestionIndex + 1];
        console.log(this.currentQuestion) 
      }
    }
  }

  previousQuestion() {
    if (this.currentQuestion && this.currentQuestion.id > 1) {
      const currentQuestionIndex = this.questionList.findIndex(question => question.id === this.currentQuestion?.id);
      if (currentQuestionIndex >= 0) {
        this.currentQuestion = this.questionList[currentQuestionIndex - 1];
      }
    }
  }

  answer(currentQno: number, option: any) {
    if (currentQno === this.questionList.length) {
      this.isQuizCompleted = true;
      this.stopCounter();
    }
    if (option.correct) {
      this.points += 10;
      this.correctAnswer++;
      setTimeout(() => {
        this.nextQuestion();
        this.resetCounter();
        this.getProgressPercent();
      }, 1000);
    } else {
      setTimeout(() => {
        this.nextQuestion();
        this.inCorrectAnswer++;
        this.resetCounter();
        this.getProgressPercent();
      }, 1000);
      this.points = 10;
    }
  }

  startCounter() {
    this.interval$ = interval(1000).subscribe(val => {
      this.counter--;
      if (this.counter === 0) {
        this.nextQuestion();
        this.counter = 60;
        this.points -= 10;
      }
    });
    setTimeout(() => {
      this.interval$.unsubscribe();
    }, 600000);
  }

  stopCounter() {
    this.interval$.unsubscribe();
    this.counter = 0;
  }

  resetCounter() {
    this.stopCounter();
    this.counter = 60;
    this.startCounter();
  }

  resetQuiz() {
    this.resetCounter();
    this.getAllQuestions();
    this.points = 0;
    this.counter = 60;
    this.currentQuestion = this.questionList[0];
    this.progress = "0";
    this.correctAnswer = 0;
    this.inCorrectAnswer = 0;
    this.isQuizCompleted = false;
  }

  getProgressPercent() {
    if (this.currentQuestion) {
      this.progress = ((this.currentQuestion.id / this.questionList.length) * 100).toString();
    }
    return this.progress;
  }
}