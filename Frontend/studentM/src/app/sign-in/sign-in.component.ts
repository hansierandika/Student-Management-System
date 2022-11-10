import { User } from './../models/user.model';
import { UserService } from './../services/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Student } from './../models/student';
import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  user:User
  userName: string;
  password: string;
  isLoginError: boolean = false;

  constructor(private route: ActivatedRoute,
    private userService: UserService,
    private routepath: Router) { }

  userState =''
  ngOnInit(): void {
    this.routepath.navigate(['/'])
    console.log(sessionStorage.getItem('currentUser'))
    if(sessionStorage.getItem('currentUser') != null){
      this.userState = sessionStorage.getItem('currentUser')!
    }
  }

  logAsStudent() {
    this.userState = 'Student'
    sessionStorage.setItem('currentUser', this.userState);
    console.log(sessionStorage.getItem('currentUser'))

  }

  logAsTeacher() {
    this.userState = 'Teacher'
    sessionStorage.setItem('currentUser', this.userState);
    console.log(sessionStorage.getItem('currentUser'))
  
  }

  onSubmit() {
    this.userService.userAuthentication(this.userName, this.password).subscribe((data: any) => {
      localStorage.setItem('userToken', data.access_token);
      this.routepath.navigate(['/all-students']);
    },
      (err: HttpErrorResponse) => {
        this.isLoginError = true;
      });
  }

  
  removeUserRole(){
    sessionStorage.removeItem('currentUser');
    delete sessionStorage.currentUser;
    this.userState =''
  }
}
