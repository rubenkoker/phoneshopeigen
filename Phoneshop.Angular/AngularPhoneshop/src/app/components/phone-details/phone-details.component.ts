import { Component,Input } from '@angular/core';
import { PhoneService } from '../../phone.service';
import Phone  from "../../Phone";
@Component({
  selector: 'app-phone-details',
  templateUrl: './phone-details.component.html',
  styleUrls: ['./phone-details.component.scss']
})
export class PhoneDetailsComponent {
  Phone?: Phone;

   @Input()
   set phone_id(id: number) {
    console.log(id);
      this.phoneService.GetPhoneById(id).subscribe(x => this.Phone=x);
   }
   
  constructor(private phoneService: PhoneService) {
    
  }
}
