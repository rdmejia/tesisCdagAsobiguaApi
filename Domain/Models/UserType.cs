using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace tesisCdagAsobiguaApi.API.Domain.Models
{
    public enum UserType
    {
        [Description("T")]
        Trainer = 0,

        [Description("P")]
        Player = 1
    }
}
