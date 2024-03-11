import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from 'src/login/register/register.component';
import { DashboardComponent } from '../class/dashboard/dashboard.component';
import { CourseComponent } from 'src/class/course/course.component';
import { ChatComponent } from 'src/class/chat/chat.component';
import { SignInComponent } from 'src/login/sign-in/sign-in.component';
import { QuizComponent } from 'src/class/quiz/quiz.component';
import { MaterialComponent } from 'src/class/material/material.component';
import { AuthsecGuard } from './security/authsec.guard';
import { VideoComponent } from 'src/class/video/video.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'sign-in',
    pathMatch: 'full',
  },
  {
    path: 'quiz',
    component: QuizComponent,canActivate:[AuthsecGuard ]
  },

  {
    path: 'video/:id',
    component: VideoComponent,canActivate:[AuthsecGuard ]
  },
  { path: 'register', component: RegisterComponent },
  {
    path: 'dashboard',
    component: DashboardComponent,canActivate:[AuthsecGuard ]
  },
  {
    path: 'course/:id',
    component: CourseComponent, canActivate:[AuthsecGuard ]
  },
  {
    path: 'chat',
    component: ChatComponent, canActivate:[AuthsecGuard ]
  },
  {
    path: 'course',
    component: CourseComponent, canActivate:[AuthsecGuard ]
  },

  { path: 'chat/:CourseId', component: ChatComponent,canActivate:[AuthsecGuard ] },
  { path: 'material/:id', component: MaterialComponent,canActivate:[AuthsecGuard ] },

  {
    path: 'sign-in',
    loadChildren: () =>
      import('../login/login.module').then((m) => m.LoginModule),
  },
  {
    path: 'register',
    loadChildren: () =>
      import('../login/login.module').then((m) => m.LoginModule),
  },
  {
    path: 'signout',
    component: SignInComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
