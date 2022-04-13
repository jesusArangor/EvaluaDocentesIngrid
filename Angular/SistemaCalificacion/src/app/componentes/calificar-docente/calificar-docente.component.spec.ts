import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalificarDocenteComponent } from './calificar-docente.component';

describe('CalificarDocenteComponent', () => {
  let component: CalificarDocenteComponent;
  let fixture: ComponentFixture<CalificarDocenteComponent>;


  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CalificarDocenteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CalificarDocenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  
});
