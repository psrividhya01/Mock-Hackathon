export interface Invoice {
  invoiceId: string;
  clientId: string;
  totalAmount: number;
  status: 'paid' | 'unpaid' | 'pending';
  createdDate: string;
}

export interface GenerateInvoiceRequest {
  clientId: string;
}

export interface MarkPaidRequest {
  invoiceId: string;
}