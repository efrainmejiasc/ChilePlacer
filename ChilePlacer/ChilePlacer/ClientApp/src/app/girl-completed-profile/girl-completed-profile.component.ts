import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import * as $ from 'jquery';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http'

@Component({
  selector: 'app-girl-completed-profile',
  templateUrl: './girl-completed-profile.component.html',
  styleUrls: ['./girl-completed-profile.component.css']
})
export class GirlCompletedProfileComponent implements OnInit {
  public imgPerfil = "assets/ImagesSite/unphoto.jpg";
  public nombre: string;
  public apellido: string;
  public dni: string;
  public telefono: string;
  public username: string;
  public identidad: string;

  public progress: number;
  public message: string;
  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  public cancelar() {
    window.location.href = 'http://localhost:4200';
  }

  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.http.post('http://localhost:4200/api/UploadFileMethod', formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(event.body);
        }
      });
  }

 public getParametros() {
  const queryString = window.location.search;
  const urlParams = new URLSearchParams(queryString);
  this.username = urlParams.get('username')
  this.identidad = urlParams.get('identidad')

 }

}
