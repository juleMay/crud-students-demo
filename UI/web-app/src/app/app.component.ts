import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ThemeToggleComponent } from './shared/components/theme-toggle/theme-toggle.component';
import { ErrorModalComponent } from './shared/components/error-modal/error-modal.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterModule, ThemeToggleComponent, ErrorModalComponent],
  templateUrl: './app.component.html',
})
export class AppComponent {
  
}
