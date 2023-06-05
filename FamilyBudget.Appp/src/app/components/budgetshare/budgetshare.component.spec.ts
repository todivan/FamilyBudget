import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BudgetshareComponent } from './budgetshare.component';

describe('BudgetshareComponent', () => {
  let component: BudgetshareComponent;
  let fixture: ComponentFixture<BudgetshareComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BudgetshareComponent]
    });
    fixture = TestBed.createComponent(BudgetshareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
