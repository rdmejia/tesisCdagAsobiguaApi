using System;
using System.Collections.Generic;
using tesisCdagAsobiguaApi.Domain.Models;

namespace tesisCdagAsobiguaApi.Resources
{
    public class ShotResource
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
        public double ImpactX { get; set; }
        public double ImpactY { get; set; }
        public string TipSteerDir { get; set; }
        public DateTime TimeStamp { get; set; }

        public  UserResource Trainer { get; set; }

        public UserResource Player { get; set; }

        public IList<XyzShotResource> XyzShots { get; set; }
    }
}
