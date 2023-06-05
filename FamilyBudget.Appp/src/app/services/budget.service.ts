import { Injectable } from '@angular/core';
import { Budget } from '../models/budget';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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
  header: HttpHeaders;
  
  constructor(private http: HttpClient) {
    const token = localStorage.getItem('token');

    this.header = new HttpHeaders({
      'Authorization': 'Bearer ' + token,
      'Content-Type': 'application/json'
    });
  }

  public doLogin(email: string, password: string): Observable<any> {
    const options = { email, password }

    return this.http.post<any>(`${environment.apiUrl}/Authentication/Login`, options);
  }

  public listBudgets(): Observable<Budget[]>  {

    return this.http.get<Budget[]>(`${environment.apiUrl}/budget`, {
      headers: this.header
    });
  }

  public listBudgetsShare(): Observable<BudgetShare[]> {

    return this.http.get<BudgetShare[]>(`${environment.apiUrl}/budgetshare`, {
      headers: this.header
    });
  }

  public listUsers(): Observable<FamilyMember[]> {

    return this.http.get<FamilyMember[]>(`${environment.apiUrl}/authentication/list`, {
      headers: this.header
    });
  }

  public listTransactions(): Observable<Transaction[]> {

    return this.http.get<Transaction[]>(`${environment.apiUrl}/transaction`, {
      headers: this.header
    });
  }
}
