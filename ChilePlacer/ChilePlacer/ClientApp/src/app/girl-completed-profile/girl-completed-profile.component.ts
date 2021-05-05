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
        $('#contextura').append('<option selected disabled value="-1">Seleccione  contextura...</option>');
        $.each(data, function (index, value) {
          $('#contextura').append('<option  value="' + value.ide + '">' + value.contextura + '</option>');
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
