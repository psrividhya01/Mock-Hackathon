using FreelancerFlow.API.Enums;

namespace FreelancerFlow.API.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; } // Primary Key

        public int ClientId { get; set; } // Foreign Key

        public Client Client { get; set; } // Navigation

        public double TotalAmount { get; set; } // Total price as double

        public InvoiceStatus Status { get; set; } = InvoiceStatus.Unpaid; // Status as enum

        public DateTime CreatedAt { get; set; } // Date created
    }
}
