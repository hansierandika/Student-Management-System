import { ResponseModel } from './../models/response-model';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Student } from '../models/student';
import { StudentMarkView } from '../models/student_mark_view';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private studentUrl = 'http://localhost:60988/api';
  constructor(
    private http: HttpClient
  ) { }

  registerUser(user: User): Observable<ResponseModel> {
    console.log(user)
    return this.http.post<ResponseModel>(this.studentUrl + '/User/saveUser', user);

  }

  getAuthStatus(){
    return false
  }

  userAuthentication(userName: string, password: string) {
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded', 'No-Auth': 'True' });
    return this.http.post(this.studentUrl + '/token', data, { headers: reqHeader });
  }

  logout(){
    const user = sessionStorage.getItem('currentUser');
    console.log(user)
    sessionStorage.removeItem('currentUser');
  }
}
