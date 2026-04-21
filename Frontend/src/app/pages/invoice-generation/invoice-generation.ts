import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Invoice } from '../../models/invoice';
import { ClientDetail } from '../../models/client';
import { InvoiceService } from '../../services/invoice-service';

@Component({
  selector: 'app-invoice-generation',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './invoice-generation.html',
  styleUrl: './invoice-generation.css'
})
export class InvoiceGeneration implements OnInit {
  client: ClientDetail | null = null;
  generatedInvoice: Invoice | null = null;
  isLoading = false;
  errorMessage = '';
  successMessage = '';

  constructor(
    private invoiceService: InvoiceService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const nav = this.router.getCurrentNavigation();
    const state = nav?.extras?.state as { client: ClientDetail };

    if (state?.client) {
      this.client = state.client;
    } else {
      const historyState = history.state as { client: ClientDetail };
      if (historyState?.client) {
        this.client = historyState.client;
      } else {
        this.router.navigate(['/']);
      }
    }
  }

  generateInvoice(): void {
    if (!this.client) return;

    // Reset state before every call
    this.isLoading = true;
    this.errorMessage = '';
    this.successMessage = '';
    this.generatedInvoice = null;

    this.invoiceService.generateInvoice(this.client.clientId).subscribe({
      next: (invoice) => {
        this.generatedInvoice = invoice;
        this.successMessage = 'Invoice generated successfully!';
        this.isLoading = false;
      },
      error: () => {
        this.errorMessage = 'Failed to generate invoice. Please try again.';
        this.isLoading = false;
      }
    });
  }

  goBack(): void {
    this.router.navigate(['/']);
  }

  getTaskClass(status: string): string {
    switch (status) {
      case 'completed':  return 'task-completed';
      case 'in-progress': return 'task-in-progress';
      case 'pending':    return 'task-pending';
      default: return '';
    }
  }

  getStatusClass(status: string): string {
    switch (status) {
      case 'paid':    return 'badge-paid';
      case 'unpaid':  return 'badge-unpaid';
      case 'pending': return 'badge-pending';
      default: return '';
    }
  }
}