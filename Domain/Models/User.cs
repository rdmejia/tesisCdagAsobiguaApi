using System;

namespace tesisCdagAsobiguaApi.API.Domain.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }

        public string lastName {get; set; }

        public DateTime birthDate {get;set;}

        public string email { get; set; }

        public string username { get; set; }

        public UserType type { get; set; }
    }
}