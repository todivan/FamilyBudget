import { Component } from '@angular/core';
import { BudgetService } from '../../services/budget.service';
import { MatTableModule } from '@angular/material/table';
import { BudgetShare } from '../../models/budget-share';
import { FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { NgIf } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-budgetshare',
  templateUrl: './budgetshare.component.html',
  styleUrls: ['./budgetshare.component.scss'],
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatTableModule, FormsModule, ReactiveFormsModule, NgIf, MatButtonModule]
})
export class BudgetshareComponent {
  displayedColumns: string[] = ['id', 'userGuid', 'budgetId'];
  dataSource: BudgetShare[] = [];
  newId = new FormControl(0, [Validators.required]);
  newBudgetId = new FormControl(0, [Validators.required]);
  newUserGuid = new FormControl('', [Validators.required]);

  constructor(private budgetService: BudgetService) {

    budgetService.listBudgetsShare().subscribe((x) => {
      this.dataSource = x;
      console.log(x);
    });

  }

  createBudgetShare() {
    this.budgetService.createBudgetShare(this.newId.value!, this.newUserGuid.value!, this.newBudgetId.value!).subscribe(() => {

      this.budgetService.listBudgetsShare().subscribe((x) => {
        this.dataSource = x;
        console.log(x);
      });
    });
  }
}
