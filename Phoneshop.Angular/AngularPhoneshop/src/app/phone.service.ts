import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import phone from './Phone';
@Injectable({
  providedIn: 'root'
})
export class PhoneService {

  constructor(private httpClient : HttpClient) { 
    
  }
  GetPhones(): Observable<phone[]>{
    console.log("hallo");
    return this.httpClient.get<phone[]>("https://localhost:4430/api/phones");
   }
   GetPhoneById(input:number): Observable<phone>{
    
    return this.httpClient.get<phone>(`https://localhost:4430/phone/${input}`);
   }
}
