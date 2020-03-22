﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to DTO
            Mapper.CreateMap<Customer, CustomerDTO>();            
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();

            //DTO to Domain
            Mapper.CreateMap<CustomerDTO, Customer>();


        }
    }
}