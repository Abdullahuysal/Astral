﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral.Membership.Application.ApplicationQueries.UserQueries
{
    public record GetUserQueryResponse
    {
        public string UserName { get; set; }
    }
}