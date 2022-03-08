using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlawailApi.Domain.Models
{
public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        
    }
}