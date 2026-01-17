import { inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class CourseNavigationService {
    private readonly router = inject(Router);

    toCourseDetails(id: string) {
        this.router.navigate(['/courses', id]);
    }
}
