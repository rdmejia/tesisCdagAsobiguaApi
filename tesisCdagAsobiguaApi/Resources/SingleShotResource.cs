using System;
namespace tesisCdagAsobiguaApi.Resources
{
    public class SingleShotResource
    {
        public long Id { get; set; }
        public double BackstrokePause { get; set; }
        public double ShotInterval { get; set; }
        public double Jab { get; set; }
        public double FollowThrough { get; set; }
        public double TipSteer { get; set; }
        public double Straightness { get; set; }
        public double Finesse { get; set; }
        public double Finish { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
