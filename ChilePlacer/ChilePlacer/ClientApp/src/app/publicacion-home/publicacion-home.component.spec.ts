import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PublicacionHomeComponent } from './publicacion-home.component';

describe('PublicacionHomeComponent', () => {
  let component: PublicacionHomeComponent;
  let fixture: ComponentFixture<PublicacionHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PublicacionHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PublicacionHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
