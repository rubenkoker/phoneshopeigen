import { Component,Input } from '@angular/core';
import phone from '../../Phone';

@Component({
  selector: 'app-phone-info',
  templateUrl: './phone-info.component.html',
  styleUrls: ['./phone-info.component.scss']
})
export class PhoneInfoComponent {
  @Input() Phone! : phone;
 
}
