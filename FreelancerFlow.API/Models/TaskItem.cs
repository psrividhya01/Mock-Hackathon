using FreelancerFlow.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancerFlow.API.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public Client? Client { get; set; } // nullable

        public int HoursWorked { get; set; }

        public string Description { get; set; } = string.Empty;

        public TaskItemStatus Status { get; set; } = TaskItemStatus.UnBilled; // Use enum

        public int? InvoiceId { get; set; }
    }
}