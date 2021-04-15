import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-registro-girls',
  templateUrl: './registro-girls.component.html',
  styleUrls: ['./registro-girls.component.css']
})
export class RegistroGirlsComponent  {

  public username: string;
  public mail: string;
  public password: string;
  public confirmaPassword: string;
  public robot: boolean;
  public msj: string;



  public getRegister()
  {
    if (this.username === '' || this.mail === '' || this.password === '' || this.confirmaPassword === '' || this.robot !== true)
    {
      this.mostrarMensaje('Todos los campos son requeridos');
      return false;
    }
    else
    {
      if (!this.emailValido(this.mail)) {
        this.mostrarMensaje('El email no es una cuenta de correo valida');
        return false;
      } else if (!this.compararCadenas(this.password, this.confirmaPassword)) {
        this.mostrarMensaje('Las contraseñas deben ser identicas');
        return false;
      }
    }

    $.ajax({
      type: "POST",
      url: "Registro/RegistroGirls",
      data: {username: this.username, mail: this.mail, password: this.password },
      dataType: "json",
      success: function (data) {
        $('#msj').html('');
        $('#msj').html(data.descripcion);
        $('#mensaje').show();
        setTimeout(function () { $('#mensaje').hide(); }, 3000);
      },
      complete: function () {
        console.log('REGITROGIRLS');
      }
    });

    return false;
  
  }

  ocultarmensaje() {
    $('#mensaje').hide();
  }

  emailValido(mail: string): boolean {
    const regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(mail);
  }

  compararCadenas(a: string, b: string) {
    if (a === b)
      return true;

    return false;
  }

  mostrarMensaje(msj: string) {
    $('#msj').html('');
    $('#msj').html(msj);
    $('#mensaje').show();
    setTimeout(this.ocultarmensaje, 3000);
  }
}
