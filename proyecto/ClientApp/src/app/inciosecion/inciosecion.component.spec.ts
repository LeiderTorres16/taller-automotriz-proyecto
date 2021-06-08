import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InciosecionComponent } from './inciosecion.component';

describe('InciosecionComponent', () => {
  let component: InciosecionComponent;
  let fixture: ComponentFixture<InciosecionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InciosecionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InciosecionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
