using ContactManagement.Bll.Core.Interfaces;
using ContactManagement.Bll.Core.Models.Contacts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Tests.ProviderMocks
{
    public class ContactProviderMock
    {
        public static Mock<IContactProvider> GetContacts_ReturnsNull()
        {
            var mock = new Mock<IContactProvider>();
            IEnumerable<ContactModel> contacts = null;
            mock.Setup(x => x.GetContactsAsync()).ReturnsAsync(contacts);
            return mock;
        }
    }
}
