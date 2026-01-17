import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PagedResponse } from '../../shared/models/paged-response.model';
import { CourseListItem } from './courses-list/models/course-list-response.model';
import { PagedRequest } from '../../shared/models/paged-request.model';
import { CourseDetailResponse } from './course-detail/models/course-detail-response.model';
import { CourseStudentsListItem } from './course-detail/models/course-students-list-response.model';
import { pagedRequestToQueryParams } from '../../shared/utils/paged-request-to-query-params.util';

@Injectable({ providedIn: 'root' })
export class CoursesApi {
    private readonly baseUrl = 'http://localhost:5114/api/course-assignments';


    constructor(private readonly http: HttpClient) { }

    getCourses(pagedRequest: PagedRequest) {
        return this.http.get<PagedResponse<CourseListItem>>(this.baseUrl, { params: pagedRequestToQueryParams(pagedRequest) });
    }

    getEnrolledStudents(courseAssignmentId: string, pagedRequest: PagedRequest) {
        return this.http.get<PagedResponse<CourseStudentsListItem>>(`${this.baseUrl}/${courseAssignmentId}/enrollments`, { params: pagedRequestToQueryParams(pagedRequest) });
    }

    getCourseDetail(courseAssignmentId: string) {
        return this.http.get<CourseDetailResponse>(`${this.baseUrl}/${courseAssignmentId}`);
    }
}