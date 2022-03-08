using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlawailApi.Domain.Models
{
public class Department
    {
        [Key]
        public int DepartmentId { get; set; }      
        public string DepartmentName { get; set; }      
        public string DepartmentHeadManager { get; set; }      

        
    }
}