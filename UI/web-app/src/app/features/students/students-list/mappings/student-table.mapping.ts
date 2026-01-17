import { TableMapping } from "../../../../shared/utils/paged-response-to-table.util";
import { StudentListItem } from "../models/course-list-response.model";

export const STUDENT_TABLE_MAPPING: TableMapping<StudentListItem> = {
  headers: [
    { label: 'Student', sortable: true, sortKey: 'studentName' },
    { label: 'Courses', sortable: true, sortKey: 'enrollments' },
  ],
  columns: [
    c => c.studentName,
    c => c.enrollments,
  ]
};
