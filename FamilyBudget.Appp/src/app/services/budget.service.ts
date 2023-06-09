import { Injectable } from '@angular/core';
import { Budget } from '../models/budget';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FamilyMember } from '../models/family-member';
import { Transaction } from '../models/transaction';
import { BudgetShare } from '../models/budget-share';

@Injectable({
  providedIn: 'root'
})
export class BudgetService {
  url = 'Budget';
  
  constructor(private http: HttpClient) {

  }

  public doLogin(email: string, password: string): Observable<any> {
    const options = { email, password }

    return this.http.post<any>(`${environment.apiUrl}/Authentication/Login`, options);
  }

  public doRegister(name: string, email: string, password: string): Observable<any> {
    const options = { name, email, password }

    return this.http.post<any>(`${environment.apiUrl}/Authentication/Register`, options);
  }

  public listBudgets(): Observable<Budget[]>  {

    return this.http.get<Budget[]>(`${environment.apiUrl}/budget`);
  }

  public listBudgetsShare(): Observable<BudgetShare[]> {

    return this.http.get<BudgetShare[]>(`${environment.apiUrl}/budgetshare`);
  }

  public listUsers(): Observable<FamilyMember[]> {

    return this.http.get<FamilyMember[]>(`${environment.apiUrl}/authentication/list`);
  }

  public listTransactions(): Observable<Transaction[]> {

    return this.http.get<Transaction[]>(`${environment.apiUrl}/transaction`);
  }

  public createBudget(id: number, name: string, amount: number): Observable<any> {
    const options = { id, name, amount }

    return this.http.post<any>(`${environment.apiUrl}/budget`, options);
  }

  public createTransaction(id: number, budetId: number, type: number, amount: number, category:number): Observable<any> {
    const options = { id, budetId, type, amount, category }

    return this.http.post<any>(`${environment.apiUrl}/transaction`, options);
  }

  public createBudgetShare(id: number, userGuid: string, budetId: number): Observable<any> {
    const options = { id, userGuid, budetId }

    return this.http.post<any>(`${environment.apiUrl}/budgetshare`, options);
  }
}
