import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserInfo } from '../models/user-model.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  router: any
  constructor(private http: HttpClient,private route: Router) {
    this.router = route
   }

  baseServerUrl = "https://localhost:44337/api/User/";

  registerUser(user: Array<String>){
    return this.http.post(this.baseServerUrl + "CreateUser", 
    {
       FirstName: user[0],
       LastName: user[1],
       Phone: user[2],
       Email: user[3],
       Password: user[4]
    },
    {
      responseType: 'text',
    });
  }

  getUserInfos(): Observable<UserInfo[]>{
    return this.http.get<UserInfo[]>(this.baseServerUrl + "GetUsersInfo");
  }

  loginUser(loginInfo: Array<String>){
    return this.http.post(this.baseServerUrl + "LoginUser", 
    {
       Email: loginInfo[0],
       Password: loginInfo[1]
    },
    {
      responseType: 'text',
    });
  }

  getUserInfo(email: string,password: string): Observable<UserInfo>{
    return this.http.get<UserInfo>(
      this.baseServerUrl + "GetSessionInfo?email="+ email + "&password=" + password);
  }

  setToken(token: string){
    localStorage.setItem("access_token", token);
  }

  setSession(id: string){
    sessionStorage.setItem("id", id);
  }
}
