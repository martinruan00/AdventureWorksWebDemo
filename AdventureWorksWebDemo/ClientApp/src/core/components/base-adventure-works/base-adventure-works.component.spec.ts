import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BaseAdventureWorksComponent } from './base-adventure-works.component';

describe('BaseAdventureWorksComponent', () => {
  let component: BaseAdventureWorksComponent;
  let fixture: ComponentFixture<BaseAdventureWorksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BaseAdventureWorksComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BaseAdventureWorksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
