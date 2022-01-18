using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
	public class Employee
	{
		[Key]
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public Position JobTitle { get; set; }
	}
}
