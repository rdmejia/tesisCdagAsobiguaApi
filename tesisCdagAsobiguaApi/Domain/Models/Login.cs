using System;
namespace tesisCdagAsobiguaApi.Domain.Models
{
    public class Login
    {
        public long Id { get; set; }
        public DateTime TimeStamp { get; set; }

        public long TrainerId { get; set; }
        public User Trainer { get; set; }

        public long PlayerId { get; set; }
        public User Player { get; set; }
    }
}
