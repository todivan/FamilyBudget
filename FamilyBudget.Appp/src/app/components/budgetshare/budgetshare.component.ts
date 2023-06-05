import { Component } from '@angular/core';
import { BudgetService } from '../../services/budget.service';
import { MatTableModule } from '@angular/material/table';
import { BudgetShare } from '../../models/budget-share';

@Component({
  selector: 'app-budgetshare',
  templateUrl: './budgetshare.component.html',
  styleUrls: ['./budgetshare.component.scss'],
  standalone: true,
  imports: [MatTableModule]
})
export class BudgetshareComponent {
  displayedColumns: string[] = ['id', 'userGuid', 'budgetId'];
  dataSource: BudgetShare[] = [];

  constructor(private budgetService: BudgetService) {

    budgetService.listBudgetsShare().subscribe((x) => {
      this.dataSource = x;
      console.log(x);
    });

  }
}
