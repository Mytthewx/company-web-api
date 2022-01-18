using System;
using System.Collections.Generic;

namespace WebAPI
{
	public class CompanySearchFilterDto
	{
		public string? Keyword { get; set; }
		public DateTime? EmployeeDateOfBirthFrom { get; set; }
		public DateTime? EmployeeDateOfBirthTo { get; set; }
		public List<string> EmployeeJobTitles { get; set; }
	}
}
