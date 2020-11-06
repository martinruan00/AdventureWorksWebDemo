import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HumanresourcesComponent } from './humanresources.component';

describe('HumanresourcesComponent', () => {
  let component: HumanresourcesComponent;
  let fixture: ComponentFixture<HumanresourcesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HumanresourcesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HumanresourcesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
