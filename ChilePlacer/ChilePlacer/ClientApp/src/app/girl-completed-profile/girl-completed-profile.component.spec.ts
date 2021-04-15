import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GirlCompletedProfileComponent } from './girl-completed-profile.component';

describe('GirlCompletedProfileComponent', () => {
  let component: GirlCompletedProfileComponent;
  let fixture: ComponentFixture<GirlCompletedProfileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GirlCompletedProfileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GirlCompletedProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
