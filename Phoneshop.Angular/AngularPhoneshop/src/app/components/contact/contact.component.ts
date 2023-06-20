import { Component } from '@angular/core';
import { ContactData } from '../../ContactData';
@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent {
  model = new ContactData(18, '', '');

  submitted = false;

  onSubmit() { this.submitted = true; }
}
