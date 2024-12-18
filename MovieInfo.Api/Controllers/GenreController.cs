﻿using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovieInfo.Api.Infraestructure;
using MovieInfo.Application.Common.Interfaces.Repositories;
using MovieInfo.Application.Common.Interfaces.Services;
using MovieInfo.Application.Common.Requests;
using MovieInfo.Application.Common.Responses;
using MovieInfo.Domain.Errors;

namespace MovieInfo.Api.Controllers
{
    public class GenreController : ApiControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Policy = "AdminOrEmployeePolicy")]
        public async Task<ActionResult<int>> Create(CreateGenreRequest request)
        {
            var result = await _genreService.CreateGenreAsync(request);

            if (result.IsFailed)
            {
                return BadRequest(new ApiErrorResponse("Errors", result.Errors));
            }

            return Ok(result.Value);
        }

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse),StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GetAllGenreResponse>>> GetAll()
        {
            var result = await _genreService.GetAllGenreAsync();

            if (result.IsFailed)
            {
                var error = result.Errors.First();

                if (error is NotFoundError) return NotFound(new ApiErrorResponse("NotFound", error.Message));

                return BadRequest(new ApiErrorResponse("Errors", result.Errors));
            }

            return Ok(result.Value);
        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiErrorResponse),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Policy = "AdminOrEmployeePolicy")]
        public async Task<ActionResult> UpdateGenreById(int id, UpdateGenreRequest request)
        {
            var mov = await _genreService.UpdateGenreByIdAsync(id, request);

            if (mov.IsFailed)
            {
                var error = mov.Errors.First();

                if (error is NotFoundError) return NotFound(new ApiErrorResponse("NotFound", error.Message));

                return BadRequest(new ApiErrorResponse("Errors", mov.Errors));
            }

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiErrorResponse),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Policy = "AdminOrEmployeePolicy")]
        public async Task<ActionResult> DeleteGenreById(int id)
        {
            var mov = await _genreService.DeleteGenreByIdAsync(id);

            if (mov.IsFailed)
            {
                var error = mov.Errors.First();

                if (error is NotFoundError) return NotFound(new ApiErrorResponse("NotFound", error.Message));

                return BadRequest(new ApiErrorResponse("Errors", mov.Errors));
            }

            return NoContent();
        }
    }
}
