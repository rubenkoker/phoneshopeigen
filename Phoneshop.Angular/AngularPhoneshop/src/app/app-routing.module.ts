import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OverviewComponent } from './components/overview/overview.component';
import { PhoneInfoComponent } from './components/phone-info/phone-info.component';
import { PhoneDetailsComponent } from './components/phone-details/phone-details.component';
import { ContactComponent } from './components/contact/contact.component';


const routes: Routes = [
  { path: '', component: OverviewComponent },
  { path: 'phones/info', component: PhoneInfoComponent },
  { path: 'phones/details/:phone_id', component: PhoneDetailsComponent },
  { path: 'overview', component: OverviewComponent },
  { path: 'contact', component: ContactComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes,{bindToComponentInputs: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
