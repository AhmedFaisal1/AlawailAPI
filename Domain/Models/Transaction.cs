using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlawailApi.Domain.Models
{
public class Transaction
    {
        [Key]
        public int Id { get; set; }     
        public string Amount { get; set; }     
        public string LeftOver { get; set; }     
        public string Payments { get; set; }     
        public string UserId { get; set; }     
        public string StudentId { get; set; }
        public string PaymentMethod { get; set; }     
        public string StudentYear { get; set; }     

    }
}