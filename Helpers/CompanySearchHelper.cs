using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Entities;

namespace WebAPI
{
	public class CompanySearchHelper
	{
		private DatabaseContext _dbContext;

		public CompanySearchHelper(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IQueryable<Company> GetFilteredCompanies(CompanySearchFilterDto searchFilter)
		{
			var result = _dbContext.Companies.Include(x => x.Employees).AsQueryable();
			if (searchFilter!= null)
			{
				if (!string.IsNullOrEmpty(searchFilter.Keyword))
				{
					result = result.Where(x => x.Name.Contains(searchFilter.Keyword) ||
							x.Employees.Any(y => y.FirstName.Contains(searchFilter.Keyword)) ||
							x.Employees.Any(y => y.LastName.Contains(searchFilter.Keyword)));
				}
				if (searchFilter.EmployeeDateOfBirthFrom.HasValue)
				{
					result = result.Where(x => x.Employees.Any(y => y.DateOfBirth > searchFilter.EmployeeDateOfBirthFrom));
				}
				if (searchFilter.EmployeeDateOfBirthTo.HasValue)
				{
					result = result.Where(x => x.Employees.Any(y => y.DateOfBirth <= searchFilter.EmployeeDateOfBirthTo));
				}
				if (searchFilter.EmployeeJobTitles != null && searchFilter.EmployeeJobTitles.Any())
				{
					var positions = new List<Position>();
					foreach (var title in searchFilter.EmployeeJobTitles)
					{
						if (Enum.IsDefined(typeof(Position), title))
						{
							Enum.TryParse(title, out Position position);
							positions.Add(position);
						}
					}
					result = result.Where(x => x.Employees.Any(y => positions.Contains(y.JobTitle)));
				}
			}
			return result;
		}
	}
}
