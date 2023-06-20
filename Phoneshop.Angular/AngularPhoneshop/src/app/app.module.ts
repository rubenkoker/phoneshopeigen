import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatToolbarModule } from '@angular/material/toolbar';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule, Routes, provideRouter, withComponentInputBinding } from '@angular/router';
import { AppComponent } from './app.component';
import {MatSidenavModule} from '@angular/material/sidenav'; 
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OverviewComponent } from './components/overview/overview.component';
import { PhoneInfoComponent } from './components/phone-info/phone-info.component';
import { HttpClientModule } from '@angular/common/http';
import { PhoneDetailsComponent } from './components/phone-details/phone-details.component';
import { ContactComponent } from './components/contact/contact.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    OverviewComponent,
    PhoneInfoComponent,
    PhoneDetailsComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatToolbarModule,
    MatSidenavModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
