import {Component} from '@angular/core';
import {MatCard, MatCardContent, MatCardHeader, MatCardTitle} from '@angular/material/card';
import {MatIconButton} from '@angular/material/button';
import {MatIcon} from '@angular/material/icon';

@Component({
	selector: 'add-card-component',
	templateUrl: './add-card-component.html',
	styleUrls: ['./add-card-component.css'],
	imports: [
		MatCard,
		MatCardHeader,
		MatCardTitle,
		MatCardContent,
		MatIconButton,
		MatIcon,
	],
	standalone: true
})

export class AddCardComponent {

}
