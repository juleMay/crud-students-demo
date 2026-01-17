import { Injectable } from '@angular/core';

export type ThemeMode = 'light' | 'dark' | 'auto';

@Injectable({
    providedIn: 'root'
})
export class ThemeService {
    private readonly storageKey = 'theme';

    constructor() {
        this.applyTheme(this.getPreferredTheme());
        globalThis.matchMedia('(prefers-color-scheme: dark)')
            .addEventListener('change', () => {
                const stored = this.getStoredTheme();
                if (stored !== 'light' && stored !== 'dark') {
                    this.applyTheme(this.getPreferredTheme());
                }
            });
    }

    getStoredTheme(): ThemeMode | null {
        return localStorage.getItem(this.storageKey) as ThemeMode | null;
    }

    setStoredTheme(theme: ThemeMode): void {
        localStorage.setItem(this.storageKey, theme);
    }

    getPreferredTheme(): ThemeMode {
        const stored = this.getStoredTheme();
        if (stored) return stored;

        return globalThis.matchMedia('(prefers-color-scheme: dark)').matches
            ? 'dark'
            : 'light';
    }

    applyTheme(theme: ThemeMode): void {
        let resolvedTheme = theme;
        if (theme === 'auto') {
            resolvedTheme = globalThis.matchMedia('(prefers-color-scheme: dark)').matches
                ? 'dark'
                : 'light';
        }
        document.documentElement.dataset.bsTheme = resolvedTheme;
    }

    setTheme(theme: ThemeMode): void {
        this.setStoredTheme(theme);
        this.applyTheme(theme);
    }
}
