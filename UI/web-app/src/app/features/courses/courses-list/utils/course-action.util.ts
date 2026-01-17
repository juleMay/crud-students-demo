import { RowActionRule } from "../../../../shared/models/table.model";
import { CourseNavigationService } from "../../course-navigation.service";

export function createCourseActionRules(
  navigation: CourseNavigationService
): RowActionRule[] {
  return [
    {
      when: () => true,
      actions: [
        {
          label: 'Details',
          buttonClass: 'btn btn-sm btn-primary',
          action: row => navigation.toCourseDetails(row.id),
        }
      ]
    }
  ];
}
