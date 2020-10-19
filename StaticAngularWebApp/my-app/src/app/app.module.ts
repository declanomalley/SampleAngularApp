import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactComponent } from './contact/contact.component';
import { ContactEditComponent } from './contact-edit/contact-edit.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ContactalertComponent } from './contactalert/contactalert.component';

import { ContactAPIService } from './contact.service';

@NgModule({
  declarations: [
    AppComponent,
    ContactComponent,
    ContactEditComponent,
    NavbarComponent,
    ContactalertComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgbModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ContactAPIService],
  bootstrap: [AppComponent]
})
export class AppModule { }
