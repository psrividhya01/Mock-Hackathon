export interface Invoice {
  invoiceId: number;
  clientName: string;
  totalAmount: number;
  status: 'paid' | 'unpaid' | 'pending';
  createdDate: string;
  clientId: string;
}

export interface GenerateInvoiceRequest {
  clientName: string;
}

export interface MarkPaidRequest {
  invoiceId: number;
}