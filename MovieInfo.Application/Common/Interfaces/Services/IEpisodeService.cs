﻿using FluentResults;
using MovieInfo.Application.Common.Requests;
using MovieInfo.Application.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Application.Common.Interfaces.Services;
public interface IEpisodeService
{
    Task<Result<int>> AddEpisodeToSeason(CreateEpisodeRequest request);
    Task<Result<IEnumerable<GetEpisodeFromSeasonResponse>>> GetEpisodeFromSeasonAsync(int id);
    Task<Result<GetEpisodeByIdResponse>> GetEpisodeById(int Id);
    Task<Result> DeleteEpisodeByIdAsync(int id);
    Task<Result> UpdateEpisodeByIdAsync(int id, UpdateEpisodeByIdRequest request);
}
