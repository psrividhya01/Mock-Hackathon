namespace FreelancerFlow.API.DTOs.Invoice
{
    public class InvoiceResponseDto
    {
        public int InvoiceId { get; set; }
        public int ClientId { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class CreateInvoiceDto
    {
        public int ClientId { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; } = "Unpaid";
    }

    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public int ClientId { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
