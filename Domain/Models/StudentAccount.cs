using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlawailApi.Domain.Models
{
public class StudentAccount
    {
        [Key]
        public int Id { get; set; }     
        // public string StudentAccount { get; set; }     
        public string Scholarships { get; set; }     
        public string ScholarshipsType { get; set; }     
        public string Tols { get; set; }     
        public string Registration { get; set; }     
        public string Cuurency { get; set; }     
        public string Loan { get; set; }     

    }
}