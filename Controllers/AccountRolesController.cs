using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMSAPI.Commands.SaveAccountRolesCommand;
using TMSAPI.Models;
using TMSAPI.Repositories;

namespace TMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountRolesController : ControllerBase
    {
        private readonly TMSContext _context;
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IMediator _mediator;

        public AccountRolesController(TMSContext context, IAccountRoleRepository accountRoleRepository, IMediator mediator)
        {
            _context = context;
            _accountRoleRepository = accountRoleRepository;
            _mediator = mediator;
        }

        // GET: api/AccountRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountRole>>> GetAccountRoles()
        {
            return await _context.AccountRoles.ToListAsync();
        }

        // GET: api/AccountRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountRole>> GetAccountRoles(int id)
        {
            var accountRoles = await _context.AccountRoles.FindAsync(id);

            if (accountRoles == null)
            {
                return NotFound();
            }

            return accountRoles;
        }

        // PUT: api/AccountRoles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountRoles(int id, AccountRole accountRole)
        {
            _accountRoleRepository.Update(accountRole);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/AccountRoles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccountRole>> PostAccountRoles(SaveAccountRolesCommand command)
        {

            var result = await _mediator .Send(command);
            return result;
            //_context.AccountRoles.Add(accountRoles);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetAccountRoles", new { id = accountRoles.Id }, accountRoles);
        }

        // DELETE: api/AccountRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountRole>> DeleteAccountRoles(int id)
        {
            var accountRoles = await _context.AccountRoles.FindAsync(id);
            if (accountRoles == null)
            {
                return NotFound();
            }

            _context.AccountRoles.Remove(accountRoles);
            await _context.SaveChangesAsync();

            return accountRoles;
        }

        private bool AccountRolesExists(int id)
        {
            return _context.AccountRoles.Any(e => e.Id == id);
        }
    }
}
