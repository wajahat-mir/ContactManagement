using ContactManagement.Bll.Core.Interfaces;
using ContactManagement.Bll.Core.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Bll.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactProvider _contactProvider;

        public ContactService(IContactProvider contactProvider)
        {
            _contactProvider = contactProvider;
        }

        public async Task<IEnumerable<ContactModel>> GetContactsAsync()
        {
            return await _contactProvider.GetContactsAsync();
        }
        public async Task<bool> CreateContactAsync(ContactModel contact)
        {
            return await _contactProvider.CreateContactAsync(contact);
        }

        public async Task<ContactModel> GetContactById(int id)
        {
            return await _contactProvider.GetContactById(id);
        }

        public async Task<bool> UpdateContactAsync(ContactModel contact)
        {
            return await _contactProvider.UpdateContactAsync(contact);
        }
    }
}
