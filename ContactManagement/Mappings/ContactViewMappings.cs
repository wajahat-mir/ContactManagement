using AutoMapper;
using ContactManagement.Bll.Core.Models.Contacts;
using ContactManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Mappings
{
    public class ContactViewMappings: Profile
    {
        public ContactViewMappings()
        {
            CreateMap<ContactModel, ContactViewModel>();
            CreateMap<ContactViewModel, ContactModel>();
        }
    }
}
