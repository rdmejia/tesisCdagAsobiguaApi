using System;
using System.ComponentModel;

namespace tesisCdagAsobiguaApi.Domain.Models
{
    public enum EXyzShotPosition : byte
    {
        [Description("Antebrazo")]
        Antebrazo = 0,

        [Description("Muñeca")]
        Muneca = 1,

        [Description("Pierna")]
        Pierna = 2
    }
}
