import { TableMapping } from "../../../../shared/utils/paged-response-to-table.util";
import { StudentListItem } from "../models/course-list-response.model";

export const STUDENT_TABLE_MAPPING: TableMapping<StudentListItem> = {
  headers: [
    { label: 'Student', sortable: true, sortKey: 'Name.FirstSurname' },
    { label: 'Courses', sortable: false, sortKey: 'Enrrollments' },
  ],
  columns: [
    c => c.studentName,
    c => c.enrollments,
  ]
};
