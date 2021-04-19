import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-login-girl',
  templateUrl: './login-girl.component.html',
  styleUrls: ['./login-girl.component.css']
})
export class LoginGirlComponent implements OnInit {


  public mail: string;
  public password: string;
  public robot: boolean;
  public msj: string;

  constructor() { }

  ngOnInit() {
  }


  public cancelar() {
    window.location.href = 'http://chileplacercl-001-site1.itempurl.com/';
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

  public loginGirls() {
    if (this.mail === '' || this.password === '' || this.robot !== true) {
      this.mostrarMensaje('Todos los campos son requeridos');
      return false;
    }

    $.ajax({
      type: "POST",
      url: "Registro/LoginGirls",
      data:  { email: this.mail, password: this.password },
      dataType: "json",
      success: function (data) {
        $('#msj').html('');
        $('#msj').html(data.descripcion);
        $('#mensaje').show();
        setTimeout(function () { $('#mensaje').hide(); }, 3000);
        setTimeout(function () { window.location.href = 'http://chileplacercl-001-site1.itempurl.com/'; }, 3000);

      },
      complete: function () {
        console.log('LoginGIRLS');
      }
    });

    return false;

  }

}
