import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericTableComponent } from '../../../shared/components/generic-table/generic-table.component';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { SortEvent, Table, TableHeader } from '../../../shared/models/table.model';
import { COURSE_STUDENTS_TABLE_MAPPING } from './mappings/course-students-table.mapping';
import { Pagination } from '../../../shared/models/pagination.model';
import { CourseNavigationService } from '../course-navigation.service';
import { CoursesApi } from '../courses.api';
import { CourseDetailResponse } from './models/course-detail-response.model';
import { pagedResponseToTable } from '../../../shared/utils/paged-response-to-table.util';
import { rowActionsToTable } from '../../../shared/utils/row-actions-to-table.util';
import { createCourseActionRules } from '../courses-list/utils/course-action.util';
import { PaginationComponent } from '../../../shared/components/pagination/pagination.component';
import { EnrollmentsApi } from '../enrollments.api';
import { EnrollmentResponse } from './models/enrollment-response.model';
import { EnrollmentStatus } from './enums/enrollment-status.enum';
import { PAGINATION } from '../../../shared/constants/pagination.constant';
import { EMPTY_ID } from '../../../shared/constants/empty-id.constant';
import { STUDENT_ID } from '../../../shared/constants/student-id.constant';

@Component({
  standalone: true,
  imports: [CommonModule, GenericTableComponent, RouterModule, PaginationComponent],
  templateUrl: './course-detail.html',
})
export class CourseDetail implements OnInit {
  headers: TableHeader[] = COURSE_STUDENTS_TABLE_MAPPING.headers;

  totalItems = 0;
  loading = false;

  pageSize = PAGINATION.PAGE_SIZE;
  table: Table;
  pagination: Pagination;

  course: CourseDetailResponse;
  enrollment?: EnrollmentResponse;

  EnrollmentStatus = EnrollmentStatus;

  emptyId = EMPTY_ID;

  studentId = STUDENT_ID;

  private readonly cdr = inject(ChangeDetectorRef);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly coursesApi = inject(CoursesApi);
  private readonly enrollmentsApi = inject(EnrollmentsApi);
  private readonly navigationService = inject(CourseNavigationService);

  ngOnInit() {
    this.route.params.subscribe(params => {
      const courseAssignmentId = params['id'];
      if (!courseAssignmentId) {
        throw new Error('Course assignment id is not found');
      }
      this.route.queryParams.subscribe(queryParams => {
        const page = Number(queryParams['page'] ?? PAGINATION.INITIAL_PAGE);
        const sortKey = queryParams['sortKey'];
        const sortDirection = queryParams['sortDirection'];
        this.loadPage(courseAssignmentId, page, sortKey, sortDirection);
      });
    });
  }

  loadPage(courseAssignmentId: string, page: number, sortKey?: string, sortDirection?: any) {
    this.loading = true;
    this.coursesApi
      .getCourseDetail(courseAssignmentId)
      .subscribe(res => {
        this.course = res;
        this.cdr.detectChanges();
      });
    this.enrollmentsApi
      .getEnrollment(this.studentId, courseAssignmentId)
      .subscribe(res => {
        this.enrollment = res;
        this.cdr.detectChanges();
      });
    this.coursesApi
      .getEnrolledStudents(courseAssignmentId, { page: page, pageSize: this.pageSize, sortBy: sortKey, sortDirection: sortDirection })
      .subscribe(res => {
        const rows = pagedResponseToTable(res, COURSE_STUDENTS_TABLE_MAPPING);

        this.table = rowActionsToTable(
          {
            headers: this.headers,
            rows: rows,
            hasActions: false,
          },
          createCourseActionRules(this.navigationService)
        );

        this.loading = false;
        this.totalItems = res.totalCount;
        this.pagination = res;
        this.cdr.detectChanges();
      });
  }

  onPageChange(page: number) {
    this.router.navigate([], {
      queryParams: { page },
      queryParamsHandling: 'merge',
    });
  }

  onSort(sort: SortEvent) {
    const queryParams: any = {
      page: 1,
    };

    if (sort.sortKey && sort.direction) {
      queryParams.sortKey = sort.sortKey;
      queryParams.sortDirection = sort.direction;
    } else {
      queryParams.sortKey = null;
      queryParams.sortDirection = null;
    }

    this.router.navigate([], {
      queryParams,
      queryParamsHandling: 'merge',
    });
  }

  onPageSizeChange(size: number) {
    this.pageSize = size;
    this.router.navigate([], {
      queryParams: {
        pageSize: this.pageSize,
        page: 1,
      },
      queryParamsHandling: 'merge',
    });
  }

  enrollToCourse() {
    if (this.enrollment.id === this.emptyId) {
      this.enrollmentsApi
        .enrollToCourse(this.course.id, this.studentId)
        .subscribe(() => this.reloadPage());
    } else {
      this.reenrollToCourse();
    }
  }

  withdrawFromCourse() {
    this.enrollmentsApi
      .withdrawFromCourse(this.enrollment.id)
      .subscribe(() => this.reloadPage());
  }

  reenrollToCourse() {
    this.enrollmentsApi
      .reenrollToCourse(this.enrollment.id)
      .subscribe(() => this.reloadPage());
  }

  goBack() {
    this.router.navigate(['courses']);
  }

  reloadPage() {
    globalThis.location.reload();
  }
}