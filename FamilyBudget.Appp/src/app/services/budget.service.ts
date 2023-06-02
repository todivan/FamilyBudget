import { Injectable } from '@angular/core';
import { Budget } from '../models/budget';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BudgetService {
  url = 'Budget'
  constructor(private http: HttpClient) { }

  public getBudgets(): Observable<Budget[]> {
    return this.http.get<Budget[]>(`${environment.apiUrl}/${this.url}`)
  }
}
