import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnrollmentResponse } from './course-detail/models/enrollment-response.model';

@Injectable({ providedIn: 'root' })
export class EnrollmentsApi {
    private readonly baseUrl = 'http://localhost:5114/api/enrollments';


    constructor(private readonly http: HttpClient) { }

    getEnrollment(studentId: string, courseAssignmentId: string) {
        return this.http.get<EnrollmentResponse>(`${this.baseUrl}/students/${studentId}/course-assignments/${courseAssignmentId}`);
    }

    enrollToCourse(courseAssignmentId: string, studentId: string) {
        return this.http.post(this.baseUrl, { studentId, courseAssignmentId });
    }

    withdrawFromCourse(enrollmentId: string) {
        return this.http.delete(`${this.baseUrl}/${enrollmentId}`);
    }

    reenrollToCourse(enrollmentId: string) {
        return this.http.put(`${this.baseUrl}/${enrollmentId}`, {});
    }
}