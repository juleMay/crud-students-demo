import {
  Component,
  Input,
  Output,
  EventEmitter,
  ContentChild,
  TemplateRef,
  ChangeDetectorRef,
  inject,
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
  private readonly cdr = inject(ChangeDetectorRef);

  @Output() pageChange = new EventEmitter<number>();
  @Output() sortChange = new EventEmitter<SortEvent>();

  @ContentChild('cellTemplate') cellTemplate?: TemplateRef<any>;

  currentPage = 1;
  currentSort: SortEvent = { sortKey: null, direction: '' };

  get totalPages(): number {
    const total = this.totalItems ?? this.table.rows.length;
    return Math.ceil(total / this.pageSize);
  }

  onSort(header: TableHeader): void {
    if (!header.sortable) return;

    if (this.currentSort.sortKey !== header.sortKey) {
      this.currentSort = { sortKey: header.sortKey, direction: 'asc' };
    }
    else if (this.currentSort.direction === 'asc') {
      this.currentSort = { sortKey: header.sortKey, direction: 'desc' };
    }
    else {
      this.currentSort = { sortKey: null, direction: '' };
    }

    this.sortChange.emit(this.currentSort);
  }

  isSorted(header: TableHeader, dir: 'asc' | 'desc'): boolean {
    if (!header.sortable) return;
    return (
      this.currentSort.sortKey === header.sortKey &&
      this.currentSort.direction === dir
    );
  }
}
