import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserInfo } from 'src/app/models/user-model.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  isUserValid: boolean = false;

  user: UserInfo = {
    id: '',
    firstname: '',
    lastname: '',
    email: '',
    phone: '',
    password: ''
}

  constructor(
    private loginAuth: AuthService,
    private router: Router) {}

  ngOnInit(): void {
    
  }

  loginForm = new FormGroup({
    email: new FormControl('',[
      Validators.required,
      Validators.email
    ]),
    pwd: new FormControl('',[
      Validators.required,
      Validators.minLength(6)
    ])
  });

  loginSubmited(){
    this.loginAuth.loginUser([
      this.loginForm.value.email || '',
      this.loginForm.value.pwd || ''
    ]).subscribe((res) =>{
      if (res == 'Success') {
        this.isUserValid = true;
        this.loginAuth.setToken(Math.random().toString());
        this.loginInfo();
        this.router.navigateByUrl('home');
      } else if(res == 'User not found.') {
        this.isUserValid = false;
        alert(res);
      } else {
        this.isUserValid = false;
        alert(res);
      }
    });
  }

  loginInfo(){
    const email=this.loginForm.value.email || '';
    const password = this.loginForm.value.pwd || '';
    this.loginAuth.getUserInfo(email,
      password).subscribe({
      next: (response) => {
        this.user = response;
        console.log(this.user);
        this.loginAuth.setSession(this.user.id.toString());
      }
    })
  }
  
  get Email(): FormControl{
    return this.loginForm.get("email") as FormControl;
  }
  get Pwd(): FormControl{
    return this.loginForm.get("pwd") as FormControl;
  }
}