using System;
namespace tesisCdagAsobiguaApi.Domain.Models
{
    public class XyzShot
    {
        public long Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public DateTime TimeStamp { get; set; }

        public long ShotId { get; set; }
        public Shot Shot { get; set; }
    }
}
