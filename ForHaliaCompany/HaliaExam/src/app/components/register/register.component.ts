import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  repeatPass: string = 'none'; 

  displayMessage: string = '';
  isAccountCreated: boolean = false;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
  }

  registerForm = new FormGroup({
    firstName: new FormControl('',[
      Validators.required,
      Validators.minLength(2)]),
    lastName: new FormControl('',[
      Validators.required,
      Validators.minLength(2)]),
    email: new FormControl('',[
      Validators.required,
      Validators.email]),
    mobile: new FormControl('',[
      Validators.required,
      Validators.minLength(10),
      Validators.maxLength(10),
      Validators.pattern("[0-9]*")
    ]),
    pwd: new FormControl('',[
      Validators.required,
      Validators.minLength(6)
    ]),
    rpwd: new FormControl(''),
  });

  registerSubmited(){
    if (this.Pwd.value == this.Rpwd.value) {
      console.log('Submited')
      this.repeatPass = 'none'

      this.authService.registerUser([
        this.registerForm.value.firstName || '',
        this.registerForm.value.lastName || '',
        this.registerForm.value.mobile || '',
        this.registerForm.value.email || '',
        this.registerForm.value.pwd || ''
      ]).subscribe((res) =>{
        if (res == 'Success') {
          this.displayMessage = 'Account Created Successfully!';
          this.isAccountCreated = true;
        } else if (res == 'Email is already exist.'){
          this.displayMessage = 'Email is already exist.';
          this.isAccountCreated = false;
        } else if (res == 'Phone is already exist.'){
          this.displayMessage = 'Phone is already exist.';
          this.isAccountCreated = false;
        } else if (res == 'Invalid Password.'){
          this.displayMessage = 'Invalid! Password should be alphanumeric';
          this.isAccountCreated = false;
        } else {
          this.displayMessage = res;
          this.isAccountCreated = false;
        }
      });
    }
    else{
      this.repeatPass = 'inline'
    }
  }

  get FirstName(): FormControl{
    return this.registerForm.get("firstName") as FormControl;
  }
  get LastName(): FormControl{
    return this.registerForm.get("lastName") as FormControl;
  }
  get Email(): FormControl{
    return this.registerForm.get("email") as FormControl;
  }
  get Mobile(): FormControl{
    return this.registerForm.get("mobile") as FormControl;
  }
  get Pwd(): FormControl{
    return this.registerForm.get("pwd") as FormControl;
  }
  get Rpwd(): FormControl{
    return this.registerForm.get("rpwd") as FormControl;
  }

}