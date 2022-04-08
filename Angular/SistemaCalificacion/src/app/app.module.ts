import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './componentes/login/login.component';
import { NavComponent } from './componentes/nav/nav.component';
import { HomeComponent } from './componentes/home/home.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule} from '@angular/common/http';
import { DatosDocenteComponent } from './componentes/datos-docente/datos-docente.component';
import { CargarDatosComponent } from './componentes/cargar-datos/cargar-datos.component';
import { ConsultarDocenteComponent } from './componentes/consultar-docente/consultar-docente.component';
import { CalificarDocenteComponent } from './componentes/calificar-docente/calificar-docente.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavComponent,
    HomeComponent,
    DatosDocenteComponent,
    CargarDatosComponent,
    ConsultarDocenteComponent,
    CalificarDocenteComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
