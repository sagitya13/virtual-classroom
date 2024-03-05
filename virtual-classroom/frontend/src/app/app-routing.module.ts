import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'; 
import { RegisterComponent } from 'src/login/register/register.component';
import { DashboardComponent } from '../class/dashboard/dashboard.component';  
import { CourseComponent } from 'src/class/course/course.component';
import { ChatComponent } from 'src/class/chat/chat.component';
import { SignInComponent } from 'src/login/sign-in/sign-in.component';
import { QuizComponent } from 'src/class/quiz/quiz.component';
import { MaterialComponent } from 'src/class/material/material.component';

import { VideoComponent } from 'src/class/video/video.component';

const routes: Routes = [
  {
    path:'',redirectTo:'sign-in', pathMatch:'full'
  },{
    path:'quiz-home', component: QuizComponent
  },

  {
    path:'video', component: VideoComponent
  },
  { path: 'register', component: RegisterComponent },
  {
    path:'dashboard',
    component:DashboardComponent
  },
  {
    path: 'course/:id',
    component: CourseComponent,
    
  },
    
  { path: 'chat/:CourseId', component: ChatComponent },
  { path: 'material', component: MaterialComponent },
  
 
  {
    path:'sign-in', loadChildren: ()=> import('../login/login.module').then((m)=> m.LoginModule),
  },
  {
    path:'register', loadChildren:()=> import('../login/login.module').then((m)=> m.LoginModule),
  },
  {
    path:'signout',
    component:SignInComponent
  }
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
