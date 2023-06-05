import { Component } from '@angular/core';
import { BudgetService } from '../../services/budget.service';
import { MatTableModule } from '@angular/material/table';
import { FamilyMember } from '../../models/family-member';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss'],
  standalone: true,
  imports: [MatTableModule]
})
export class UserComponent {
  displayedColumns: string[] = ['id', 'username', 'email'];
  dataSource: FamilyMember[] = [];

  constructor(private budgetService: BudgetService) {

    budgetService.listUsers().subscribe((x) => {
      this.dataSource = x;
      console.log(x);
    });

  }
}
