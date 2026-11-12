import { Component, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { LoginRequest, LoginResponse } from '../models/auth.models';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    imports: [
        ReactiveFormsModule,
        MatCardModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatIconModule,
        MatCheckboxModule,
        MatProgressSpinnerModule,
    ],
})
export class LoginComponent {
    private router = inject(Router);
    private fb = inject(FormBuilder);
    private http = inject(HttpClient);

    hidePassword = signal(true);
    loading = signal(false);
    errorMessage = signal<string | null>(null);

    form = this.fb.nonNullable.group({
        username: ['', Validators.required],
        password: ['', [Validators.required, Validators.minLength(6)]],
        rememberMe: [false],
    });

    togglePassword(event: MouseEvent) {
        event.preventDefault();
        this.hidePassword.update((v) => !v);
    }

    onSubmit() {
        if (this.form.invalid) {
            this.form.markAllAsTouched();
            return;
        }

        const credentials: LoginRequest = this.form.getRawValue();

        this.loading.set(true);
        this.errorMessage.set(null);
        this.form.disable();

        // withCredentials lets the browser keep the auth cookie the backend sets
        // and send it back on subsequent requests.
        this.http
            .post<LoginResponse>('/api/login', credentials, { withCredentials: true })
            .subscribe({
                next: () => {
                    this.loading.set(false);
                    this.form.enable();
                    this.router.navigate(['/dashboard']);
                },
                error: (err: HttpErrorResponse) => {
                    this.loading.set(false);
                    this.form.enable();
                    this.form.controls.password.reset();
                    this.errorMessage.set(err.message);
                },
            });
    }


    onSignUp() {
        // TODO: navigate to sign-up route once it exists
    }
}
