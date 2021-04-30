import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import * as $ from 'jquery';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse, HttpParams } from '@angular/common/http'

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

    var url = window.location.href;
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
          //window.location.href = 'http://chileplacercl-001-site1.itempurl.com/login-girl/;
          window.location.href = 'http://localhost:4200/login-girl/';
        }
        else {
          if (s === 'true') {
            //window.location.href = 'http://chileplacercl-001-site1.itempurl.com/profile-girl?user=' + data.username;
            window.location.href = 'http://localhost:4200/profile-girl?user=' + data.username;
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

    setTimeout(this.getImagenes, 3000);

  }


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

    this.http.post('http://localhost:4200/api/UploadFilePublication', formData, { reportProgress: true, observe: 'events', params: { identidad: this._guid, texto: this._texto}, withCredentials: false })
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
    this.getImagenes();
  }

  public getImagenes() {

    var identidad = $('#_guid').val();
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

                           <img src = data:image/jpg;base64,${item.img64} style="width:360px;height:250px;border-radius:30%;padding:20px;"/><p></p><p></p>
                           
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
