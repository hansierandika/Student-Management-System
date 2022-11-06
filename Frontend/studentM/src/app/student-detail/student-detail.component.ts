import { ResponseModel } from './../models/response-model';
import { Mark } from './../models/mark';
import { StudentMarkView } from './../models/student_mark_view';
import { student } from './../models/studentData';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DetailServiceService } from '../services/detail-service.service';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';
import { Student } from './../models/student';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'app-student-detail',
  templateUrl: './student-detail.component.html',
  styleUrls: ['./student-detail.component.css']
})
export class StudentDetailComponent implements OnInit {

  private readonly notifier: NotifierService;

  id: string;
  data: any;
  public student: Student;
  x = 56;
  public mark: Mark[];
  message: string = ""
  public barChartOptions: ChartOptions = {
    responsive: true,
  };
  public barChartLabels: Label[] = ['Maths', 'Sinhala', 'English'];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [];



  constructor(private route: ActivatedRoute,
    private detailService: DetailServiceService,
    notifierService: NotifierService) {
    this.notifier = notifierService;
  }

  ngOnInit(): void {
    this.route.params.subscribe(params =>
      this.id = params['id']

    )
    this.getDetail();

  }

  getDetail() {
    this.detailService.getDetail(this.id).subscribe(student => this.student = student);
    // this.detailService.getMark(this.id).subscribe(mark => this.mark = mark);
    // console.warn(this.mark)
    // this.detailService.getDetail(this.id).subscribe(student => this.sdata = student);
    // console.log(this.sdata.maths)
    // //this.sdata= this.data;

    // this.barChartData = [
    //   { data: [56, this.sdata.sinhala, this.sdata.english, 0], label: 'Marks Chart' },
    // ];
  }

  //   this.detailService.getDetail(this.id).subscribe(student => this.sdata = student);
  //   //console.log(this.detailService.getDetail(this.id).subscribe(student => this.sdata = student))
  //   this.sdata= this.data;
  //   this.barChartData = [
  //     { data: [this.sdata.maths, this.sdata.sinhala, this.sdata.english, 0], label: 'Marks Chart' },
  //   ];
  // }

  public barChartData: ChartDataSets[];

  conertToCSV(studentDetails: Student) {
    this.detailService.conertToCSV(studentDetails).subscribe(

      (data: ResponseModel) => {
        this.message = data.message
        if (data.response === 'success') {
          this.notifier.notify('success', this.message)
        }else{
          this.notifier.notify('error', this.message)
        }


      }
    )
  }
}
