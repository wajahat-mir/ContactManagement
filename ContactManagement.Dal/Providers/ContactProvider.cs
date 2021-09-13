using ContactManagement.Bll.Core.Interfaces;
using ContactManagement.Bll.Core.Models.Contacts;
using ContactManagement.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Dal.Providers
{
    public class ContactProvider: IContactProvider
    {
        private readonly IContactApiClient _contactApiClient;

        public ContactProvider(IContactApiClient contactApiClient)
        {
            _contactApiClient = contactApiClient;
        }

        public async Task<IEnumerable<ContactModel>> GetContactsAsync()
        {
            string url = $"v1/contact";
            return await _contactApiClient.GetAsync<IEnumerable<ContactModel>>(url);
        }

        public async Task<bool> CreateContactAsync(ContactModel contact)
        {
            try
            {
                string url = $"v1/contact";
                await _contactApiClient.PostAsync<ContactModel>(url, contact);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ContactModel> GetContactById(int id)
        {
            string url = $"v1/contact/{id}";
            return await _contactApiClient.GetAsync<ContactModel>(url);
        }

        public async Task<bool> UpdateContactAsync(ContactModel contact)
        {
            try
            {
                string url = $"v1/contact/{contact.id}";
                await _contactApiClient.PutAsync<ContactModel>(url, contact);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
