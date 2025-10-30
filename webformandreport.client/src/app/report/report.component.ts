import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
})
export class ReportComponent implements OnInit {
  report: any[] = [];

  constructor(private api: ApiService) { }

  ngOnInit(): void {
    this.api.getReport().subscribe({
      next: (data) => (this.report = data),
      error: (err) => console.error('Error loading report:', err)
    });
  }
}
