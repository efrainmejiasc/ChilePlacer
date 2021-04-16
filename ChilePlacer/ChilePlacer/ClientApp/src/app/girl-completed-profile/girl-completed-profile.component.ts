import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-girl-completed-profile',
  templateUrl: './girl-completed-profile.component.html',
  styleUrls: ['./girl-completed-profile.component.css']
})
export class GirlCompletedProfileComponent implements OnInit {
  public imgPerfil = "assets/ImagesSite/unphoto.jpg";
  public nombre: string;
  public apellido: string;
  public dni: string;
  public telefono: string;

  constructor() { }

  ngOnInit() {
  }

  public cancelar() {
    window.location.href = 'http://localhost:4200';
  }
}
