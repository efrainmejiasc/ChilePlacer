
import { Component, OnInit } from '@angular/core';
import { AppConfiguration } from "read-appsettings-json";
import * as $ from 'jquery';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  constructor() { }

  ngOnInit() {
    console.log(AppConfiguration.Setting().urlServerHost);
    console.log(window.location.pathname);
    this.getImagenesPortada()
  }


  public getImagenesPortada() {
   
    $.ajax({
      type: "POST",
      url: "Aplicacion/GetImagenesPortada",
      dataType: "json",
      success: function (data) {
        console.log(data);
        $("#tablaPortada thead tr").remove();
        $('#tablaPortada tbody tr').remove();

        let title = `<tr>
                        <th> </th>
                      </tr>`;

        $("#tablaPortada thead").append(title);

        $.each(data, function (index, item) {
          let tr = `<tr> 
                      <td>
                           <a href="${item.urlProfile}" style="color:silver;float:left;"> ${item.username} </a>

                          <img src= ${item.pathImagen} style="width:360px;height:250px;border-radius:30%;padding:20px;"/><p></p><p></p>
                           
                           <label id=${item.id}> ${item.texto} <label>
                      </td>
                      </tr>`;
          $('#tablaPortada tbody').append(tr);
        });
      },
      complete: function () {
        console.log('GetIdentityUser');
      }
    });

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
          window.location.href = AppConfiguration.Setting().urlServerHost + '/cl?user=' + data.username;
        }
      },
      complete: function () {
        console.log('GetIdentityUser');
      }
    });

  }


}
