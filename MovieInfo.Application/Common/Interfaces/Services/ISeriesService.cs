﻿using FluentResults;
using MovieInfo.Application.Common.Requests;
using MovieInfo.Application.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Application.Common.Interfaces.Services
{
    public interface ISeriesService
    {
        Task<Result<int>> CreateSerieAsync(CreateSerieRequest request);
        Task<Result<GetSerieByIdResponse>> GetSerieByIdAsync(int Id);
        Task<Result> UpdateSerieAsync(int Id, UpdateSerieRequest request);
        Task<Result> DeleteSerieAsync(int Id);
        Task<Result<IEnumerable<GetAllSerieResponse>>> GetAllSerieAsync();
    }
}
