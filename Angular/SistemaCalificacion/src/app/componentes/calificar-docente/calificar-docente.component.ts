import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-calificar-docente',
  templateUrl: './calificar-docente.component.html',
  styleUrls: ['./calificar-docente.component.css']
})
export class CalificarDocenteComponent implements OnInit {

  prueba:string="hola";
  constructor() { }

  ngOnInit(): void {
  }

  mostrar(){
    this.prueba= "mundo"
  };
}
