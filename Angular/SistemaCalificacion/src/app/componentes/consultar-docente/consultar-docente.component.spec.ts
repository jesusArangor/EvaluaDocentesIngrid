import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultarDocenteComponent } from './consultar-docente.component';

describe('ConsultarDocenteComponent', () => {
  let component: ConsultarDocenteComponent;
  let fixture: ComponentFixture<ConsultarDocenteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsultarDocenteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultarDocenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
