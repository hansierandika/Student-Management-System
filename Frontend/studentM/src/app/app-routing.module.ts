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
import { AuthGuard } from './services/auth.guard';

const routes: Routes = [
  { path: '', component: SignInComponent },
  {path:'dashboard',
  component:DashboardComponent,
  children:[
  { path: 'all-students', component: AllStudentsComponent, canActivate: [AuthGuard] },
  { path: 'student-detail/:id', component: StudentDetailComponent,canActivate: [AuthGuard] },
  { path: 'students-marks', component: StudentsMarksComponent, canActivate: [AuthGuard] },
  { path: 'students-add', component: AddEditStudentComponent, canActivate: [AuthGuard] },
  { path: 'subjects', component: AddSubjectComponent, canActivate: [AuthGuard] },
  { path: 'mark-add', component: AddEditMarkComponent, canActivate: [AuthGuard] }
]},

{ path: 'sign-up', component: SignUpComponent, canActivate: [AuthGuard] },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
