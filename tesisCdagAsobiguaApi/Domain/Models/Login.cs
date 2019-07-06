using System;
namespace tesisCdagAsobiguaApi.Domain.Models
{
    public class Login
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }

        public int TrainerId { get; set; }
        public User Trainer { get; set; }

        public int PlayerId { get; set; }
        public User Player { get; set; }
    }
}
