import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent} from './componentes/login/login.component';
import { HomeComponent } from './componentes/home/home.component';
import { DatosDocenteComponent } from './componentes/datos-docente/datos-docente.component';


const routes: Routes = [
  { path: '', redirectTo: 'login' , pathMatch: 'full'},
  { path: '', pathMatch: 'full', redirectTo:'login'},
  { path: '**', pathMatch: 'full', redirectTo:'login'}, 
  { path: 'login', component: LoginComponent},
  { path: 'home', component: HomeComponent},
  { path: 'datos-docente', component: DatosDocenteComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
