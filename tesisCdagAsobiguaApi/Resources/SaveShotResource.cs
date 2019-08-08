using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tesisCdagAsobiguaApi.Resources
{
    public class SaveShotResource
    {
        [Required]
        public double BackstrokePause { get; set; }

        [Required]
        public double ShotInterval { get; set; }

        [Required]
        public double Jab { get; set; }

        [Required]
        public double FollowThrough { get; set; }

        [Required]
        public double TipSteer { get; set; }

        [Required]
        public double Straightness { get; set; }

        [Required]
        public double Finesse { get; set; }

        [Required]
        public double Finish { get; set; }

        [Required]
        public double ImpactX { get; set; }

        [Required]
        public double ImpactY { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        public SaveUserShotResource Trainer { get; set; }

        [Required]
        public SaveUserShotResource Player { get; set; }

        [Required]
        public IList<SaveXyzShotResource> XyzShots { get; set; }
    }
}
