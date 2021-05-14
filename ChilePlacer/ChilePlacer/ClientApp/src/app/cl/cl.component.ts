import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import * as $ from 'jquery';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse, HttpParams } from '@angular/common/http'
import { AppConfiguration } from "read-appsettings-json";

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
    setTimeout(this.getProfile, 1000);
    setTimeout(this.getImageProfile, 1000);
    setTimeout(this.getImagenes, 1000);
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

  public getProfile() {
    var id = $('#_identidad').val() as string ;

    console.log(id);

    $.ajax({
      type: "POST",
      url: "Registro/GetProfileGirl",
      data: { id: id },
      dataType: "json",
      success: function (data) {

        if (data !== null) {
          $('#_identidad').val(data.identidad);
          $('#_username').val(data.username);

          $('#escort').val(data.categoriaEscort);
          $('#presentacion').val(data.presentacion);
          $('#edad').val(data.edad);
          const ubicacion = data.country + ' - ' + data.location + ' - ' + data.sector;
          $('#ubicacion').val(ubicacion);
          $('#telefono').val(data.telefono);
          $('#valor1').val(data.valorHora);
          $('#valor2').val(data.valorMediaHora);
          $('#nacion').val(data.nacionalidad);

        }

      },
      complete: function () {
        console.log('getProfile');
      }
    });

    return false;
  }

  public getImageProfile() {
    let username = $('#_username').val();

    $.ajax({
      type: "POST",
      url: "Registro/ImagenProfileGirl",
      data: { username: username, opt: false },
      dataType: "json",
      success: function (data) {
        $('#_foto').attr("src", data.descripcion);
      },
      complete: function () {
        console.log('getImageProfile');
      }
    });
  }


  public getImagenes() {

    var identidad = $('#_identidad').val();
    if (identidad === '' || identidad === null) {
      console.log('identidad no puede ser vacio')
      return false;
    }

    $.ajax({
      type: "POST",
      url: "Aplicacion/GetImagenesPerfil",
      data: { identidad: identidad },
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
                           <a href="${item.urlProfile}" style="color:silver;float:left;display:none;"> ${item.username} </a>
 
                           <img src= ${item.img64} style="width:360px;height:250px;border-radius:30%;padding:20px;"/><p></p><p></p>
                           
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



}
