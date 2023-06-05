import { Component } from '@angular/core';
import { BudgetService } from '../../services/budget.service';
import { MatTableModule } from '@angular/material/table';
import { Transaction } from '../../models/transaction';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.scss'],
  standalone: true,
  imports: [MatTableModule]
})
export class TransactionComponent {
  displayedColumns: string[] = ['id', 'budgetId', 'type', 'amount', 'category'];
  dataSource: Transaction[] = [];

  constructor(private budgetService: BudgetService) {

    budgetService.listTransactions().subscribe((x) => {
      this.dataSource = x;
      console.log(x);
    });

  }
}
