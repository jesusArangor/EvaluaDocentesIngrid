import { CursorError } from '@angular/compiler/src/ml_parser/lexer';
import { Component, OnInit } from '@angular/core';
import { EmailValidator, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-datos-docente',
  templateUrl: './datos-docente.component.html',
  styleUrls: ['./datos-docente.component.css']
})
export class DatosDocenteComponent implements OnInit {

  title = 'DatosDocente';
  public formDatos!: FormGroup;

  constructor(private FormBuilder: FormBuilder) { 

  }

  ngOnInit(): void {
    this.formDatos = this.FormBuilder.group({
      documento: ['',[Validators.required, Validators.requiredTrue]],
      nombre: ['',[Validators.required, Validators.name]],
      correo: ['',[Validators.required, Validators.email]],
      telefono: ['',[Validators.required]]
    });
  }

  send(): any {
    console.log(this.formDatos.value);
  }

}


