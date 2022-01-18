using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dto;
using WebAPI.Entities;
using WebAPI.ResponseModel;

namespace WebAPI.Services
{
	public class CompanyService : ICompanyService
	{
		private readonly DatabaseContext _dbContext;
		private readonly IMapper _mapper;

		public CompanyService(DatabaseContext dbContext,
			IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<long> AddCompany(CompanyDto company)
		{
			var companyToAdd = _mapper.Map<Company>(company);
			_dbContext.Companies.Add(companyToAdd);
			await _dbContext.SaveChangesAsync();
			var response = new CompanyCreateResponse { Id = companyToAdd.Id };
			return response.Id;
		}

		public Result SearchCompany(CompanySearchFilterDto searchFilter)
		{
			var helper = new CompanySearchHelper(_dbContext);
			var models = helper.GetFilteredCompanies(searchFilter);

			var responseList = new List<CompanySearchResultResponse>();

			foreach (var model in models)
			{
				responseList.Add(new CompanySearchResultResponse
				{
					Name = model.Name,
					EstablishmentYear = model.EstablishmentYear,
					Employees = model.Employees
				});
			}

			return new Result { Results = responseList };
		}

		public async Task<bool> UpdateCompany(int id, CompanyDto company)
		{
			var companyToEdit = await _dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
			if (companyToEdit == null)
			{
				return false;
			}

			companyToEdit.Name = company.Name;
			companyToEdit.EstablishmentYear = company.EstablishmentYear;
			companyToEdit.Employees = _mapper.Map<List<Employee>>(company.Employees);

			await _dbContext.SaveChangesAsync();
			return true;
		}

		public async Task<Company> DeleteCompany(int id)
		{
			var company = await _dbContext.Companies.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == id);
			if (company == null)
			{
				return null;
			}

			if (company.Employees.Any())
			{
				_dbContext.Employees.RemoveRange(company.Employees);
			}

			_dbContext.Companies.Remove(company);
			await _dbContext.SaveChangesAsync();
			return company;
		}
	}
}
