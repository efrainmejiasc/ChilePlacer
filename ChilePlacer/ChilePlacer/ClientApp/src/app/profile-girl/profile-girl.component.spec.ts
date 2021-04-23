import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileGirlComponent } from './profile-girl.component';

describe('ProfileGirlComponent', () => {
  let component: ProfileGirlComponent;
  let fixture: ComponentFixture<ProfileGirlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfileGirlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileGirlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
