export interface LoginRequest {
    username: string;
    password: string;
    rememberMe: boolean;
}

export interface LoginResponse {
    id: string;
    username: string;
    email: string | null;
}
