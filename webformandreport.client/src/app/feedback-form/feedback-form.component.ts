import { Component } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-feedback-form',
  templateUrl: './feedback-form.component.html',
})
export class FeedbackFormComponent {
  form = {
    name: '',
    email: '',
    product: '',
    message: ''
  };
  successMessage = '';

  constructor(private api: ApiService) { }

  submitForm() {
    this.api.submitFeedback(this.form).subscribe({
      next: () => {
        this.successMessage = 'Feedback submitted successfully!';
        this.form = { name: '', email: '', product: '', message: '' };
      },
      error: (err) => console.error('Error submitting feedback:', err)
    });
  }
}
