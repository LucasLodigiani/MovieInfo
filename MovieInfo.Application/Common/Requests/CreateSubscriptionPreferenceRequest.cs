﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Application.Common.Requests;
public record CreateSubscriptionPreferenceRequest(string Title, string Description, decimal Price);
