import { Injectable } from '@angular/core';
import { Invoice } from '../models/invoice';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { ClientDetail } from '../models/client';

@Injectable({
  providedIn: 'root',
})
export class InvoiceService {
  private baseUrl = 'http://your-api-base-url/api'; // Replace with your backend URL

  constructor(private http: HttpClient) {}

  // GET all invoices
  getAllInvoices(): Observable<Invoice[]> {
    return this.http.get<Invoice[]>(`${this.baseUrl}/invoices`);
  }

  // Generate invoice by client ID
  generateInvoice(clientId: string): Observable<Invoice> {
    return this.http.post<Invoice>(`${this.baseUrl}/invoices/generate`, { clientId });
  }

  // GET invoices by client ID
  getInvoiceByClient(clientId: string): Observable<Invoice[]> {
    return this.http.get<Invoice[]>(`${this.baseUrl}/invoices/client/${clientId}`);
  }

  // Mark invoice as paid
  markAsPaid(invoiceId: string): Observable<Invoice> {
    return this.http.patch<Invoice>(`${this.baseUrl}/invoices/${invoiceId}/paid`, {});
  }
  getClientById(clientId: string): Observable<ClientDetail> {
    return this.http.get<ClientDetail>(`${this.baseUrl}/clients/${clientId}`);
  }
}
