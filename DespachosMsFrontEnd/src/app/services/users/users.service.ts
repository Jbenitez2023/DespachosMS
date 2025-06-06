import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private apiUrl = 'http://localhost:9000';

  constructor(private http: HttpClient) { }

  login(credentials: { userName: string; password: string }): Observable<any[]> {
    return this.http.post<any[]>(this.apiUrl+"/users/UserValidation",credentials);
  }
}
