using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dto
{
	public class EmployeeDto
	{
		[Required(ErrorMessage = "First name is required")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Last name is required")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "Date of birth is required")]
		public DateTime DateOfBirth { get; set; }
		[Required(ErrorMessage = "Job title is required")]
		public Position JobTitle { get; set; }
	}
}
