import { TableMapping } from "../../../../shared/utils/paged-response-to-table.util";
import { CourseListItem } from "../models/course-list-response.model";

export const COURSE_TABLE_MAPPING: TableMapping<CourseListItem> = {
  headers: [
    { label: 'Course', sortable: true, sortKey: 'courseName' },
    { label: 'Credits', sortable: true, sortKey: 'credits' },
    { label: 'Teacher', sortable: true, sortKey: 'teacherName' },
  ],
  columns: [
    c => c.courseName,
    c => c.credits,
    c => c.teacherName,
  ]
};
