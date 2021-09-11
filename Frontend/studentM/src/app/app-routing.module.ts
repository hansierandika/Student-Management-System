import { SignUpComponent } from './sign-up/sign-up.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllStudentsComponent } from './all-students/all-students.component';
import { StudentDetailComponent } from './student-detail/student-detail.component';
import { StudentsMarksComponent } from './students-marks/students-marks.component';

const routes: Routes = [
  { path: 'all-students', component: AllStudentsComponent },
  { path: 'sign-in', component: SignInComponent },
  { path: 'sign-up', component: SignUpComponent },
  { path: 'student-detail/:id', component: StudentDetailComponent },
  { path: 'students-marks', component: StudentsMarksComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
