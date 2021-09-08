import { StudentMarkView } from './../models/student_mark_view';
import { Component, OnInit } from '@angular/core';
import { DetailServiceService } from '../detail-service.service';
import { Student } from '../models/student';
import { student } from '../models/studentData';

@Component({
  selector: 'app-students-marks',
  templateUrl: './students-marks.component.html',
  styleUrls: ['./students-marks.component.css']
})
export class StudentsMarksComponent implements OnInit {

  student :any;
  students: StudentMarkView[];
  
  constructor(private detailService : DetailServiceService) { }

  ngOnInit(): void {
    this.detailService.getStudentsForMArks().subscribe(students => this.students = students);
    
  }

  getStudents(){
    //this.student = this.service.getStudents();
  }

}
