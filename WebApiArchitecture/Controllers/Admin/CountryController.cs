using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Countries;
using Service.Services.Interfaces;

namespace WebApiArchitecture.Controllers.Admin
{
    public class CountryController : BaseController
    {

        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
       public async Task<IActionResult> GetAll()
       {
            try
            {
                return Ok(await _countryService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }

       }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CountryCreateDto request)
        {
            try
            {
                await _countryService.CreateAsync(request);
                return CreatedAtAction(nameof(Create), new { response = "Data succesfully created" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int? id)
        {
            try
            {
                if (id is null) return BadRequest("Id cannot be null");
                var result = await _countryService.GetByIdAsync((int)id);

                if (result is null) return NotFound("data not found");

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });

            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            try
            {
                if (id is null) return BadRequest("Id cannot be null");
                var result = await _countryService.GetByIdAsync((int)id);
                if (result is null) return NotFound("data not found");
                await _countryService.DeleteAsync((int)id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int? id, [FromBody] CountryEditDto request)
        {
            try
            {
                if (id is null) return BadRequest("Id Can not be null");

                var result = await _countryService.GetByIdAsync((int)id);
                if (result is null) return NotFound("data not found");

                await _countryService.EditAsync(request,(int)id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });

            }
        }




    }
}

