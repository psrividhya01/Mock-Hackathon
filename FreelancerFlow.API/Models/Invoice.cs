namespace FreelancerFlow.API.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; } // Primary Key

        public int ClientId { get; set; } // Foreign Key

        public Client Client { get; set; } // Navigation

        public decimal TotalAmount { get; set; } // Total price

        public string Status { get; set; } // Unpaid / Paid

        public DateTime CreatedDate { get; set; } // Date created
    }
}
