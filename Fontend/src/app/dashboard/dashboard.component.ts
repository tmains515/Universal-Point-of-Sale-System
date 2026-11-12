import {Component} from '@angular/core';
import {Store} from '../models/store.models'
import { AppButtonComponent } from '../../components/app-button'
import { NgFor } from '@angular/common';

@Component({
    selector: 'app-dashboard',
    standalone: true,
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css'],
    imports: [AppButtonComponent, NgFor],
})

export class DashboardComponent {

    // Dummy data
    protected dummyStoresData:Store[] = [
        {id: 123, name: "store 1", location: "New York"},
        {id: 456, name: "store 2", location: "California"},
        {id: 123, name: "store 3", location: "New York"},
    ]

}
