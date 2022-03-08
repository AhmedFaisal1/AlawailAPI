using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlawailApi.Domain.Models
{
public class Student
    {
        [Key]
         public int StudentId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }
}