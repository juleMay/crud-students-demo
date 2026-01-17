import { PagedResponse } from "../models/paged-response.model";
import { TableHeader, TableRow } from "../models/table.model";

export interface TableMapping<T> {
    headers: TableHeader[];
    columns: ((item: T) => any)[];
}

export function pagedResponseToTable<T>(
    response: PagedResponse<T>,
    mapping: TableMapping<T>
): TableRow[] {
    return response.items.map(item => ({
        id: item['id'],
        cells: mapping.columns.map(column => column(item))
    }));
}
