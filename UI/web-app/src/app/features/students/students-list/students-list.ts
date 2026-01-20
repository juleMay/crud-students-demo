import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericTableComponent } from '../../../shared/components/generic-table/generic-table.component';
import { PaginationComponent } from '../../../shared/components/pagination/pagination.component';
import { SortEvent, Table, TableHeader } from '../../../shared/models/table.model';
import { Pagination } from '../../../shared/models/pagination.model';
import { STUDENT_TABLE_MAPPING } from './mappings/student-table.mapping';
import { ActivatedRoute, Router } from '@angular/router';
import { pagedResponseToTable } from '../../../shared/utils/paged-response-to-table.util';
import { rowActionsToTable } from '../../../shared/utils/row-actions-to-table.util';
import { CourseNavigationService } from '../../courses/course-navigation.service';
import { createCourseActionRules } from '../../courses/courses-list/utils/course-action.util';
import { StudentsApi } from '../students.api';
import { PAGINATION } from '../../../shared/constants/pagination.constant';

@Component({
  standalone: true,
  imports: [CommonModule, GenericTableComponent, PaginationComponent],
  templateUrl: './students-list.html',
})
export class StudentsList implements OnInit {
  headers: TableHeader[] = STUDENT_TABLE_MAPPING.headers;

  totalItems = 0;
  loading = false;

  pageSize = PAGINATION.PAGE_SIZE;
  table: Table;
  pagination: Pagination;

  private readonly cdr = inject(ChangeDetectorRef);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly api = inject(StudentsApi);
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
      .getStudents({ page: page, pageSize: this.pageSize, sortBy: sortKey, sortDirection: sortDirection })
      .subscribe(res => {
        const rows = pagedResponseToTable(res, STUDENT_TABLE_MAPPING);

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
}
