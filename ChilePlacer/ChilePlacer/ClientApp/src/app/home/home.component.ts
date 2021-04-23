
import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{

  constructor() { }

  ngOnInit() {

    console.log(window.location.pathname);
    this.getImagenesPortada() 
  }


  public getImagenesPortada() {

    $.ajax({
      type: "POST",
      url: "Aplicacion/GetImagenesPortada(",
      dataType: "json",
      success: function (data) {
        this.tablaPortada();
      },
      complete: function () {
        console.log('GetIdentityUser');
      }
    });

    return false;
  }


  public tablaPortada(emp) {
    $("#tablaPortada thead tr").remove();
    $('#tablaPortada tbody tr').remove();

    let title = `<tr>
                        <th> Id </th>
                        <th> IdGirls </th>
                        <th> PathImagen </th>
               </tr>`;

    $("#tablaPortada thead").append(title); 
   
    $.each(emp, function (index, item) {
      let tr = `<tr> 
                      <td> ${item.Id} </td>
                      <td> ${item.IdGirls} </td>
                      <td> ${item.PathImagen}</td>
                      </tr >`;
      $('#tablaPortada tbody').append(tr);
    });
  }


}

