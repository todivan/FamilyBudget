import { Component } from '@angular/core';
import { Budget } from '../../models/budget';
import { BudgetService } from '../../services/budget.service';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormControl, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgIf } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-budget-component',
  templateUrl: './budget-component.component.html',
  styleUrls: ['./budget-component.component.scss'],
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatTableModule, FormsModule, ReactiveFormsModule, NgIf, MatButtonModule]
})
export class BudgetComponentComponent {
  displayedColumns: string[] = ['id', 'name', 'amount'];
  dataSource: Budget[] = [];
  newId = new FormControl(0, [Validators.required]);
  newName = new FormControl('', [Validators.required]);
  newAmount = new FormControl(0, [Validators.required]);

  constructor(private budgetService: BudgetService) {

    budgetService.listBudgets().subscribe((x) => {
      this.dataSource = x;
      console.log(x);
    });
  }

  createBudget() {
    this.budgetService.createBudget(this.newId.value!, this.newName.value!, this.newAmount.value!).subscribe(() => {

      this.budgetService.listBudgets().subscribe((x) => {
        this.dataSource = x;
        console.log(x);
      });
    });
  }
}
