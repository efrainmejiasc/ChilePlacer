import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import * as $ from 'jquery';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse, HttpParams } from '@angular/common/http'

@Component({
  selector: 'app-cl',
  templateUrl: './cl.component.html',
  styleUrls: ['./cl.component.css']
})
export class ClComponent implements OnInit {

  public msj: string;


  constructor() { }

  ngOnInit() {
  }




}
