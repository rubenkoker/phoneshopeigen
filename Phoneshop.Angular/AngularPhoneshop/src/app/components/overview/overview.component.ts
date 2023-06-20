import { Component } from '@angular/core';
import { PhoneService } from '../../phone.service';
import phone from '../../Phone';
@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.scss']
})
export class OverviewComponent {
  constructor(phoneService: PhoneService) {
    phoneService.GetPhones().subscribe(x=> {this.Phonelist = x});
    console.log("in overview");
}
Phonelist?:  phone[];

}
