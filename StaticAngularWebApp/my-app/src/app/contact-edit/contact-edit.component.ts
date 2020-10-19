import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ContactAPIService } from '../contact.service';
import { iContact } from '../interface/iContact';
import { FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-contact-edit',
  templateUrl: './contact-edit.component.html',
  styleUrls: ['./contact-edit.component.scss']
})
export class ContactEditComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private _contactApiService: ContactAPIService,
    private formBuilder: FormBuilder,
    private _router: Router
  ) {
    this.contactForm = this.formBuilder.group({
      id: 0,
      familyName: null,
      givenNames: null,
      dateOfBirth: null,
      sex: null
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      let id = params.get('id')

      if (id && id != "0") {
        this.getApiContactByID(id);
      }
    });
  }

  id: number;
  contact: iContact;
  contactForm;
  errorList: string[] = [];

  callback = x => {
    if (!x)
      console.error(x);

    if (x.id > 0) {
      this.getApiContactByID(x.id.toString());
    }
  }

  errorCallback = error => {
    console.log(error);
    if (error)
      this.errorList.push(error);
  }


  onSubmit(contactData) {
    //reset errors
    this.errorList = [];


    // have an id , its an update
    if (contactData.id > 0) {
      this._contactApiService.putContact(contactData).subscribe(data => {
        this.callback(data);
      }, error => {
          this.errorCallback(error);

      });
    }
    //insert
    else {
      this._contactApiService.postContact(contactData).subscribe(data => {
        this.callback(data);
      }, error => {
          this.errorCallback(error);
      });
    }



  }

  getApiContactByID(id: string) {
    this._contactApiService.getContact(id).subscribe(data => {
      this.contactForm = this.formBuilder.group(data);
      this.contact = data;
    });
  }

  deleteContact(contact: iContact) {
    if (!confirm('are you sure you want to delete this item?')) {
      return;
    }

    this._contactApiService.deleteContact(contact.id.toString()).subscribe(x => {
      this.errorList = [];
      //successfully deleted, go back to homepage
      if (x) {
        this._router.navigate(["/"]);
      }
    }, error => {
        this.errorCallback(error);
    });

  }

}
