using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlawailApi.Domain.Models
{
public class StudentToll
    {
        [Key]
        public int Id { get; set; }     
        public string Year { get; set; }     
        public string Amount { get; set; }     
        public string Registration { get; set; }     
        public string Currency { get; set; }     

    }
}