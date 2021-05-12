import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse, HttpParams } from '@angular/common/http'
import { AppConfiguration } from "read-appsettings-json";
import * as $ from 'jquery';

@Component({
  selector: 'app-profile-girl',
  templateUrl: './profile-girl.component.html',
  styleUrls: ['./profile-girl.component.css']
})

export class ProfileGirlComponent implements OnInit {

  public msj: string;
  public _guid: string;
  public _user: string;
  public _texto: string;

  public progress: number;
  public message: string;
  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.progress = 0; this.message = "";

   let url = window.location.href;
    if (!url.includes('='))
      this.getIdentityUser('true');
    else
      this.getIdentityUser('false');
  }

  public getIdentityUser(s) {

    $.ajax({
      type: "POST",
      url: "Registro/GetIdentityUser",
      dataType: "json",
      success: function (data) {
        if (data === null) {
          window.location.href = AppConfiguration.Setting().urlServerHost + '/login-girl/';
        }
        else {
          if (s === 'true') {
            window.location.href = AppConfiguration.Setting().urlServerHost + '/profile-girl?user=' + data.username;
            return false;
          }
          this._user = data.username; $('#_user').val(data.username);
          this._guid = data.identidad; $('#_guid').val(data.identidad);
          console.log(data);
        }
      },
      complete: function () {
        console.log('GetIdentityUser');
      }
    });

    setTimeout(this.getImagenes, 1000);
    setTimeout(this.getImageProfile, 1000);
    setTimeout(this.getProfile, 1000);


  }

  public getImageProfile() {
    let username = $('#_user').val();

    $.ajax({
      type: "POST",
      url: "Registro/ImagenProfileGirl",
      data: {username: username, opt: false},
      dataType: "json",
      success: function (data) {
        $('#_foto').attr("src", data.descripcion);
      },
      complete: function () {
        console.log('getImageProfile');
      }
    });
  }

  public getProfile() {
    const id = $('#_guid').val();

    $.ajax({
      type: "POST",
      url: "Registro/GetProfileGirl",
      data: { id: id },
      dataType: "json",
      success: function (data) {

        if (data !== null) {
          $('#_guid').val(data.identidad);
          $('#_user').val(data.username);

          $('#escort').val(data.categoriaEscort);
          $('#presentacion').val(data.presentacion);
          $('#_fechaNacimiento').val(data.strFechaNacimiento);
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

    setTimeout(this.calcularEdad, 1000);
  }


  public CurrentDate(): string {
    var d = new Date();
    var month = d.getMonth() + 1;
    var day = d.getDate();
    var currentDate = d.getFullYear() + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day
    return currentDate;
  }

  public calcularEdad() {
    console.log('Hola Mundo');
    var fechaNacimiento = $('#_fechaNacimiento').val() as string;
    var date1 = new Date(fechaNacimiento);
    var date2 = new Date(this.CurrentDate());

    var diff = (date2.getTime() - date1.getTime()) / 1000;
    diff /= (60 * 60 * 24);

    var edad = Math.abs(Math.round(diff / 365.25));
    console.log(edad);
    $('#edad').val(edad);
  }


  //subir archivo

  public uploadFile = (files) => {
    console.log('SF');

    if (files.length === 0) {
      return false;
    }
    this.progress = 0;
    this._guid = $('#_guid').val().toString();
    this._texto = $('#_texto').val().toString();

    let fileToUpload = <File>files[0];
    $('#filename').val(fileToUpload.name);

    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.http.post(AppConfiguration.Setting().urlServerHost + '/api/UploadFilePublication', formData, { reportProgress: true, observe: 'events', params: { identidad: this._guid, texto: this._texto}, withCredentials: false })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        }
        else if (event.type === HttpEventType.Response) {
          this.message = 'Exito';
          this.onUploadFinished.emit(event.body);
        }
      });

    $('#_texto').val('');
    setTimeout(this.getImagenes, 2000);
  }

  public getImagenes() {

    const identidad = $('#_guid').val();
    if (identidad === '' || identidad === null) {
      console.log('identidad no puede ser vacio')
      return false;
    }

    $.ajax({
      type: "POST",
      url: "Aplicacion/GetImagenesPerfil",
      data: {identidad: identidad},
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

  public actualizarPerfil() {
    this._guid = $('#_guid').val().toString();
    window.location.href = AppConfiguration.Setting().urlServerHost + "/girl-completed-profile?identidad=" + this._guid;
  }

}
