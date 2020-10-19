import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { iContact } from './interface/iContact';

@Injectable({
  providedIn: 'root'
})
export class ContactAPIService {

  constructor(private http: HttpClient) { }

  getContacts() : Observable<iContact[]> {
    return this.http.get<iContact[]>('https://ilrfunctionapi.azurewebsites.net/api/contact');
  }

  getContact(id : string): Observable<iContact> {
    return this.http.get<iContact>('https://ilrfunctionapi.azurewebsites.net/api/contact/'+id);
  }

  postContact(contact : iContact): Observable<iContact> {
    return this.http.post<iContact>('https://ilrfunctionapi.azurewebsites.net/api/contact/',contact);
  }

  deleteContact(id: string): Observable<boolean> {
    return this.http.delete<boolean>('https://ilrfunctionapi.azurewebsites.net/api/contact/'+id);
  }

  putContact(contact : iContact): Observable<iContact> {
    return this.http.put<iContact>('https://ilrfunctionapi.azurewebsites.net/api/contact/' + contact.id.toString(),contact);
  }
}
