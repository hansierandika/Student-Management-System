import { Component, OnInit } from '@angular/core';
import { DetailServiceService } from '../services/detail-service.service';
import { Student } from '../models/student';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-all-students',
  templateUrl: './all-students.component.html',
  styleUrls: ['./all-students.component.css']
})
export class AllStudentsComponent implements OnInit {

  students: Student[];
  da:any;

  constructor(private route: ActivatedRoute, 
    private router:Router,
    private detailService: DetailServiceService) {
      this.detailService.getStudents().subscribe((students: Student[]) => this.students = students);
    
     }

  ngOnInit(): void {
    this.getDetail()
  }

  // getDetail(){
  //   this.da=this.detailService.getStudents().subscribe(res => {
  //     this.da = res;
  //   });
  //   this.student= this.da.pipe.switchMap(response => {
  //         const config = response.result ? response.data : {};
  //         return this.handleConfig(type, config);
  //     }
  // );

  getDetail(){
    // this.barChartData = [
    //   { data: [this.sdata.maths, this.sdata.sinhala, this.sdata.english, 0], label: 'Marks Chart' },
    // ];
  }
}
