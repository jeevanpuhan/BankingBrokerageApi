using AutoMapper;
using BankingBrokerage.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingBrokerage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly IBankService _bankService;
        private readonly IMapper mapper;

        public BanksController(IBankService bankService, IMapper mapper)
        {
            this._bankService = bankService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBanksAsync()
        {
            var banks = await _bankService.GetAllBanksAsync();

            var banksDTO = mapper.Map<List<Models.DTO.Bank>>(banks);

            return Ok(banksDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetBankAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBankAsync([FromRoute] int id)
        {
            var bank = await _bankService.GetBankAsync(id);

            if (bank == null)
            {
                return NotFound();
            }

            var bankDTO = mapper.Map<Models.DTO.Bank>(bank);

            return Ok(bankDTO);
        }

        [HttpGet]
        [Route("user/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGetAllBanksByUserIdAsync(int id)
        {
            var banks = await _bankService.GetAllBanksByUserIdAsync(id);

            var banksDTO = mapper.Map<List<Models.DTO.Bank>>(banks);

            return Ok(banksDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddBankAsync([FromBody] Models.DTO.AddBankRequest addBankRequest)
        {
            var bank = mapper.Map<Models.Domain.Bank>(addBankRequest);

            bank = await _bankService.AddBankAsync(bank);

            var bankDTO = mapper.Map<Models.DTO.Bank>(bank);

            return CreatedAtAction(nameof(GetBankAsync), new {id = bankDTO.Id},bankDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var bank = await _bankService.DeleteBankAsync(id);

            if (bank == null)
            {
                return NotFound();
            }

            var bankDTO = mapper.Map<Models.DTO.Bank>(bank);

            return Ok(bankDTO);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserAsync(
            [FromRoute] int id,
            [FromBody] Models.DTO.UpdateBankRequest updateBankRequest)
        {
            var bank = mapper.Map<Models.Domain.Bank>(updateBankRequest);

            bank = await _bankService.UpdateBankAsync(id, bank);

            if (bank == null)
            {
                return NotFound();
            }

            var bankDTO = mapper.Map<Models.DTO.Bank>(bank);

            return Ok(bankDTO);
        }
    }
}
