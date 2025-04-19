import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit  {
  
  loginForm!: FormGroup;
  rememberedUsername:string|null = "";
  rememberedPassword:string|null = "";
  remember:boolean|null = false;
  constructor(private fb: FormBuilder) {}



  ngOnInit(): void {

    if (typeof window !== 'undefined') {
        this.rememberedUsername = localStorage.getItem('rememberedUsername');
        this.rememberedPassword = localStorage.getItem('rememberedPassword');
        if (localStorage.getItem('remember') != "false" &&
            localStorage.getItem('remember') != "" &&
            localStorage.getItem('remember') != null){
            this.remember =true;
        }
        
    }

    this.loginForm = this.fb.group({
      username: [this.rememberedUsername ||''],
      password: [this.rememberedPassword ||''],
      rememberMe: [this.remember||false]
    });
  }

  login(): void {
    const { username, password, rememberMe } = this.loginForm.value;
    if (rememberMe) {
      localStorage.setItem('rememberedPassword', password);
      localStorage.setItem('rememberedUsername', username);
      localStorage.setItem('remember', rememberMe);
    } else {
      localStorage.removeItem('rememberedPassword');
      localStorage.removeItem('rememberedUsername');
      localStorage.removeItem('remember');
    }
  }

}
