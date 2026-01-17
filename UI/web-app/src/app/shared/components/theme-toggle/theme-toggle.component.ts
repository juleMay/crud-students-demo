import { Component } from '@angular/core';
import { ThemeMode, ThemeService } from './services/theme.service';

@Component({
  selector: 'app-theme-toggle',
  templateUrl: './theme-toggle.component.html'
})
export class ThemeToggleComponent {
  currentTheme: ThemeMode;

  themes: ThemeMode[] = ['light', 'dark', 'auto'];

  constructor(private readonly themeService: ThemeService) {
    this.currentTheme = this.themeService.getPreferredTheme();
  }

  setTheme(theme: ThemeMode): void {
    this.currentTheme = theme;
    this.themeService.setTheme(theme);
  }

  isActive(theme: ThemeMode): boolean {
    return this.currentTheme === theme;
  }
}
