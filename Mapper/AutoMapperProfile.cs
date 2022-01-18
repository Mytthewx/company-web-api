using AutoMapper;
using WebAPI.Dto;
using WebAPI.Entities;

namespace WebAPI.Mapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<CompanyDto, Company>();
			CreateMap<EmployeeDto, Employee>();
		}
	}
}
