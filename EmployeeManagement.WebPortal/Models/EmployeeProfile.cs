using AutoMapper;
using EmployeeManagement.Models;

namespace EmployeeManagement.WebPortal.Models
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EditEmployeeModel>()
                .ForMember(des => des.ConfirmEmail,
                opt => opt.MapFrom(src => src.Email));
            CreateMap<EditEmployeeModel, Employee>();
        }
    }
}
