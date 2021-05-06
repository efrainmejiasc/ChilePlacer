import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse, HttpParams } from '@angular/common/http'
import { AppConfiguration } from "read-appsettings-json";
import * as $ from 'jquery';


@Component({
  selector: 'app-girl-completed-profile',
  templateUrl: './girl-completed-profile.component.html',
  styleUrls: ['./girl-completed-profile.component.css']
})

export class GirlCompletedProfileComponent implements OnInit {

  public identidad: string;
  public namefile: string;
  public msj: string;
  public imgPerfil: string;

  public progress: number;
  public message: string;


  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http: HttpClient) { }

  ngOnInit() {
    //this.getImagenProfile();
    this.inicioDocumento();
  }

  public inicioDocumento() {
    $('#foto').attr("src", "assets/ImagesSite/unphoto.jpg");
    this.getSexo();
    this.getNacion();
    this.getEscort();
    this.getContextura();
    this.getAtencion();
    this.getServicios();
    this.getPiel();
    this.getHair();
    this.getEyes();
    this.getDrink();
    this.getSmoke();
    this.getCountry();
    this.getLocation();
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

    this.http.post(AppConfiguration.Setting().urlServerHost + '/api/UploadFileMethod', formData, { reportProgress: true, observe: 'events', params: { identidad: this.identidad }, withCredentials: false })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Exito';
          this.onUploadFinished.emit(event.body);
        }
      });

    setTimeout(this.setImageProfile, 3000);
  }

  public getParametros() {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    let guid = urlParams.get('identidad');
    this.identidad = guid;
    $('#identidad').val();
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

  public cancelar() {
    window.location.href = AppConfiguration.Setting().urlServerHost;
  }

  // Vallidaciones de perfil

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

  //Guardar perfil

  public SaveprofileGirls() {

    this.namefile = $('#filename').val() as string;
    this.identidad = $('#identidad').val() as string;
    var p = this.namefile.replace('_', '').split('.');
    var nameImg = p[0] + "_" + this.identidad + "." + p[1];

    var nombre = $('#nombre').val();
    var apellido = $('#apellido').val();
    var telefono = $('#telefono').val();
    var fechaNacimiento = $('#fechaNacimiento').val();
    var dni = $('#dni').val();
    var sexo = $('#sexo').val();

    var username = $('#username').val();
    var presentacion = $('#presentacion').val();
    var descripcion = $('#descripcion').val();
    var escort = $('#escort').val();
    var atencion = $('#atencion').val();
    var servicios = $('#servicios').val();
    var valor1 = $('#valor1').val();
    var valor2 = $('#valor2').val();
    var drink = $('#drink').val();
    var smoke = $('#smoke').val();

    var estatura = $('#estatura').val();
    var peso = $('#peso').val();
    var medidas = $('#medidas').val();
    var contextura = $('#contextura').val();
    var piel = $('#piel').val();
    var hair = $('#hair').val();
    var eyes = $('#eyes').val();

    var country = $('#country').val();
    var location = $('#location').val();
    var sector = $('#sector').val();

    if (sexo == '') {
      this.mostrarMensaje('El campo sexo es requerido');
      return false;
    }
    else if (username == '') {
      this.mostrarMensaje('El campo nombre de fantasia es requerido');
      return false;
    }
    else if (presentacion == '') {
      this.mostrarMensaje('El campo presentacion es requerido');
      return false;
    }
    else if (descripcion == '') {
      this.mostrarMensaje('El campo descripcion es requerido');
      return false;
    }
    else if (escort == '') {
      this.mostrarMensaje('El campo tipo escort es requerido');
      return false;
    }
    else if (atencion == '') {
      this.mostrarMensaje('El campo lugares de atencion es requerido');
      return false;
    }
    else if (servicios == '') {
      this.mostrarMensaje('El campo opciones de servicio es requerido');
      return false;
    }
    else if (drink == '') {
      this.mostrarMensaje('El campo opciones de alchol es requerido');
      return false;
    }
    else if (smoke == '') {
      this.mostrarMensaje('El campo opciones de tabaco es requerido');
      return false;
    }
    else if (estatura == '') {
      this.mostrarMensaje('El campo es estatura requerido');
      return false;
    }
    else if (peso == '') {
      this.mostrarMensaje('El campo es peso requerido');
      return false;
    }
    else if (medidas == '') {
      this.mostrarMensaje('El campo medidas es requerido');
      return false;
    }
    else if (contextura == '') {
      this.mostrarMensaje('El campo contextura es requerido');
      return false;
    }
    else if (piel == '') {
      this.mostrarMensaje('El campo color de piel es requerido');
      return false;
    }
    else if (hair == '') {
      this.mostrarMensaje('El campo color de cabello es requerido');
      return false;
    }
    else if (eyes == '') {
      this.mostrarMensaje('El campo color de ojos  es requerido');
      return false;
    }

    else if (country == '') {
      this.mostrarMensaje('El campo pais es requerido');
      return false;
    }
    else if (location == '') {
      this.mostrarMensaje('El campo  ubicacion es requerido');
      return false;
    }
    else if (sector == '') {
      this.mostrarMensaje('El campo sector/barrio es requerido');
      return false;
    }

    console.log(nameImg)

    if (p[0] === '' || p[1] === '')
      nameImg = '';

    $.ajax({
      type: "POST",
      url: "Registro/CompletedRegistroGirls",
      data: {} ,
      dataType: "json",
      success: function (data) {
        $('#msj').html('');
        $('#msj').html(data.descripcion);
        $('#mensaje').show();
        setTimeout(function () { $('#mensaje').hide(); }, 3000);
      },
      complete: function () {
        console.log('SaveProfileGirls');
      }
    });

    return false;
  }

  public mostrarMensaje(msj: string) {
    $('#msj').html('');
    $('#msj').html(msj);
    $('#mensaje').show();
    setTimeout(this.ocultarmensaje, 3000);
  }

  public ocultarmensaje() {
    $('#mensaje').hide();
  }

  // Funciones catalogos

  public getNacion() {

    $.ajax({
      type: "POST",
      url: "Registro/GetNacionalidad",
      dataType: "json",
      success: function (data) {
        $("#nacion").empty();
        $('#nacion').append('<option selected disabled value="-1">Seleccione nacionalidad...</option>');
        $.each(data, function (index, value) {
          $('#nacion').append('<option  value="' + value.ide + '">' + value.nacionalidad + '</option>');
        });
      }
    });

    return false;
  }

  public getSexo() {

    $.ajax({
      type: "POST",
      url: "Registro/GetSexo",
      dataType: "json",
      success: function (data) {
        $("#sexo").empty();
        $('#sexo').append('<option selected disabled value="-1">Seleccione sexo...</option>');
        $.each(data, function (index, value) {
          $('#sexo').append('<option  value="' + value.ide + '">' + value.sexo + '</option>');
        });
      }
    });

    return false;
  }

  public getEscort() {

    $.ajax({
      type: "POST",
      url: "Registro/GetEscort",
      dataType: "json",
      success: function (data) {
        $("#escort").empty();
        $('#escort').append('<option selected disabled value="-1">Seleccione categoria escort...</option>');
        $.each(data, function (index, value) {
          $('#escort').append('<option  value="' + value.ide + '">' + value.categoria + '</option>');
        });
      }
    });

    return false;
  }


  public getContextura() {

    $.ajax({
      type: "POST",
      url: "Registro/GetContextura",
      dataType: "json",
      success: function (data) {
        $("#contextura").empty();
        $('#contextura').append('<option selected disabled value="-1">Seleccione contextura...</option>');
        $.each(data, function (index, value) {
          $('#contextura').append('<option  value="' + value.ide + '">' + value.contextura + '</option>');
        });
      }
    });

    return false;
  }


  public getPiel() {

    $.ajax({
      type: "POST",
      url: "Registro/GetPiel",
      dataType: "json",
      success: function (data) {
        $("#piel").empty();
        $('#piel').append('<option selected disabled value="-1">Seleccione color de piel...</option>');
        $.each(data, function (index, value) {
          $('#piel').append('<option  value="' + value.ide + '">' + value.piel + '</option>');
        });
      }
    });

    return false;
  }

  public getEyes() {

    $.ajax({
      type: "POST",
      url: "Registro/GetEyes",
      dataType: "json",
      success: function (data) {
        $("#eyes").empty();
        $('#eyes').append('<option selected disabled value="-1">Seleccione color de ojos...</option>');
        $.each(data, function (index, value) {
          $('#eyes').append('<option  value="' + value.ide + '">' + value.ojos + '</option>');
        });
      }
    });

    return false;
  }

  public getHair() {

    $.ajax({
      type: "POST",
      url: "Registro/GetHair",
      dataType: "json",
      success: function (data) {
        $("#hair").empty();
        $('#hair').append('<option selected disabled value="-1">Seleccione color de cabello...</option>');
        $.each(data, function (index, value) {
          $('#hair').append('<option  value="' + value.ide + '">' + value.colorCabello + '</option>');
        });
      }
    });

    return false;
  }

  public getDrink() {

    $.ajax({
      type: "POST",
      url: "Registro/GetDrink",
      dataType: "json",
      success: function (data) {
        $("#drink").empty();
        $('#drink').append('<option selected disabled value="-1">Seleccione...</option>');
        $.each(data, function (index, value) {
          $('#drink').append('<option  value="' + value.ide + '">' + value.drink + '</option>');
        });
      }
    });

    return false;
  }

  public getSmoke() {

    $.ajax({
      type: "POST",
      url: "Registro/GetSmoke",
      dataType: "json",
      success: function (data) {
        $("#smoke").empty();
        $('#smoke').append('<option selected disabled value="-1">Seleccione...</option>');
        $.each(data, function (index, value) {
          $('#smoke').append('<option  value="' + value.ide + '">' + value.smoke + '</option>');
        });
      }
    });

    return false;
  }

  public getAtencion() {

    $.ajax({
      type: "POST",
      url: "Registro/GetAtencion",
      dataType: "json",
      success: function (data) {
        $("#atencion").empty();
        $.each(data, function (index, value) {
          $('#atencion').append('<option  value="' + value.ide + '">' + value.atencion + '</option>');
        });
      }
    });

    return false;
  }

  public getServicios() {

    $.ajax({
      type: "POST",
      url: "Registro/GetServicios",
      dataType: "json",
      success: function (data) {
        $("#servicios").empty();
        $.each(data, function (index, value) {
          $('#servicios').append('<option  value="' + value.ide + '">' + value.servicio + '</option>');
        });
      }
    });

    return false;
  }

  public getCountry() {

    $.ajax({
      type: "POST",
      url: "Registro/GetCountry",
      dataType: "json",
      success: function (data) {
        $("#country").empty();
        $.each(data, function (index, value) {
          $('#country').append('<option  value="' + value.ide + '">' + value.pais + '</option>');
        });
      }
    });

    return false;
  }


  public getLocation() {

    $.ajax({
      type: "POST",
      url: "Registro/GetLocation",
      dataType: "json",
      success: function (data) {
        $("#location").empty();
        $('#location').append('<option selected disabled value="-1">Seleccione ubicacion...</option>');
        $.each(data, function (index, value) {
          $('#location').append('<option  value="' + value.ide + '">' + value.location + '</option>');
        });
      }
    });

    return false;
  }

 




  




}
