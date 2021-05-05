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
    $('#foto').attr("src", "assets/ImagesSite/unphoto.jpg");
    this.getSexo();
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
        $('#atencion').append('<option selected disabled value="-1">Seleccione lugar de atencion...</option>');
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

    setTimeout(this.setImageProfile, 6000);
  }

  public getParametros() {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    this.identidad = urlParams.get('identidad');

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

}
