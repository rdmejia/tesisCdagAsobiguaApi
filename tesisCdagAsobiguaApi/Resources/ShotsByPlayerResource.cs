using System;
namespace tesisCdagAsobiguaApi.Resources
{
    public class ShotsByPlayerResource
    {
        public long Id { get; set; }
        public DateTime timeStamp { get; set; }
        public UserResource trainer { get; set; }
        public UserResource player { get; set; }
    }
}
