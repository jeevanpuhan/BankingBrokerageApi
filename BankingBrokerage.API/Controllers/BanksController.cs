﻿using AutoMapper;
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
        public async Task<IActionResult> GetAllBanksAsync()
        {
            var banks = await _bankService.GetAllBanksAsync();

            var banksDTO = mapper.Map<List<Models.DTO.Bank>>(banks);

            return Ok(banksDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetBankAsync")]
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

        [HttpPost]
        public async Task<IActionResult> AddBankAsync([FromBody] Models.DTO.AddBankRequest addBankRequest)
        {
            var bank = mapper.Map<Models.Domain.Bank>(addBankRequest);

            bank = await _bankService.AddBankAsync(bank);

            var bankDTO = mapper.Map<Models.DTO.Bank>(bank);

            return CreatedAtAction(nameof(GetBankAsync), new {id = bankDTO.Id},bankDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
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