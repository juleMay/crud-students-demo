import { TableMapping } from "../../../../shared/utils/paged-response-to-table.util";
import { CourseStudentsListItem } from "../models/course-students-list-response.model";

export const COURSE_STUDENTS_TABLE_MAPPING: TableMapping<CourseStudentsListItem> = {
  headers: [
    { label: 'Student', sortable: true, sortKey: 'studentName' },
  ],
  columns: [
    c => c.studentName,
  ]
};
