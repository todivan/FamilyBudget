import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BudgetshareComponent } from './components/budgetshare/budgetshare.component';
import { BudgetComponentComponent } from './components/budget-component/budget-component.component';
import { LoginComponent } from './components/login/login.component';
import { TransactionComponent } from './components/transaction/transaction.component';
import { UserComponent } from './components/user/user.component';


const routes: Routes = [
  { path: '', component: LoginComponent, pathMatch: 'full' },
  { path: 'budget', component: BudgetComponentComponent },
  { path: 'user', component: UserComponent },
  { path: 'transaction', component: TransactionComponent },
  { path: 'budgetshare', component: BudgetshareComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
