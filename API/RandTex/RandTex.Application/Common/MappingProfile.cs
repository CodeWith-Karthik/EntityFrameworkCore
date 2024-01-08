using AutoMapper;
using RandTex.Application.ViewModels;
using RandTex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandTex.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDetailsVM>()
                .ForMember(x => x.DepartmentId, opt => opt.MapFrom(source => source.Department.Id))
                .ForMember(x => x.DepartmentName, opt => opt.MapFrom(source => source.Department.Name))
                .ForMember(x => x.EmployeeDetailsId, opt => opt.MapFrom(source => source.EmployeeDetails.Id))
                .ForMember(x => x.Age, opt => opt.MapFrom(source => source.EmployeeDetails.Age))
                .ForMember(x => x.Gender, opt => opt.MapFrom(source => source.EmployeeDetails.Gender))
                .ForMember(x => x.PhoneNo, opt => opt.MapFrom(source => source.EmployeeDetails.PhoneNo))
                .ForMember(x => x.EmailAddress, opt => opt.MapFrom(source => source.EmployeeDetails.EmailAddress))
                .ForMember(x => x.Address, opt => opt.MapFrom(source => source.EmployeeDetails.Address));

            CreateMap<CallRecords, CallRecordsVM>()
                 .ForMember(x => x.EmployeeId, opt => opt.MapFrom(source => source.Employee.Id))
                 .ForMember(x => x.EmployeeName, opt => opt.MapFrom(source => source.Employee.LastName + " " + source.Employee.FirstName))
                 .ForMember(x => x.CustomerId, opt => opt.MapFrom(source => source.Customer.Id))
                 .ForMember(x => x.CustomerName, opt => opt.MapFrom(source => source.Customer.Name))
                 .ForMember(x => x.CallType, opt => opt.MapFrom(source => source.CallType));
        }
    }
}
