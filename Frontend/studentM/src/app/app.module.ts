import { UserService } from './user.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentDetailComponent } from './student-detail/student-detail.component';
import { StudentsMarksComponent } from './students-marks/students-marks.component';
import { AllStudentsComponent } from './all-students/all-students.component';
import { DetailServiceService } from './detail-service.service';
import { ChartsModule } from 'ng2-charts';
import { SignUpComponent } from './sign-up/sign-up.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { HeaderComponent } from './header/header.component';

@NgModule({
  declarations: [
    AppComponent,
    StudentDetailComponent,
    StudentsMarksComponent,
    AllStudentsComponent,
    SignUpComponent,
    SignInComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ChartsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    DetailServiceService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
