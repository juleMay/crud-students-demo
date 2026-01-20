import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorService } from './services/error.service';

@Component({
    selector: 'app-error-modal',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './error-modal.component.html'
})
export class ErrorModalComponent {

    private readonly errorService: ErrorService = inject(ErrorService);
    error$ = this.errorService.error$;

    close() {
        this.errorService.clear();
    }
}
