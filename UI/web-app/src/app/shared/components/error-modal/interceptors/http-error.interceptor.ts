import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { ErrorService } from '../services/error.service';

export const httpErrorInterceptor: HttpInterceptorFn = (req, next) => {
    const errorService = inject(ErrorService);
    return next(req).pipe(
        catchError((error: HttpErrorResponse) => {
            errorService.show({
                title: error.error?.title ?? 'Unexpected error',
                message: error.error?.message ?? 'Unexpected error',
                status: error.status,
                details: error.error?.details ?? []
            });
            return throwError(() => error);
        })
    );
};