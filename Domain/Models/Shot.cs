using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tesisCdagAsobiguaApi.API.Domain.Models
{
    public class Shot
    {
        public int id { get; set; }

        public User trainer { get; set; }

        public User player { get; set; }

        public double backstokePause { get; set; }

        public double shotInterval { get; set; }
        
        public double jab { get; set; }

        public double followThrough { get; set; }

        public DateTime timeStamp { get; set; }

        public List<ShotXYZ> ShotXYZ { get; set; }
    }
}
