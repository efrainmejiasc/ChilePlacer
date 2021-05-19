import { Component, OnInit } from '@angular/core';
import { AppConfiguration } from "read-appsettings-json";
import * as $ from 'jquery';

@Component({
  selector: 'app-publicacion-home',
  templateUrl: './publicacion-home.component.html',
  styleUrls: ['./publicacion-home.component.css']
})
export class PublicacionHomeComponent implements OnInit {

  constructor() { }

  ngOnInit() {

    let url = window.location.href;
    if (!url.includes('='))
      window.location.href = AppConfiguration.Setting().urlServerHost + '/login-girl/';
    else {
      this.getParametros()
      this.getImagen('','',0);
    }
     
  }

  public getParametros() {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    let username = urlParams.get('user');
    let idf = urlParams.get('idf');
    $('#username').val(username);
    $('#idf').val(idf);
  }


  public getImagen(i, u, s) {

     var id = '';
     var username = '';

    if (i === '' && u === '') {
      id = $('#idf').val() as string;
      username = $('#username').val() as string;
    } else {
      id = i ;
      username = u;
    }

    $.ajax({
      type: "POST",
      url: "Aplicacion/GetImagenGirl",
      data: { id: id, username: username, sentido: s },
      dataType: "json",
      success: function (data) {
        $('#foto').attr("src", data.img64);
        $('#idf').val(data.id);
        $('#username').val(data.username);
        $("#perfil").attr("href", AppConfiguration.Setting().urlServerHost + '/cl?user=' + data.username + '&ide=' + data.identidad64);
        var usershow = username.split('-');
        $("#perfil").html('Perfil de ' + usershow[0])
      }
    });

    return false;
  }

  public getImagenSiguiente() {
    let ide = $('#idf').val() as string;
    var username = $('#username').val();

    let id = parseInt(ide) + 1;

    this.getImagen(id, username, 1);

    return false;
  }

  public getImagenAnterior()
  {
    let ide = $('#idf').val() as string ;
    var username = $('#username').val();

    let id = parseInt(ide) - 1;

    this.getImagen(id, username,2);

    return false;
  }

}
