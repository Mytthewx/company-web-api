using System.Threading.Tasks;
using WebAPI.Dto;

namespace WebAPI.Services
{
	public interface ICompanyService
	{
		Task<long> AddCompany(CompanyDto company);
		Task<bool> DeleteCompany(int id);
		Result SearchCompany(CompanySearchFilterDto searchFilter);
		Task<bool> UpdateCompany(int id, CompanyDto company);
	}
}
