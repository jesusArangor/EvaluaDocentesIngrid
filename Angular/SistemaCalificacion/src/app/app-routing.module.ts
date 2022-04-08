import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent} from './componentes/login/login.component';
import { HomeComponent } from './componentes/home/home.component';
import { DatosDocenteComponent } from './componentes/datos-docente/datos-docente.component';
import { CargarDatosComponent } from './componentes/cargar-datos/cargar-datos.component';
import { CalificarDocenteComponent } from './componentes/calificar-docente/calificar-docente.component';
import { ConsultarDocenteComponent } from './componentes/consultar-docente/consultar-docente.component';


const routes: Routes = [
  { path: '', redirectTo: 'login' , pathMatch: 'full'},
  { path: '', pathMatch: 'full', redirectTo:'login'},
  { path: '**', pathMatch: 'full', redirectTo:'login'}, 
  { path: 'login', component: LoginComponent},
  { path: 'home', component: HomeComponent},
  { path: 'datos-docente', component: DatosDocenteComponent},
  { path: 'cargar-datos', component: CargarDatosComponent},
  { path: 'calificar-docente', component: CalificarDocenteComponent},
  { path: 'consultar-docente', component: ConsultarDocenteComponent}

]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
