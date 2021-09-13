import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PayfastFormComponent } from './payfast-form.component';

describe('PayfastFormComponent', () => {
  let component: PayfastFormComponent;
  let fixture: ComponentFixture<PayfastFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PayfastFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PayfastFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
