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
   // window.location.href = 'http://chileplacercl-001-site1.itempurl.com/';
    window.location.href = 'http://localhost:4200/';
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
        //setTimeout(function () { window.location.href = 'http://chileplacercl-001-site1.itempurl.com/'; }, 3000);
        setTimeout(function () { window.location.href = 'http://localhost:4200/'; }, 3000);

      },
      complete: function () {
        console.log('LoginGIRLS');
      }
    });

    return false;

  }

 public olvidoPassword() {
   $('#olvido').show();
  }

  public cerrarOlvido() {
    $('#olvido').hide();
  }

  public getCodigo() {

    var _mail = $('#_mail').val();

    if (_mail === '') {
      $('#_mensaje').css("color", "red");
      $('#_mensaje').html('Ingresa tu cuenta de correo');
      $('#_msj').show();
      setTimeout(function () { $('#_msj').hide(); }, 4000);

      return false;
    }

    if (!this.emailValido(_mail.toString())) {
      $('#_mensaje').css("color", "red");
      $('#_mensaje').html('El email no es una direccion valida');
      $('#_msj').show();
      setTimeout(function () { $('#_msj').hide(); }, 4000);
      return false;
    }

    $.ajax({
      type: "POST",
      url: "Registro/SendMailChangePassword",
      data: { email: _mail },
      dataType: "json",
      success: function (data) 
      {
        if (data.status === 'true')
        {
          $('#_mensaje').css("color", "green");
          $('#_mensaje').html(data.descripcion);
          $('#_msj').show();
          setTimeout(function() { $('#_msj').hide(); }, 4000);
        }
        else {
          $('#_mensaje').css("color", "red");
          $('#_mensaje').html(data.descripcion);
          $('#_msj').show();
          setTimeout(function() { $('#_msj').hide(); }, 3000);
          $('#olvido').hide();
          return false;
        }
      }
     ,
      complete: function () {
        console.log('SendEmail');
      }
    });

    return false;
  }

  public haveCodigo() {
    $('#_mensaje').css("color", "green");
    $('#_mensaje').html('Ingresa tu correo y el codigo, click en Enviar');
    $('#_msj').show();
    setTimeout(function () { $('#_msj').hide(); }, 4000);
  }

  public validarCodigo() {

    var _mail = $('#_mail').val();
    var _codigo =  $('#_codigo').val();

    if (_mail === '' || _codigo === '') {
      $('#_mensaje').css("color", "red");
      $('#_mensaje').html('Todos los campos son requeridos');
      $('#_msj').show();
      setTimeout(function () { $('#_msj').hide(); }, 4000);

      return false;
    }


    if (!this.emailValido(_mail.toString())) {
      $('#_mensaje').css("color", "red");
      $('#_mensaje').html('El email no es una direccion valida');
      $('#_msj').show();
      setTimeout(function () { $('#_msj').hide(); }, 4000);
      return false;
    }

    $.ajax({
      type: "POST",
      url: "Registro/ValidarCodigoChangePassword ",
      data: { email: _mail , codigo: _codigo},
      dataType: "json",
      success: function (data) {
        if (data.status === 'true') {
          var parametro = '?email='+ data.email
          //setTimeout(function () { window.location.href = 'http://chileplacercl-001-site1.itempurl.com/cambiar-password/' + parametro; }, 3000);
          setTimeout(function () { window.location.href = 'http://localhost:4200/cambiar-password/' + parametro; }, 3000);
        }
        else {
          $('#_mensaje').css("color", "red");
          $('#_mensaje').html(data.descripcion);
          $('#_msj').show();
          setTimeout(function () { $('#_msj').hide(); }, 3000);
          return false;
        }
      }
      ,
      complete: function () {
        console.log('SendEmail');
      }
    });

    return false;

  }

  public emailValido(mail: string): boolean {
    const regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(mail);
  }


}
