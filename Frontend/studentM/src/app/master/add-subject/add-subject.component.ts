import { NotifierService } from 'angular-notifier';
import { CommonService } from './../../services/common.service';
import { Subject } from './../../models/subject.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-subject',
  templateUrl: './add-subject.component.html',
  styleUrls: ['./add-subject.component.css']
})

export class AddSubjectComponent implements OnInit {

  isActive: ActiveStatus[] = [
    { id: 1, name: "Active" },
    { id: 0, name: "Inactive" }
  ];
  //Array<Object> = new Array([
  //     {id: 0, name: "name1"},
  //     {id: 1, name: "name2"}
  // ]);
  subject: Subject
  message: string
  private readonly notifier:NotifierService;

  constructor(
    private _commonService: CommonService,
    notifierService:NotifierService
  ) {
this.notifier=notifierService;
  }

  ngOnInit(): void {
    this.subject = new Subject()
    this.subject.IsActive = 1

  }

  addSubject() {
    this._commonService.addSubject(this.subject).subscribe(
      (data) => {
        this.message = data.message
        if (data.response === 'OK') {
          this.notifier.notify('success', this.message)
          // this.router.navigate(['/all-students']);
        }
        else if(data.response === 'MultipleChoices'){
          this.notifier.notify('warning', this.message)
        } else {
          this.notifier.notify('error', this.message)
        }
      }
    )
  }

}


interface ActiveStatus {
  id: number,
  name: string
}