import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { HomeComponent } from './components/home/home.component';
import { authGuard } from './services/auth.guard';
import { MyCaseComponent } from './components/case/my-case/my-case-new/case-new.component';
import { MyCaseListComponent } from './components/case/case-list/case-list.component';
import { AssignedCaseNewComponent } from './components/assigned-case/assigned-case-new/assigne-case-new.component';
import { CaseStatusListComponent } from './components/case-status-list/case-status-list.component';
import { UserAssignedCaseListComponent } from './components/user-assigned-case-list/user-assigned-case-list.component';
import { AssignedCaseAnswerComponent } from './components/assigned-case-answer/assigned-case-answer.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path:'home',
    component: HomeComponent,
    canActivate: [authGuard]
  },
  {
    path: 'mycase',
    component: MyCaseComponent,
    canActivate: [authGuard]
  },
  {
    path: 'mycaselist',
    component: MyCaseListComponent,
    canActivate: [authGuard]
  },
  {
    path: 'mycaselist/caseStatus/getDetail/:id',
    component: CaseStatusListComponent,
    canActivate: [authGuard]
  },
  {
    path: 'newAssignedCase',
    component: AssignedCaseNewComponent,
    canActivate: [authGuard]
  },
  {
    path: 'assignedCaseStatusList',
    component: CaseStatusListComponent,
    canActivate: [authGuard]
  },
  {
    path: 'myAssignedList',
    component: UserAssignedCaseListComponent,
    canActivate: [authGuard]
  },
  {
    path: 'myAssignedList/assignedCase/answer/:id',
    component: AssignedCaseAnswerComponent,
    canActivate: [authGuard]
  },
  {
    path: '**',
    component: PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
