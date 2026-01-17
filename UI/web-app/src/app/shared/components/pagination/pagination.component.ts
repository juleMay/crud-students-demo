import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Pagination } from '../../models/pagination.model';
import { PAGINATION } from '../../constants/pagination.constant';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './pagination.component.html',
})
export class PaginationComponent {
  @Input({ required: true }) pagination!: Pagination;

  @Output() pageChange = new EventEmitter<number>();
  @Output() pageSizeChange = new EventEmitter<number>();

  readonly pageSizes = PAGINATION.PAGE_SIZE_OPTIONS;

  get totalPages(): number {
    return Math.ceil(this.pagination.totalCount / this.pagination.pageSize);
  }

  pages(): number[] {
    return Array.from({ length: this.totalPages }, (_, i) => i + 1);
  }

  goTo(page: number) {
    if (page < 1 || page > this.totalPages) return;
    if (page === this.pagination.page) return;

    this.pageChange.emit(page);
  }

  next() {
    if (this.pagination.hasNextPage) {
      this.pageChange.emit(this.pagination.page + 1);
    }
  }

  previous() {
    if (this.pagination.hasPreviousPage) {
      this.pageChange.emit(this.pagination.page - 1);
    }
  }

  changePageSize(size: number) {
    if (size === this.pagination.pageSize) return;
    this.pageSizeChange.emit(size);
  }
}
