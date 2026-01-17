import { PagedRequest } from "../models/paged-request.model";

export function pagedRequestToQueryParams(pagedRequest: PagedRequest): { [key: string]: string } {
    const queryParams: { [key: string]: string } = {};

    if (pagedRequest.page) {
        queryParams['page'] = String(pagedRequest.page);
    }

    if (pagedRequest.pageSize) {
        queryParams['pageSize'] = String(pagedRequest.pageSize);
    }

    if (pagedRequest.sortBy) {
        queryParams['sortBy'] = String(pagedRequest.sortBy);
    }

    if (pagedRequest.sortDirection) {
        queryParams['sortDirection'] = String(pagedRequest.sortDirection);
    }

    return queryParams;
}