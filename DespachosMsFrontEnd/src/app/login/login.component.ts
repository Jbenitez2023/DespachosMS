import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { UsersService } from '../services/users/users.service';
import { Token } from '../models/token.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router'
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
  token: any[] = [];
  constructor(private router: Router,private toastr:ToastrService, private fb: FormBuilder,private loginService: UsersService) {}

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
    const credentials = this.loginForm.value;
    if (rememberMe) {
      localStorage.setItem('rememberedPassword', password);
      localStorage.setItem('rememberedUsername', username);
      localStorage.setItem('remember', rememberMe);
    } else {
      localStorage.removeItem('rememberedPassword');
      localStorage.removeItem('rememberedUsername');
      localStorage.removeItem('remember');
    }
    
    this.loginService.login(credentials).subscribe({
      next: data => {
        var tokenReceived = new Token();
        tokenReceived = this.transformaDataToToken(data)
        this.guardaToken(tokenReceived);
        this.router.navigate(['/intern/dashboard']);
      },
      error: err => {
        this.toastr.error("Datos incorrectos!");
      }
    });
  }

  guardaToken(objectToken : Token){
    sessionStorage.setItem("token",objectToken.token);   
   this.toastr.success("Datos correctos!");
  }

  transformaDataToToken(data:any[]){
    const firstItem = data[0];
    const token = new Token();
    token.token = firstItem;
    return token;
  }

}
