using System;
using System.Collections.Generic;

namespace tesisCdagAsobiguaApi.Domain.Models
{
    public class Shot
    {
        public int Id { get; set; }
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

        public int TrainerId { get; set; }
        public User Trainer { get; set; }

        public int PlayerId { get; set; }
        public User Player { get; set; }

        public IList<XyzShot> XyzShots { get; set; }
    }
}
