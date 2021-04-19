import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginGirlComponent } from './login-girl.component';

describe('LoginGirlComponent', () => {
  let component: LoginGirlComponent;
  let fixture: ComponentFixture<LoginGirlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginGirlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginGirlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
