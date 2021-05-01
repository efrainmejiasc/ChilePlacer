import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import * as $ from 'jquery';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse, HttpParams } from '@angular/common/http'


@Component({
  selector: 'app-girl-completed-profile',
  templateUrl: './girl-completed-profile.component.html',
  styleUrls: ['./girl-completed-profile.component.css']
})

export class GirlCompletedProfileComponent implements OnInit {

  public imgPerfil: string;
  public nombre: string;
  public apellido: string;
  public dni: string;
  public telefono: string;
  public username: string;
  public identidad: string;
  public namefile: string;
  public msj: string;

  public progress: number;
  public message: string;

  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getImagenProfile();
  }


  public getImagenProfile() {

    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    this.identidad = urlParams.get('identidad');

    console.log(this.username);

    if (this.identidad == '' || this.identidad == null) {
      this.getIdentityUser();
      return false;
    }

    $.ajax({
      type: "POST",
      url: "Registro/GetProfileImage",
      data: { id: this.identidad },
      dataType: "json",
      success: function (data) {
        $('#foto').attr("src", data.descripcion);
      },
      complete: function () {
        console.log('GetImagenProfile');
      }
    });

    return false;
  }

  public cancelar() {
    //window.location.href = 'http://chileplacercl-001-site1.itempurl.com/';
    window.location.href = 'http://localhost:4200/';
  }

  public uploadFile = (files) => {
    if (files.length === 0) {
      return false;
    }
    this.progress = 0;
    this.getParametros();

    let fileToUpload = <File>files[0];
    $('#filename').val(fileToUpload.name);

    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.http.post('http://localhost:4200/api/UploadFileMethod', formData, { reportProgress: true, observe: 'events', params: { identidad: this.identidad }, withCredentials: false })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Exito';
          this.onUploadFinished.emit(event.body);
        }
      });

    setTimeout(this.setImageProfile, 6000);
  }

  public getParametros() {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    this.identidad = urlParams.get('identidad');

    return false;
  }

  public ocultarmensaje() {
    $('#mensaje').hide();
  }

  public mostrarMensaje(msj: string) {
    $('#msj').html('');
    $('#msj').html(msj);
    $('#mensaje').show();
    setTimeout(this.ocultarmensaje, 3000);
  }


  public SaveprofileGirls() {

    this.namefile = $('#filename').val() as string;
    this.identidad = $('#identidad').val() as string;
    var p = this.namefile.replace('_', '').split('.');
    var nameImg = p[0] + "_" + this.identidad + "." + p[1];

    if (this.nombre === '' || this.apellido === '' || this.dni === '' || this.telefono === '' || this.identidad === '') {
      this.mostrarMensaje('Todos los campos son requeridos');
      return false;
    }

    $.ajax({
      type: "POST",
      url: "Registro/CompletedRegistroGirls",
      data: { nombre: this.nombre, apellido: this.apellido, dni: this.dni, telefono: this.telefono, nameFoto: nameImg, id: this.identidad, username: this.username },
      dataType: "json",
      success: function (data) {
        $('#msj').html('');
        $('#msj').html(data.descripcion);
        $('#mensaje').show();
        setTimeout(function () { $('#mensaje').hide(); }, 3000);
        if (data.status === 'true') {
          // setTimeout(function () { window.location.href = 'http://chileplacercl-001-site1.itempurl.com/'; }, 3000);
          setTimeout(function () { window.location.href = 'http://localhost:4200/'; }, 3000);
        }
      },
      complete: function () {
        console.log('SaveProfileGirls');
      }
    });

    return false;
  }

  public setImageProfile() {
    this.namefile = $('#filename').val() as string;
    this.identidad = $('#identidad').val() as string;
    var p = this.namefile.replace('_', '').split('.');
    var nameImg = p[0] + "_" + this.identidad + "." + p[1];

    this.imgPerfil = "assets/ProfileImageGirls/" + nameImg;
    $('#foto').attr("src", "assets/ProfileImageGirls/" + nameImg);
    console.log(nameImg);

    return false;
  }

  public validarUserName() {
    let valor = $('#username').val();
    var nvalor = valor.toString();
    const soloNum = /^[0-9a]+$/;
    const soloLet = /^[aA-zZ]+$/;
    $('#msj').html('');

    if (nvalor.length > 0) {
      if (soloNum.test(nvalor) || soloLet.test(nvalor) || !nvalor.includes('-')) {
        $('#msj').html('El nombre de fantasia no cumple con el formato: Nombre seguido de guion y digitos,ej:<strong> Katerina-2210');
        $('#mensaje').show();
        setTimeout(function () { $('#mensaje').hide(); }, 3000);
        $('#username').val('');
      }

      var svalor = nvalor.split('-');
      if (!soloNum.test(svalor[1]) || !soloLet.test(svalor[0])) {
        $('#msj').html('El nombre de fantasia no cumple con el formato: Nombre seguido de guion y digitos,ej:<strong> Katerina-2210');
        $('#mensaje').show();
        setTimeout(function () { $('#mensaje').hide(); }, 3000);
        $('#username').val('');
      }

    }

    return false;
  }

  public getIdentityUser() {

    $.ajax({
      type: "POST",
      url: "Registro/GetIdentityUser",
      dataType: "json",
      success: function (data) {
        if (data === null) {
          //window.location.href = 'http://chileplacercl-001-site1.itempurl.com/login-girl/;
          window.location.href = 'http://localhost:4200/login-girl/' ;
        }
        else {

          //window.location.href = 'http://chileplacercl-001-site1.itempurl.com/girl-completed-profile?identidad=' + data.identidad;
          window.location.href = 'http://localhost:4200/girl-completed-profile?identidad=' + data.identidad;
        }
      },
      complete: function () {
        console.log('GetIdentityUser');
      }
    });

    return false;
  }

}
