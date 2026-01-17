import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PagedResponse } from '../../shared/models/paged-response.model';
import { PagedRequest } from '../../shared/models/paged-request.model';
import { pagedRequestToQueryParams } from '../../shared/utils/paged-request-to-query-params.util';
import { StudentListItem } from './students-list/models/course-list-response.model';

@Injectable({ providedIn: 'root' })
export class StudentsApi {
    private readonly baseUrl = 'http://localhost:5114/api/students';


    constructor(private readonly http: HttpClient) { }

    getStudents(pagedRequest: PagedRequest) {
        return this.http.get<PagedResponse<StudentListItem>>(`${this.baseUrl}/enrollments`, { params: pagedRequestToQueryParams(pagedRequest) });
    }
}