import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-contactalert',
  templateUrl: './contactalert.component.html',
  styleUrls: ['./contactalert.component.scss']
})
export class ContactalertComponent implements OnInit {
  @Input() product;
  @Output() notify = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }



}
