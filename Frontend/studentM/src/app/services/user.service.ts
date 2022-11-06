
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Student } from '../models/student';
import { StudentMarkView } from '../models/student_mark_view';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private studentUrl = 'http://localhost:55937/api';
  constructor(
    private http: HttpClient
  ) { }

  registerUser(user: StudentMarkView): Observable<Student> {
    return this.http.post<Student>(this.studentUrl + '/User/Register', user);

  }

  userAuthentication(userName: string, password: string) {
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded', 'No-Auth': 'True' });
    return this.http.post(this.studentUrl + '/token', data, { headers: reqHeader });
  }
}
