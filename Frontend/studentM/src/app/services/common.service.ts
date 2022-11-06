import { ResponseModel } from './../models/response-model';
import { Observable } from 'rxjs';
import { Subject } from './../models/subject.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  private studentUrl = 'http://localhost:60988/api'
  constructor(
    private http:HttpClient
  ) { }

  addSubject(subject:Subject): Observable<ResponseModel>{
return this.http.post<ResponseModel>(this.studentUrl+'/SubjectDetail/saveSubject',subject)
  }

  getSubjects():Observable<Subject[]>{
    return this.http.get<Subject[]>(this.studentUrl+'/SubjectDetail/getSubjects');

  }

}
