import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './components/register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from './services/auth.service';
import { LoginComponent } from './components/login/login.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { HomeComponent } from './components/home/home.component';
import { MyCaseComponent } from './components/case/my-case/my-case-new/case-new.component';
import { MyCaseListComponent } from './components/case/case-list/case-list.component';
import { AssignedCaseNewComponent } from './components/assigned-case/assigned-case-new/assigne-case-new.component';
import { CaseStatusListComponent } from './components/case-status-list/case-status-list.component';
import { UserAssignedCaseListComponent } from './components/user-assigned-case-list/user-assigned-case-list.component';
import { AssignedCaseAnswerComponent } from './components/assigned-case-answer/assigned-case-answer.component';
import { SearchPipe } from './search.pipe';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    PageNotFoundComponent,
    HomeComponent,
    MyCaseComponent,
    MyCaseListComponent,
    AssignedCaseNewComponent,
    CaseStatusListComponent,
    UserAssignedCaseListComponent,
    AssignedCaseAnswerComponent,
    SearchPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
