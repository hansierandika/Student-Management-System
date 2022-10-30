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
export class DetailServiceService {
  list: Student[];
  private studentUrl = 'http://localhost:60988/api';
  constructor(
    private http: HttpClient
  ) { }
  
  // getStudents(){
  //   //console.log(this.http.get(this.studentUrl+'/StudentDetail'))
  //   // console.log("this.http.get<Student[]>(this.studentUrl+'/StudentDetail')")
  //   // return this.http.get(this.studentUrl+'/StudentDetail')
  //   // .toPromise()
  //   // .then(res => this.list = res as Student[]);

  //   return this.http.get(this.studentUrl+'/StudentDetail');

  // }

  // getStudents(): Observable<Student[]>{
  //   //console.log(this.http.get(this.studentUrl+'/StudentDetail'))
  //   // console.log("this.http.get<Student[]>(this.studentUrl+'/StudentDetail')")
  //   // return this.http.get(this.studentUrl+'/StudentDetail')
  //   // .toPromise()
  //   // .then(res => this.list = res as Student[]);

  //   return this.http.get<Student[]>(this.studentUrl+'/StudentDetail').pipe(map(res => <any[]>res));

  // }
  getStudentsForMArks(): Observable<StudentMarkView[]> {
    return this.http.get<StudentMarkView[]>(this.studentUrl+'/Marks');
  }

  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(this.studentUrl+'/StudentDetails/getStudents');
  }

  getDetail(sId: string): Observable<Student>{
    // console.log(this.studentUrl+'/StudentDetail/'+sId)
    console.log('ok')
    console.log(sId)

    return this.http.get<Student>(this.studentUrl+'/StudentDetails/GetStudentDetail/'+sId);

  }

  getMark(sId: string): Observable<Mark[]>{
    
    return this.http.get<Mark[]>(this.studentUrl+'/StudentDetail'+'/GetMark/'+sId);

  }

  conertToCSV(student: Student): Observable<string> {
    return this.http.post<string>(this.studentUrl + '/StudentDetails/ConertToCSV', student);

  }


}
