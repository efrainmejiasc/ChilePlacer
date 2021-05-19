import { Component, OnInit } from '@angular/core';
import { AppConfiguration } from "read-appsettings-json";
import * as $ from 'jquery';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public items = [] ;

  constructor() { }

  ngOnInit() {
    console.log(AppConfiguration.Setting().urlServerHost);
    this.getImagenesPortada();
  }


  public getImagenesPortada() {

    $('#searchUsuario').val('');
    var response = [];

    $.ajax({
      type: "POST",
      url: "Aplicacion/GetImagenesPortada",
      dataType: "json",
      success: function (data)
      {
        $.each(data, function (index, value) {
         response.push(value);
        });
      
      },
      complete: function () {
        console.log('getImagenesPortada');
      }
    });

    this.items = response;
    console.log(this.items);

    return false;
  }


  public buscarUsuario() {
    var username = $('#searchUsuario').val();
    if (username === '')
      return false;

    $.ajax({
      type: "POST",
      url: "Aplicacion/GetUsuario",
      data: {username: username},
      dataType: "json",
      success: function (data) {
        console.log(data);
        if (data === null) {
          $('#msj').html('');
          $('#msj').html( username + ' No se encuentra registrado');
          $('#mensaje').show();
          setTimeout(function () { $('#mensaje').hide(); }, 3000);
        }
        else {
          window.location.href = AppConfiguration.Setting().urlServerHost + '/cl?user=' + data.username + "&ide=" + data.identidad64;
        }
      },
      complete: function () {
        console.log('GetIdentityUser');
      }
    });

  }

  public like(id) {
    console.log(id);
  }


}
