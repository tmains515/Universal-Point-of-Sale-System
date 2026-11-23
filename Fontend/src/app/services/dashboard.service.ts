import {inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {BASE_URL} from '../core-config/tokens';
import {Observable} from 'rxjs';
import {Store} from '../models/store.models';


@Injectable({ providedIn: 'root'})
export class DashboardService {
	private readonly http = inject(HttpClient);
	private readonly baseUrl = inject(BASE_URL);

	getStores(): Observable<Store[]> {
		return this.http.get<Store[]>(`${this.baseUrl}/stores`, {withCredentials: true});
	}
}
