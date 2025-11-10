using API.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BuggyController : BaseApiController
{
    [HttpGet("unauthorized")]
    public IActionResult GetUnauthorized()
    {
        return Unauthorized();
    }
    
    [HttpGet("bad-request")]
    public IActionResult GetBadRequest()
    {
        return BadRequest("Bad Request");
    }
    
    [HttpGet("not-found")]
    public IActionResult GetNotFound()
    {
        return NotFound();
    }
    
    [HttpGet("internal-error")]
    public IActionResult GetInternalError()
    {
        throw new Exception("Test exception of the Internal Error");
    }
    
    [HttpPost("validation-error")]
    public IActionResult GetValidationError([FromBody] CreateVehicleDto vehicle)
    {
        return Ok();
    }
}