import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-button',
    standalone: true,
    imports: [CommonModule],
    template: `
    <button
      [type]="type"
      [disabled]="disabled"
      [ngClass]="variantClasses"
      (click)="onClick.emit($event)"
      class="px-4 py-2 rounded-md font-medium transition-all duration-100
             active:translate-y-1 active:shadow-sm">
      <ng-content></ng-content>
    </button>
  `
})
export class AppButtonComponent {
    @Input() type: 'button' | 'submit' = 'button';
    @Input() variant: 'primary' | 'secondary' | 'danger' = 'primary';
    @Input() disabled = false;

    @Output() onClick = new EventEmitter<MouseEvent>();

    get variantClasses(): string {
        const variants = {
            primary: "flex bg-secondary rounded-md px-4 py-1 hover:bg-accent hover:text-white shadow-lg transition-all duration-25 hover:shadow-xl active:translate-z-2 active:shadow-sm",
            secondary: 'bg-secondary text-primary hover:bg-secondary/90 shadow-lg hover:shadow-xl',
            danger: 'bg-red-500 text-white hover:bg-red-600 shadow-lg hover:shadow-xl'
        };

        const disabledClasses = 'opacity-50 cursor-not-allowed';

        return this.disabled
            ? `${variants[this.variant]} ${disabledClasses}`
            : variants[this.variant];
    }
}
