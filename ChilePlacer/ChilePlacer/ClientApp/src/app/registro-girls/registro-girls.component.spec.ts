import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistroGirlsComponent } from './registro-girls.component';

describe('RegistroGirlsComponent', () => {
  let component: RegistroGirlsComponent;
  let fixture: ComponentFixture<RegistroGirlsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistroGirlsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistroGirlsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
