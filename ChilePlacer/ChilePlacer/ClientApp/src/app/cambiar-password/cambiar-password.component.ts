import { Component, OnInit } from '@angular/core';
import { AppConfiguration } from "read-appsettings-json";
import * as $ from 'jquery';

@Component({
  selector: 'app-cambiar-password',
  templateUrl: './cambiar-password.component.html',
  styleUrls: ['./cambiar-password.component.css']
})
export class CambiarPasswordComponent implements OnInit {

  public email64: string;

  constructor() { }

  ngOnInit() {
    this.getParametro();
  }

  public getParametro() {

    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    this.email64 = urlParams.get('email');
    var email = atob(this.email64);
    $('#email').val(email);
  }

  public validarPassword() {

    let valor = $('#password').val();
    var nvalor = valor.toString();
    const soloNum = /^[0-9a]+$/;
    const soloLet = /^[aA-zZ]+$/;
    $('#msj').html('');

    if (nvalor.length > 0) {
      if (soloNum.test(nvalor) || soloLet.test(nvalor)) {
        $('#msj').html('La contraseña debe contener numeros y letras');
        $('#mensaje').show();
        setTimeout(function () { $('#mensaje').hide(); }, 3000);
        $('#password').val('');
      }

      if (nvalor.length < 8) {
        $('#msj').html('La contraseña debe contener minimo ocho(8) caracteres');
        $('#mensaje').show();
        setTimeout(function () { $('#mensaje').hide(); }, 3000);
        $('#password').val('');
      }
    }

    return false;
  }

  public cancelar() {
    window.location.href = AppConfiguration.Setting().urlServerHost;
  }


  public changePassword() {

    var email = $('#email').val();
    var password = $('#password').val();
    var confirmaPassword = $('#confirmaPassword').val();
    var robot = $('#robot:checked').val();
    console.log(email);
    console.log(password);
    console.log(robot);

    if (email === '' || password === '' || confirmaPassword === '' || robot !== 'on') {
      this.mostrarMensaje('Todos los campos son requeridos');
      return false;
    }
    else {
      if (!this.compararCadenas(password.toString(), confirmaPassword.toString())) {
        this.mostrarMensaje('Las contraseñas deben ser identicas');
        return false;
      }
    }

    $.ajax({
      type: "POST",
      url: "Registro/ChangePassword",
      data: { email: email, password: password },
      dataType: "json",
      success: function (data) {
        $('#msj').html('');
        $('#msj').html(data.descripcion);
        $('#mensaje').show();
        setTimeout(function () { $('#mensaje').hide(); }, 4000);
        setTimeout(function () { window.location.href = AppConfiguration.Setting().urlServerHost; }, 3000);
      },
      complete: function () {
        console.log('Cambiar');
      }
    });

    return false;

  }

  public compararCadenas(a: string, b: string) {
    if (a === b)
      return true;

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

}
