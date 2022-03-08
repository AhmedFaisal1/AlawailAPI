using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlawailApi.Domain.Models
{
public class User
    {
        [Key]
        public int Id {get; set;}
        public string Fullname {get; set;}
        public string username {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public string Role {get; set;}
    }
}



//Hi Ahmed