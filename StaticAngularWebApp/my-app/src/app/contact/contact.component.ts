import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { ContactAPIService } from '../contact.service';
import { iContact } from '../interface/iContact'

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {

  constructor(private _contactservice : ContactAPIService) { }

  ngOnInit(): void {
    this.getContacts();
  }

  contacts: iContact[];

  getContacts() {
    this._contactservice.getContacts().subscribe(data => { this.contacts = data; });
  }

  onDelete(id: number) {
    if (!confirm('are you sure you want to delete this item?')) {
      return;
    }

    this._contactservice.deleteContact(id.toString()).subscribe(data => {
      if (data && data == true) {
        this.getContacts();
      }
    });
  }

  

}
