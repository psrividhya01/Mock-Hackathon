import { Component } from '@angular/core';
import { Invoice } from '../../models/invoice';
import { InvoiceService } from '../../services/invoice-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-invoice-list',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './invoice-list.html',
  styleUrl: './invoice-list.css',
})
export class InvoiceList {
   invoices: Invoice[] = [];
  filteredInvoices: Invoice[] = [];
  isLoading = false;
  errorMessage = '';
  filterClientName = '';
  successMessage = '';

  constructor(private invoiceService: InvoiceService) {}

  ngOnInit(): void {
    this.loadAllInvoices();
  }

  loadAllInvoices(): void {
    this.isLoading = true;
    this.errorMessage = '';
    this.invoiceService.getAllInvoices().subscribe({
      next: (data) => {
        this.invoices = data;
        this.filteredInvoices = data;
        this.isLoading = false;
      },
      error: (err) => {
        this.errorMessage = 'Failed to load invoices. Please try again.';
        this.isLoading = false;
      }
    });
  }

  filterByClient(): void {
    if (!this.filterClientName.trim()) {
      this.filteredInvoices = this.invoices;
      return;
    }
    this.isLoading = true;
    this.invoiceService.getInvoiceByClient(this.filterClientName.trim()).subscribe({
      next: (data) => {
        this.filteredInvoices = data;
        this.isLoading = false;
      },
      error: (err) => {
        this.errorMessage = 'No invoices found for this client.';
        this.filteredInvoices = [];
        this.isLoading = false;
      }
    });
  }

  clearFilter(): void {
    this.filterClientName = '';
    this.filteredInvoices = this.invoices;
    this.errorMessage = '';
  }

  markAsPaid(invoiceId: string): void {
    this.invoiceService.markAsPaid(invoiceId).subscribe({
      next: (updated) => {
        const index = this.filteredInvoices.findIndex(inv => inv.invoiceId.toString() === invoiceId);
        if (index !== -1) {
          this.filteredInvoices[index] = updated;
        }
        const masterIndex = this.invoices.findIndex(inv => inv.invoiceId.toString() === invoiceId);
        if (masterIndex !== -1) {
          this.invoices[masterIndex] = updated;
        }
        this.successMessage = `Invoice #${invoiceId} marked as paid.`;
        setTimeout(() => this.successMessage = '', 3000);
      },
      error: () => {
        this.errorMessage = 'Failed to mark invoice as paid.';
      }
    });
  }

  getStatusClass(status: string): string {
    switch (status) {
      case 'paid': return 'badge-paid';
      case 'unpaid': return 'badge-unpaid';
      case 'pending': return 'badge-pending';
      default: return '';
    }
  }
  
}
