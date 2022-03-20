using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMSAPI.Commands.AccountCommand;
using TMSAPI.Models;
using TMSAPI.Queries;
using TMSAPI.Repositories;

namespace TMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly TMSContext _context;
        private readonly IAccountRepository _accountRepository;
        private readonly IMediator _mediator;
        private readonly ITMSQueries _TMSQueries;
        private readonly IAccountRoleRepository _accountRoleRepository;

        public AccountsController(TMSContext context, IAccountRepository accountRepository, IMediator mediator, ITMSQueries tmsQueries, IAccountRoleRepository accountRoleRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
            _mediator = mediator;
            _TMSQueries = tmsQueries;
            _accountRoleRepository = accountRoleRepository;

        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<IActionResult> GetAccount()
        {
            //var result = await _TMSQueries.GetAccountListAsync();
            //var result = await _TMSQueries.GetAccountListMapAsync();
            var result = await _TMSQueries.GetAllAccountAsyncByMap();

            return Ok(result);
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            //var account = await _context.Account.FindAsync(id);

            var account = await _TMSQueries.GetAccountByIdAsync(id);

            return Ok(account);
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account)
        {
            _accountRepository.Update(account);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Accounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount([FromBody] SaveAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Account>> DeleteAccount(int id)
        {
            var account = await _context.Account.FindAsync(id);
            if (account != null)
            {
                await _context.Entry(account).Collection(x => x.AccountRoles).LoadAsync();
            }

            _context.Account.Remove(account);
            await _context.SaveChangesAsync();

            return account;
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Resources", "ImagesProfile");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        
        [HttpGet("deleteImg/{fileName}")]
        public IActionResult deleteImg(string fileName)
        {
            try
            {
                var folderName = Path.Combine("Resources", "ImagesProfile");
                var dbPath = Path.Combine(folderName, fileName);

            if (System.IO.File.Exists(dbPath))
            {
                System.IO.File.Delete(dbPath);
            }
            return Ok(new { dbPath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        private bool AccountExists(int id)
        {
            return _context.Account.Any(e => e.Id == id);
        }
        // GET: api/Accounts/
        [HttpGet("login/{employeeNo}/{password}")]
        public async Task<IActionResult> GetAccountLoginChk(string employeeNo, string password)
        {
            //var account = await _context.Account.FindAsync(id);

            var account = await _TMSQueries.AccountLoginChk(employeeNo, password);

            return Ok(account);
        }
        


    }
}
