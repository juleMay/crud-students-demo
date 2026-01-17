import { Routes } from '@angular/router';
import { CoursesList } from './features/courses/courses-list/courses-list';
import { CourseDetail } from './features/courses/course-detail/course-detail';
import { StudentsList } from './features/students/students-list/students-list';

export const appRoutes: Routes = [
  {
    path: '',
    redirectTo: 'courses',
    pathMatch: 'full',
  },
  {
    path: 'courses',
    component: CoursesList,
  },
  {
    path: 'courses/:id',
    component: CourseDetail,
  },
  {
    path: 'students',
    component: StudentsList,
  },
  {
    path: '**',
    redirectTo: 'courses',
  },
];
