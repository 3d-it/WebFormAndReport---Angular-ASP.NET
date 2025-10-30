import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = '/api'; // thanks to proxy.conf.js

  constructor(private http: HttpClient) { }

  // POST feedback
  submitFeedback(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/Feedbacks`, data);
  }

  // GET report
  getReport(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/ProductReviews`);
  }
}
