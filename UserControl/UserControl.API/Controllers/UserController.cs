using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserControl.Application.Services;
using UserControl.Domain.Interfaces;

namespace UserControl.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IUser>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IUser>> GetUserById(int userId)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(userId);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<IUser>> AddUser(IUser user)
        {
            try
            {
                await _userService.AddUserAsync(user);
                return CreatedAtAction("GetUserById", new { userId = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, IUser user)
        {
            if (userId != user.Id)
            {
                return BadRequest("IDs não correspondem");
            }

            try
            {
                await _userService.UpdateUserAsync(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(userId);
                if (user == null)
                {
                    return NotFound();
                }

                await _userService.DeleteUserAsync(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
