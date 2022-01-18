using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.ResponseModel
{
	public class CompanySearchResultResponse
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public int EstablishmentYear { get; set; }

		public virtual IEnumerable<Employee> Employees { get; set; }
	}
}
