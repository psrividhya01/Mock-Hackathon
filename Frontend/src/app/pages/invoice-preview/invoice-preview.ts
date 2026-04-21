import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Invoice } from '../../models/invoice';
import { ClientDetail } from '../../models/client';

@Component({
  selector: 'app-invoice-preview',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './invoice-preview.html',
  styleUrl: './invoice-preview.css'
})
export class InvoicePreview implements OnInit {
  invoice: Invoice | null = null;
  client: ClientDetail | null = null;

  // Your company details — replace with real values or pull from config
  company = {
    name: 'Your Company Name',
    address: 'Your Business Address',
    city: 'City',
    country: 'Country',
    postal: 'Postal'
  };

  constructor(private router: Router) {}

  ngOnInit(): void {
    const state = history.state as { invoice: Invoice; client: ClientDetail };
    if (state?.invoice && state?.client) {
      this.invoice = state.invoice;
      this.client = state.client;
      this.router.navigate(['/invoice-preview'], { state: { invoice: this.invoice, client: this.client } });
    } else {
      // TEMP dummy data — remove before production
      this.loadDummyData();
    }
  }

  // TEMP: Remove before production
  loadDummyData(): void {
    this.client = {
      clientId: 'CLIENT-001',
      clientName: 'Arjun Sharma',
      email: 'arjun.sharma@gmail.com',
      
      hourlyrate: 50,
      task: [
        {
          taskId: 1, taskName: 'Design Landing Page', description: 'UI/UX design for main landing page', amount: 15000, status: 'completed',
          hoursWorked: 0,
          clientId: 0
        },
        {
          taskId: 2, taskName: 'API Integration', description: 'Connect frontend with REST APIs', amount: 20000, status: 'completed',
          hoursWorked: 0,
          clientId: 0
        },
        {
          taskId: 3, taskName: 'Testing & QA', description: 'Full regression and QA testing', amount: 10000, status: 'completed',
          hoursWorked: 0,
          clientId: 0
        }
      ]
    };

    this.invoice = {
      invoiceId: 1,
      clientId: 'CLIENT-001',
      clientName: 'Arjun Sharma',
      totalAmount: 45000,
      status: 'unpaid',
      createdDate: new Date().toISOString()
    };
  }

  getTotalAmount(): number {
    return this.client?.task?.reduce((sum, t) => sum + (t.amount || 0), 0) ?? 0;
  }

  getDueDate(): string {
    if (!this.invoice?.createdDate) return '';
    const date = new Date(this.invoice.createdDate);
    date.setDate(date.getDate() + 30);
    return date.toLocaleDateString('en-GB', { day: '2-digit', month: '2-digit', year: '2-digit' });
  }

  printInvoice(): void {
    window.print();
  }

  goBack(): void {
    this.router.navigate(['/invoice/generate'], {
      state: { client: this.client }
    });
  }
}