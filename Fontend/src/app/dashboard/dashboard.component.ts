import {Component, inject, signal} from '@angular/core';
import {Store} from '../models/store.models'
import {MatTab, MatTabGroup} from '@angular/material/tabs';
import {AddCardComponent} from '../util/components/add-card/add-card-component';
import {DashboardService} from '../services/dashboard.service';
import {MatCard, MatCardContent, MatCardHeader, MatCardTitle} from '@angular/material/card';

@Component({
    selector: 'app-dashboard',
    standalone: true,
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css'],
	imports: [
		MatTabGroup,
		MatTab,
		AddCardComponent,
		MatCardContent,
		MatCard,
		MatCardTitle
	],
})

export class DashboardComponent {
	private readonly service = inject(DashboardService);
	stores = signal<Store[]>([]);

	ngOnInit() {
		this.service.getStores().subscribe(r => this.stores.set(r));
	}
}
