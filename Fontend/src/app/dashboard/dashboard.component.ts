import {Component} from '@angular/core';
import {Store} from '../models/store.models'
import {MatTab, MatTabGroup} from '@angular/material/tabs';
import {AddCardComponent} from '../util/components/add-card/add-card-component';

@Component({
    selector: 'app-dashboard',
    standalone: true,
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css'],
	imports: [
		MatTabGroup,
		MatTab,
		AddCardComponent
	],
})

export class DashboardComponent {

    // Dummy data
    protected dummyStoresData:Store[] = [
        {id: 123, name: "store 1", location: "New York"},
        {id: 456, name: "store 2", location: "California"},
        {id: 123, name: "store 3", location: "New York"},
    ]

}
