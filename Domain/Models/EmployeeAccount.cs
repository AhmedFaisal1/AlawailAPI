using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlawailApi.Domain.Models
{
public class EmployeeAccount

    {
        [Key]
        public int EmployeeId { get; set; }
        public string Salary { get; set; }
        public string Tax { get; set; }
        public string Ammount { get; set; }
        public string BankAccountNumber { get; set; }
        public string Currency { get; set; }

        
    }
}