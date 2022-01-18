using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dto;
using WebAPI.Entities;
using WebAPI.ResponseModel;
using WebAPI.Services;

namespace WebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class Controller : ControllerBase
	{

		private readonly ICompanyService _companyService;

		public Controller(ICompanyService companyService)
		{
			_companyService = companyService;
		}

		[HttpPost]
		[Route("company/create")]
		public async Task<ActionResult<long>> AddCompany(CompanyDto company)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var response = await _companyService.AddCompany(company);
			return Ok(response);
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("company/search")]
		public ActionResult<Result> SearchCompany(CompanySearchFilterDto searchFilter)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			return Ok(_companyService.SearchCompany(searchFilter));
		}
		
		[HttpPut]
		[Route("company/update/{id}")]
		public async Task<ActionResult> UpdateCompany(int id, CompanyDto company)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var result = await _companyService.UpdateCompany(id, company);
			if (!result)
			{
				return NotFound();
			}

			return Ok();
		}

		[HttpDelete]
		[Route("company/delete/{id}")]
		public async Task<ActionResult> DeleteCompany(int id)
		{
			var result = await _companyService.DeleteCompany(id);
			return Ok(result);
		}
	}
}
