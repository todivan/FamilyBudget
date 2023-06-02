import { Component } from '@angular/core';
import { Budget } from "./models/budget";
import { BudgetService } from "./services/budget.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'FamilyBudget.Appp';

  budgets: Budget[] = [];

  constructor(private budgetService: BudgetService) { }

  ngOnInit(): void {
    this.budgetService.getBudgets().subscribe((results: Budget[]) => (this.budgets = results));
  }
}
