﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Application.Common.Responses
{
    public record GetSubscriptionPreferenceResponse(string id, string title, string description, decimal price);

}
