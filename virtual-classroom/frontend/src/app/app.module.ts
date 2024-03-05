import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { SignInComponent } from 'src/login/sign-in/sign-in.component';
import { CourseComponent } from '../class/course/course.component';
import { RegisterComponent } from '../login/register/register.component';
import { DashboardComponent } from '../class/dashboard/dashboard.component';
import { QuizComponent } from 'src/class/quiz/quiz.component';
import { MaterialComponent } from 'src/class/material/material.component';
import { ChatComponent } from 'src/class/chat/chat.component'; 
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { VideoComponent } from 'src/class/video/video.component';
import { WhiteBoardComponent } from 'src/class/white-board/white-board.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatPaginatorModule } from '@angular/material/paginator';
import { HomeComponent } from '../class/home/home.component';
@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
     CourseComponent, 
     RegisterComponent, 
     DashboardComponent, 
     QuizComponent,
     MaterialComponent,
     ChatComponent, 
     WhiteBoardComponent,
     VideoComponent,
     HomeComponent
     
      
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    FormsModule,
    MatSnackBarModule,
    MatPaginatorModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
