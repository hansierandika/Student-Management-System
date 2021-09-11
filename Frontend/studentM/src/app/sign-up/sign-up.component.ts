import { ActivatedRoute } from '@angular/router';
import { UserService } from './../user.service';
import { Student } from './../models/student';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  user= new Student();

  constructor(private route: ActivatedRoute, 
    private userService: UserService) { }

  ngOnInit(): void {
  }
  submit(){
    this.userService.registerUser(this.user).subscribe();
  }

}
