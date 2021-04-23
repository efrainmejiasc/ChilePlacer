import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { RegistroGirlsComponent } from './registro-girls/registro-girls.component';
import { GirlCompletedProfileComponent } from './girl-completed-profile/girl-completed-profile.component';
import { LoginGirlComponent } from './login-girl/login-girl.component';
import { CambiarPasswordComponent } from './cambiar-password/cambiar-password.component';
import { ProfileGirlComponent } from './profile-girl/profile-girl.component';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    RegistroGirlsComponent,
    GirlCompletedProfileComponent,
    LoginGirlComponent,
    CambiarPasswordComponent,
    ProfileGirlComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'registro-girls', component: RegistroGirlsComponent },
      { path: 'login-girl', component: LoginGirlComponent },
      { path: 'girl-completed-profile', component: GirlCompletedProfileComponent },
      { path: 'cambiar-password', component: CambiarPasswordComponent },
      { path: 'profile-girl', component: ProfileGirlComponent },

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
