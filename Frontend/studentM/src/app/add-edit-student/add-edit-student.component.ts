import { Router, ActivatedRoute } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { DetailServiceService } from './../detail-service.service';
import { Student } from './../models/student';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-edit-student',
  templateUrl: './add-edit-student.component.html',
  styleUrls: ['./add-edit-student.component.css']
})
export class AddEditStudentComponent implements OnInit {

  student: Student;
  private readonly notifier: NotifierService;
  message:string
  constructor(private route: ActivatedRoute, 
    private router:Router,
    private _studentService : DetailServiceService,
    notifierService: NotifierService) {
    this.notifier = notifierService;}

  ngOnInit(): void {
    this.student=new Student();
  }

  addStudent(){
    console.log(this.student)
this._studentService.addStudent(this.student).subscribe(
  (data)=>{
    this.message = data.message
        if (data.response === 'success') {
          this.notifier.notify('success', this.message)
          this.router.navigate(['/all-students']);
        }else{
          this.notifier.notify('error', this.message)
        }
  }
)
  }


}
