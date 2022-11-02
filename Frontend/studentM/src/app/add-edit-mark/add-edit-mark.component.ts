import { Mark } from './../models/mark';
import { student } from './../models/studentData';
import { DetailServiceService } from './../detail-service.service';
import { Student } from './../models/student';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-edit-mark',
  templateUrl: './add-edit-mark.component.html',
  styleUrls: ['./add-edit-mark.component.css']
})
export class AddEditMarkComponent implements OnInit {

  studentNo:string
  students:Student[]
  mark:Mark

  constructor(private detailService: DetailServiceService) {
    this.detailService.getStudents().subscribe((students: Student[]) => this.students = students);
   }

  ngOnInit(): void {
    this.mark=new Mark();
  }

  public loadStudentNo(e:any): void {
    let find = this.students.find(x => x?.RegistrationNo === e.target.value);
    console.log(find?.RegistrationNo);
  }
}
