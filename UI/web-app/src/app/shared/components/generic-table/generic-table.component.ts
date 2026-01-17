import {
  Component,
  Input,
  Output,
  EventEmitter,
  ContentChild,
  TemplateRef,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { SortEvent, Table, TableHeader } from '../../models/table.model';
import { PAGINATION } from '../../constants/pagination.constant';

@Component({
  selector: 'app-generic-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './generic-table.component.html',
})
export class GenericTableComponent {
  @Input({ required: true }) table!: Table;
  @Input() pageSize = PAGINATION.PAGE_SIZE;
  @Input() totalItems?: number;
  @Input() loading = false;

  @Output() pageChange = new EventEmitter<number>();
  @Output() sortChange = new EventEmitter<SortEvent>();

  @ContentChild('cellTemplate') cellTemplate?: TemplateRef<any>;

  currentPage = 1;
  currentSort?: SortEvent;

  get totalPages(): number {
    const total = this.totalItems ?? this.table.rows.length;
    return Math.ceil(total / this.pageSize);
  }

  onSort(header: TableHeader) {
    if (!header.sortable || !header.sortKey) return;

    const direction =
      this.currentSort?.key === header.sortKey &&
      this.currentSort.direction === 'asc'
        ? 'desc'
        : 'asc';

    this.currentSort = {
      key: header.sortKey,
      direction,
    };

    this.sortChange.emit(this.currentSort);
  }
}
