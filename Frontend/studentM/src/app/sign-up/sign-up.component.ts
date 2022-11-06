import { UserService } from './../services/user.service';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Student } from '../models/student';

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
    // this.userService.registerUser(this.user).subscribe();
  }

}
