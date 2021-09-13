using ContactManagement.Bll.Core.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Bll.Core.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactModel>> GetContactsAsync();
        Task<bool> CreateContactAsync(ContactModel contact);
        Task<ContactModel> GetContactById(int id);
        Task<bool> UpdateContactAsync(ContactModel contact);
    }
}
