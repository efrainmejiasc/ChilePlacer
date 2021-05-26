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
        $('#00').attr("src", data[0].img64); $('#01').attr("src", data[1].img64); $('#02').attr("src", data[2].img64); $('#03').attr("src", data[3].img64);
        $('#10').attr("src", data[4].img64); $('#11').attr("src", data[5].img64); $('#12').attr("src", data[6].img64); $('#13').attr("src", data[7].img64);
        $('#20').attr("src", data[8].img64); $('#21').attr("src", data[9].img64); $('#22').attr("src", data[10].img64); $('#23').attr("src", data[11].img64);
        $('#30').attr("src", data[12].img64); $('#31').attr("src", data[13].img64); $('#32').attr("src", data[14].img64); $('#33').attr("src", data[15].img64);

        $('#00l').attr("href", data[0].urlProfile); $('#01l').attr("href", data[1].urlProfile); $('#02l').attr("href", data[2].urlProfile); $('#03l').attr("href", data[3].urlProfile);
        $('#10l').attr("href", data[4].urlProfile); $('#11l').attr("href", data[5].urlProfile); $('#12l').attr("href", data[6].urlProfile); $('#13l').attr("href", data[7].urlProfile);
        $('#20l').attr("href", data[8].urlProfile); $('#21l').attr("href", data[9].urlProfile); $('#22l').attr("href", data[10].urlProfile); $('#23l').attr("href", data[11].urlProfile);
        $('#30l').attr("href", data[12].urlProfile); $('#31l').attr("href", data[13].urlProfile); $('#32l').attr("href", data[14].urlProfile); $('#33l').attr("href", data[15].urlProfile);

        $('#00l').html(data[0].usershow); $('#01l').html(data[1].usershow); $('#02l').html(data[2].usershow); $('#03l').html(data[3].usershow);
        $('#10l').html(data[4].usershow); $('#11l').html(data[5].usershow); $('#12l').html(data[6].usershow); $('#13l').html(data[7].usershow);
        $('#20l').html(data[8].usershow); $('#21l').html(data[9].usershow); $('#22l').html(data[10].usershow); $('#23l').html(data[11].usershow);
        $('#30l').html(data[12].usershow); $('#31l').html(data[13].usershow); $('#32l').html(data[14].usershow); $('#33l').html(data[15].usershow);

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
