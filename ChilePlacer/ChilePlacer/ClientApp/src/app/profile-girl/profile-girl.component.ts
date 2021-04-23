import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-profile-girl',
  templateUrl: './profile-girl.component.html',
  styleUrls: ['./profile-girl.component.css']
})
export class ProfileGirlComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    var url = window.location.href;
    if (!url.includes('='))
          this.getIdentityUser();
  }

  public getIdentityUser() {

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

          //window.location.href = 'http://chileplacercl-001-site1.itempurl.com/profile-girl?user=' + data.username;
          window.location.href = 'http://localhost:4200/profile-girl?user=' + data.username;
          console.log(data);
        }
      },
      complete: function () {
        console.log('GetIdentityUser');
      }
    });

    return false;
  }

}
