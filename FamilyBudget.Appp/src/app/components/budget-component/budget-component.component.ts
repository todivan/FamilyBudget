import { Component } from '@angular/core';
import { Budget } from '../../models/budget';
import { BudgetService } from '../../services/budget.service';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-budget-component',
  templateUrl: './budget-component.component.html',
  styleUrls: ['./budget-component.component.scss'],
  standalone: true,
  imports: [MatTableModule]
})
export class BudgetComponentComponent {
  displayedColumns: string[] = ['id', 'name', 'amount'];
  dataSource: Budget[] = [];

  constructor(private budgetService: BudgetService) {

    budgetService.listBudgets().subscribe((x) => {
      this.dataSource = x;
      console.log(x);
    });

  }
}
