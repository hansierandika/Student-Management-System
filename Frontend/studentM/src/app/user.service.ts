import { Mark } from './models/mark';
import { StudentMarkView } from './models/student_mark_view';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Student } from './models/student';
import { student } from './models/studentData';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private studentUrl = 'http://localhost:55937/api';
  constructor(
    private http: HttpClient
  ) { }

  registerUser(user: Student): Observable<Student> {
console.log("bhvb")
    return this.http.post<Student>(this.studentUrl + '/User/Register', user);

  }
}
