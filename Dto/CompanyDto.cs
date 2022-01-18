using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dto
{
	public class CompanyDto
	{
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Establishment year is required")]
		[Range(1800, int.MaxValue, ErrorMessage = "Please enter a value bigger than 1800")]
		public int EstablishmentYear { get; set; }
		public IEnumerable<EmployeeDto> Employees { get; set; }
	}
}
