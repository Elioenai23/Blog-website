using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/auth")] //auth route for the authentication endpoints when testing in postman

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")] // [api/auth/register] route for the registration endpoint when testing in postman
    public async Task<IActionResult> Register(RegisterDto dto)
    {

        try
        {
            var message = await _authService.RegisterAsync(dto);
            return Ok(new { message });
        }
        catch (Exception ex) 
        { 
               return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("login")] // [api/auth/login] route for the login endpoint when testing in postman
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var result = await _authService.LoginAsync(dto);

        if (result == null)
            return Unauthorized(new { message = "Invalid email or password" });

        return Ok(result);
    }

}