import {Component, input} from '@angular/core';
import {MatSidenav, MatSidenavContainer} from '@angular/material/sidenav';
import {MatNavList} from '@angular/material/list';
import {MatFabButton} from '@angular/material/button';

@Component({
	selector: 'app-navbar-component',
	templateUrl: './navbar-component.html',
	styleUrls: ['./navbar-component.css'],
	imports: [
		MatSidenavContainer,
		MatSidenav,
		MatNavList,
		MatFabButton
	],
	standalone: true
})


export class NavbarComponent{
	menuItems = input.required<string[]>();
}
