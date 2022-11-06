import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentDetailComponent } from './student-detail/student-detail.component';
import { StudentsMarksComponent } from './students-marks/students-marks.component';
import { AllStudentsComponent } from './all-students/all-students.component';
import { DetailServiceService } from './services/detail-service.service';
import { ChartsModule } from 'ng2-charts';
import { SignUpComponent } from './sign-up/sign-up.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { HeaderComponent } from './header/header.component';
import { AddEditStudentComponent } from './add-edit-student/add-edit-student.component';
import { NotifierModule } from 'angular-notifier';
import { AddEditMarkComponent } from './add-edit-mark/add-edit-mark.component';
import { NavbarComponent } from './navbar/navbar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AddSubjectComponent } from './master/add-subject/add-subject.component';
import { AddTeachersComponent } from './master/add-teachers/add-teachers.component';
import { UserService } from './services/user.service';


@NgModule({
  declarations: [
    AppComponent,
    StudentDetailComponent,
    StudentsMarksComponent,
    AllStudentsComponent,
    SignUpComponent,
    SignInComponent,
    HeaderComponent,
    AddEditStudentComponent,
    AddEditMarkComponent,
    NavbarComponent,
    DashboardComponent,
    AddSubjectComponent,
    AddTeachersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ChartsModule,
    HttpClientModule,
    FormsModule,
    NotifierModule.withConfig({
      position: {
        horizontal: {
          position: "right",
          distance: 12
        },
        vertical: {
          position: "bottom",
          distance: 12,
          gap: 10
        }
      },
      behaviour: {
        autoHide: 5000
      },
      theme: "material"
    })
  ],
  providers: [
    DetailServiceService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
