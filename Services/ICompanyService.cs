using System.Threading.Tasks;
using WebAPI.Dto;
using WebAPI.Entities;

namespace WebAPI.Services
{
	public interface ICompanyService
	{
		Task<long> AddCompany(CompanyDto company);
		Task<Company> DeleteCompany(int id);
		Result SearchCompany(CompanySearchFilterDto searchFilter);
		Task<bool> UpdateCompany(int id, CompanyDto company);
	}
}
