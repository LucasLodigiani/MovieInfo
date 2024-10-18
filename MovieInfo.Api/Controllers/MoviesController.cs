﻿using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieInfo.Api.Extensions;
using MovieInfo.Application.Common.Interfaces.Services;
using MovieInfo.Application.Common.Requests;
using MovieInfo.Application.Common.Responses;
using MovieInfo.Domain.Errors;

namespace MovieInfo.Api.Controllers
{
    public class MoviesController : ApiControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GetAllMoviesResponse>>> GetAllMovies()
        {
            var result = await _movieService.GetAllMovies();

            if (result.IsFailed)
            {
                var error = result.Errors.First();

                return BadRequest(error.Message);
            }

            return Ok(result.Value);

        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Policy = "AdminOrEmployeePolicy")]
        public async Task<ActionResult<int>> Create([FromForm] CreateMovieRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetAllErrors());

            var result = await _movieService.CreateMovieAsync(request);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Value);
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetMovieByIdResponse>> GetById(int id)
        {
            var result = await _movieService.GetMovieByIdAsync(id);

            if (result.IsFailed)
            {
                var error = result.Errors.First();

                if (error is NotFoundError) return NotFound(error.Message);

                return BadRequest(error.Message);
            }

            return Ok(result.Value);
        }

        [HttpGet("get-movies-by-genre/{genreName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GetMoviesByGenreNameResponse>>> GetMoviesByGenreName(string genreName)
        {
            var result = await _movieService.GetMoviesByGenreName(genreName);

            if (result.IsFailed)
            {
                var error = result.Errors.First();

                return BadRequest(error.Message);
            }

            return Ok(result.Value);
        }



        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateMovieById(int id, [FromForm] UpdateMovieByIdRequest request)
        {
            var mov = await _movieService.UpdateMovieByIdAsync(id, request);

            if (mov.IsFailed)
            {
                var error = mov.Errors.First();

                if (error is NotFoundError) return NotFound(error.Message);

                return BadRequest(error.Message);
            }

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteMovieById(int id)
        {
            var mov = await _movieService.DeleteMovieByIdAsync(id);

            if (mov.IsFailed)
            {
                var error = mov.Errors.First();

                if (error is NotFoundError) return NotFound(error.Message);

                return BadRequest(error.Message);
            }


            return NoContent();
        }
    }
}
