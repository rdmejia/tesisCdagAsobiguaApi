using System;
using tesisCdagAsobiguaApi.Domain.Models;

namespace tesisCdagAsobiguaApi.Resources
{
    public class XyzShotResource
    {
        public long Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
