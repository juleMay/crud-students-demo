import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AppError } from '../models/error.model';

@Injectable({ providedIn: 'root' })
export class ErrorService {
  private readonly errorSubject = new BehaviorSubject<AppError | null>(null);
  error$ = this.errorSubject.asObservable();

  show(error: AppError) {
    this.errorSubject.next(error);
  }

  clear() {
    this.errorSubject.next(null);
  }
}
