using AutoMapper;
using EmployeeRestAPI.Data.Entities;
using EmployeeRestAPI.Models;

namespace EmployeeRestAPI.Maps
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Employee, EmployeeModel>();
            CreateMap<EmployeeModel, Employee>();
            CreateMap<Employee, EmployeeForUpdatingModel>();
            CreateMap<EmployeeForUpdatingModel,Employee>();
        }
    }
}
