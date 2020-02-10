using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vks;
        public VaultKeepsController(VaultKeepsService vks)
        {
            _vks = vks;
        }
        [HttpGet("{id}/keeps")]
        public ActionResult<IEnumerable<Keep>> GetByVaultId(int id)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.GetByVaultId(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }
        [HttpPost]
        public ActionResult<VaultKeep> Post([FromBody] VaultKeep newVaultKeep)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newVaultKeep.UserId = userId;
                return Ok(_vks.Create(newVaultKeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{vaultId}/keeps/{keepId}")]
        public ActionResult<String> Delete(int vaultId, int keepId)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.Delete(vaultId, keepId, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}