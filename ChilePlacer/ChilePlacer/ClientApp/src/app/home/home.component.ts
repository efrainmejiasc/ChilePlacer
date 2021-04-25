
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
      url: "Aplicacion/GetImagenesPortada",
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
                           <a href="${item.urlProfile}" style="color:silver;"> ${item.username} </a>
                           <img src= ${item.pathImagen} style="widt:15%;height:10%;"/>
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

