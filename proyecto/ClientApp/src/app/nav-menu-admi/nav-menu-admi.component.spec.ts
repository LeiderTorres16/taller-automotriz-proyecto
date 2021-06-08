import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavMenuAdmiComponent } from './nav-menu-admi.component';

describe('NavMenuAdmiComponent', () => {
  let component: NavMenuAdmiComponent;
  let fixture: ComponentFixture<NavMenuAdmiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavMenuAdmiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NavMenuAdmiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
