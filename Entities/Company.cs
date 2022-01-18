using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
	public class Company
	{
		[Key]
		public long Id { get; set; }
		public string Name { get; set; }
		public int EstablishmentYear { get; set; }

		public virtual IEnumerable<Employee> Employees { get; set; }
	}
}
