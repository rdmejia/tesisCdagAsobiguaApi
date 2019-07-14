﻿using System;
using tesisCdagAsobiguaApi.Domain.Models;

namespace tesisCdagAsobiguaApi.Resources
{
    public class LoginResource
    {
        public long Id { get; set; }
        public DateTime TimeStamp { get; set; }

        public UserResource Trainer { get; set; }

        public UserResource Player { get; set; }
    }
}
