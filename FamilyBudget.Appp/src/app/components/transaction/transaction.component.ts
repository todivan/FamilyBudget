import { Component } from '@angular/core';
import { BudgetService } from '../../services/budget.service';
import { MatTableModule } from '@angular/material/table';
import { Transaction } from '../../models/transaction';
import { FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { NgIf } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.scss'],
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatTableModule, FormsModule, ReactiveFormsModule, NgIf, MatButtonModule]
})
export class TransactionComponent {
  displayedColumns: string[] = ['id', 'budgetId', 'type', 'amount', 'category'];
  dataSource: Transaction[] = [];
  newId = new FormControl(0, [Validators.required]);
  newBudgetId = new FormControl(0, [Validators.required]);
  newType = new FormControl(0, [Validators.required]);
  newAmount = new FormControl(0, [Validators.required]);
  newCategory = new FormControl(0, [Validators.required]);

  constructor(private budgetService: BudgetService) {

    budgetService.listTransactions().subscribe((x) => {
      this.dataSource = x;
      console.log(x);
    });

  }

  createCategory() {
    this.budgetService.createTransaction(this.newId.value!, this.newBudgetId.value!, this.newType.value!, this.newType.value!, this.newCategory.value!).subscribe(() => {

      this.budgetService.listTransactions().subscribe((x) => {
        this.dataSource = x;
        console.log(x);
      });
    });
  }
}
