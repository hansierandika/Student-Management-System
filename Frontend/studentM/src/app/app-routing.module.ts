import { AddSubjectComponent } from './master/add-subject/add-subject.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AddEditMarkComponent } from './add-edit-mark/add-edit-mark.component';
import { AddEditStudentComponent } from './add-edit-student/add-edit-student.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllStudentsComponent } from './all-students/all-students.component';
import { StudentDetailComponent } from './student-detail/student-detail.component';
import { StudentsMarksComponent } from './students-marks/students-marks.component';

const routes: Routes = [
  {path:'dashboard',
  component:DashboardComponent,
  children:[
  { path: 'all-students', component: AllStudentsComponent },
  { path: 'student-detail/:id', component: StudentDetailComponent },
  { path: 'students-marks', component: StudentsMarksComponent },
  { path: 'students-add', component: AddEditStudentComponent },
  { path: 'subjects-add', component: AddSubjectComponent },
  { path: 'mark-add', component: AddEditMarkComponent }
]},
{ path: '', component: SignInComponent },
{ path: 'sign-up', component: SignUpComponent },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
