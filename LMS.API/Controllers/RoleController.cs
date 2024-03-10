using LMS.Core.Data;
using LMS.Core.Service;
using LMS.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }


        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<List<Role>>> GetAllRoles()
        {
            try
            {
                var roles = await _roleService.GetAllRolles();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("GetRoleByID/{id}")]
        public async Task<ActionResult<Role>> GetRoleByID(int id)
        {
            try
            {
                var plan = await _roleService.GetRoleByID(id);
                if (plan == null)
                {
                    return NotFound($"Role with ID {id} not found.");
                }

                return Ok(plan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("GetRoleCount")]
        public async Task<ActionResult<int>> GetRolesCount()
        {
            try
            {
                var roleCount = await _roleService.GetRolesCount();
                return Ok(roleCount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreateRole")]
        public ActionResult CreateRole([FromBody] Role role)
        {
            try
            {
                _roleService.CreateRole(role);
                return CreatedAtAction(nameof(GetRoleByID), new { id = role.Roleid }, role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("UpdateRole")]
        public async void UpdateRole(Role role)
        {
            _roleService.UpdateRole(role);
        }



        [HttpDelete("DeleteRole/{id}")]
        public async void DeleteRole(int id)
        {
            _roleService.DeleteRole(id);
        }


    }
}
