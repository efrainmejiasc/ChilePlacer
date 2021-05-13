import { Component } from '@angular/core';
import { AppConfiguration } from "read-appsettings-json";
import * as $ from 'jquery';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public navPerfil()
  {
    $.ajax({
      type: "POST",
      url: "Registro/GetIdentityUser",
      dataType: "json",
      success: function (data) {
        if (data === null) {
          window.location.href = AppConfiguration.Setting().urlServerHost + '/login-girl';
        } else {
          window.location.href = AppConfiguration.Setting().urlServerHost + '/profile-girl?user=' + data.username;
        }
      },
      complete: function () {
        console.log('NAVPERFIL');
      }
    });

    return false;
  }

}
