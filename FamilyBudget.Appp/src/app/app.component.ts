import { Component } from '@angular/core';
import { Budget } from "./models/budget";
import { BudgetService } from "./services/budget.service";
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'FamilyBudget.Appp';

  budgets: Budget[] = [];

  constructor(private budgetService: BudgetService, private router: Router) { }

  ngOnInit(): void {
    //this.budgetService.getBudgets().subscribe((results: Budget[]) => (this.budgets = results));
  }
}
