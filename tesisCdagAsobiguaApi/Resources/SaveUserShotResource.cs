using System;
using System.ComponentModel.DataAnnotations;

namespace tesisCdagAsobiguaApi.Resources
{
    public class SaveUserShotResource
    {
        [Required]
        public string Username { get; set; }
    }
}
