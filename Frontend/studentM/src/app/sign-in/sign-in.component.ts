import { UserService } from './../user.service';
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

  userName: string;
  password: string;
  isLoginError : boolean = false;
  
  constructor(private route: ActivatedRoute, 
    private userService: UserService,
    private routepath: Router) { }

  ngOnInit(): void {
  }

  onSubmit(){
     this.userService.userAuthentication(this.userName, this.password).subscribe((data:any)=>{
       localStorage.setItem('userToken',data.access_token);
       this.routepath.navigate(['/all-students']);
     },
     (err: HttpErrorResponse)=>{
       this.isLoginError= true;
     } );
  }

}
