import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-registro-girls',
  templateUrl: './registro-girls.component.html',
  styleUrls: ['./registro-girls.component.css']
})
export class RegistroGirlsComponent  {

  public mail: string;
  public password: string;
  public confirmaPassword: string;
  public robot: boolean;
  public msj: string;



  public getRegister()
  {
    if (this.mail === '' || this.password === '' || this.confirmaPassword === '' || this.robot !== true)
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
      data: { mail: this.mail, password: this.password },
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
        console.log('REGITROGIRLS');
      }
    });

    return false;
  
  }

  public ocultarmensaje() {
    $('#mensaje').hide();
  }

  public emailValido(mail: string): boolean {
    const regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(mail);
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

  public cancelar() {
    //window.location.href = 'http://chileplacercl-001-site1.itempurl.com/';
    window.location.href = 'http://localhost:4200/';
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


}
