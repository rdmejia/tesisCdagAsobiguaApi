using System;
using System.ComponentModel;

namespace tesisCdagAsobiguaApi.Domain.Models
{
    public enum EUserType : byte
    {
        [Description("Trainer")]
        Trainer = 0,

        [Description("Player")]
        Player = 1
    }
}
