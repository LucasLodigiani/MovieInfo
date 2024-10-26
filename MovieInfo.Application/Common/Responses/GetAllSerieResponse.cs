﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Application.Common.Responses
{
    public record GetAllSerieResponse(int Id, string Title, string SereiCoverUrl, IEnumerable<string> Genres);
}