using AutoMapper;
using MovieNewMVC.Dtos;
using MovieNewMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieNewMVC.App_Start
{
    public class MappingProfiler: Profile
    {
        public MappingProfiler()
        {
            // source,target
            // Domain to Dto

            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Membership, MembershipTypeDto>();

            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>();
            // convention base auto mapper tool 
        }
    }
}