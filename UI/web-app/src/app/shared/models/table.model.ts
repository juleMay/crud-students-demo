export interface Table {
    headers: TableHeader[];
    rows: TableRow[];
    hasActions: boolean;
}

export interface TableHeader {
    label: string;
    sortable?: boolean;
    sortKey?: string;
}

export interface TableRow {
    id: string;
    cells: any[];
    actions?: RowActions[];
}

export interface RowActions {
    label: string;
    buttonClass: string;
    action: (row: TableRow) => void;
}

export interface RowActionRule {
    when: (row: TableRow) => boolean;
    actions: RowActions[];
}

export enum ButtonClass {
    PRIMARY = 'btn-primary',
    SECONDARY = 'btn-secondary',
    SUCCESS = 'btn-success',
    DANGER = 'btn-danger',
    WARNING = 'btn-warning',
    INFO = 'btn-info',
    LIGHT = 'btn-light',
    DARK = 'btn-dark',
}

export interface SortEvent {
    sortKey: string | null;
    direction: 'asc' | 'desc' | '';
}

export interface PageEvent {
    page: number;
    pageSize: number;
}
