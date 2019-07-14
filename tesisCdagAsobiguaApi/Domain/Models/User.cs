using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace tesisCdagAsobiguaApi.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        [Column(TypeName = "binary(64)")]
        public string Password { get; set; }
        public EUserType UserType { get; set; }

        public IList<Shot> Shots { get; set; }
        public IList<Login> Logins { get; set; }
    }
}
