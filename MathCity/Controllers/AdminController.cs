using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    [HttpGet("dashboard")]
    [Authorize(Roles = "Admin")]
    public IActionResult Dashboard()
    {
        return Ok(new
        {
            Message = "Welcome Admin!"
        });
    }


    [HttpGet("student")]
    [Authorize(Roles = "Student")]
    public IActionResult StudentDashboard()
    {
        return Ok(new
        {
            Message = "Welcome Student!"
        });
    }


}