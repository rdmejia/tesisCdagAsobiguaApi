using System;
using System.ComponentModel.DataAnnotations;

namespace tesisCdagAsobiguaApi.Resources
{
    public class SaveXyzShotResource
    {
        [Required]
        public double X { get; set; }

        [Required]
        public double Y { get; set; }

        [Required]
        public double Z { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
