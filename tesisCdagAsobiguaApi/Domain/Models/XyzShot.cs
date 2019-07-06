using System;
namespace tesisCdagAsobiguaApi.Domain.Models
{
    public class XyzShot
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public DateTime TimeStamp { get; set; }

        public int ShotId { get; set; }
        public Shot Shot { get; set; }
    }
}
