import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericTableComponent } from '../../../shared/components/generic-table/generic-table.component';
import { SortEvent, Table, TableHeader } from '../../../shared/models/table.model';
import { CoursesApi } from '../courses.api';
import { pagedResponseToTable } from '../../../shared/utils/paged-response-to-table.util';
import { COURSE_TABLE_MAPPING } from './mappings/course-table.mapping';
import { rowActionsToTable } from '../../../shared/utils/row-actions-to-table.util';
import { ActivatedRoute, Router } from '@angular/router';
import { PaginationComponent } from '../../../shared/components/pagination/pagination.component';
import { Pagination } from '../../../shared/models/pagination.model';
import { createCourseActionRules } from './utils/course-action.util';
import { CourseNavigationService } from '../course-navigation.service';
import { PAGINATION } from '../../../shared/constants/pagination.constant';

@Component({
  standalone: true,
  imports: [CommonModule, GenericTableComponent, PaginationComponent],
  templateUrl: './courses-list.html',
})
export class CoursesList implements OnInit {
  headers: TableHeader[] = COURSE_TABLE_MAPPING.headers;

  totalItems = 0;
  loading = false;

  pageSize = PAGINATION.PAGE_SIZE;
  table: Table;
  pagination: Pagination;

  private readonly cdr = inject(ChangeDetectorRef);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly api = inject(CoursesApi);
  private readonly navigationService = inject(CourseNavigationService);

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      const page = Number(params['page'] ?? PAGINATION.INITIAL_PAGE);
      const sortKey = params['sortKey'];
      const sortDirection = params['sortDirection'];
      this.loadPage(page, sortKey, sortDirection);
    });
  }

  loadPage(page: number, sortKey?: string, sortDirection?: any) {
    this.loading = true;
    this.api
      .getCourses({ page: page, pageSize: this.pageSize, sortBy: sortKey, sortDirection: sortDirection })
      .subscribe(res => {
        const rows = pagedResponseToTable(res, COURSE_TABLE_MAPPING);

        this.table = rowActionsToTable(
          {
            headers: this.headers,
            rows: rows,
            hasActions: true,
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
    this.router.navigate([], {
      queryParams: {
        sortKey: sort.key,
        dir: sort.direction,
        page: 1,
      },
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
}
