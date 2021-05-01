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
  public _identidad: string;
  public _username: string;


  constructor() { }

  ngOnInit() {
    this.getParametros();
  }


  public getParametros()
  {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    this._username = urlParams.get('user');
    $('#_username').val(this._username);
    this._identidad = atob(urlParams.get('ide'));
    $('#_identidad').val(this._identidad);
  }

}
