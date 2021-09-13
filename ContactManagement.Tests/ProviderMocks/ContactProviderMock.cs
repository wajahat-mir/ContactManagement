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

        public static Mock<IContactProvider> UpdateContact_Failure()
        {
            var mock = new Mock<IContactProvider>();
            mock.Setup(x => x.UpdateContactAsync(It.IsAny<ContactModel>())).ReturnsAsync(false);
            return mock;
        }


        public static Mock<IContactProvider> UpdateContact_Success()
        {
            var mock = new Mock<IContactProvider>();
            mock.Setup(x => x.UpdateContactAsync(It.IsAny<ContactModel>())).ReturnsAsync(true);
            return mock;
        }

        public static Mock<IContactProvider> CreateContact_Failure()
        {
            var mock = new Mock<IContactProvider>();
            mock.Setup(x => x.CreateContactAsync(It.IsAny<ContactModel>())).ReturnsAsync(false);
            return mock;
        }


        public static Mock<IContactProvider> CreateContact_Success()
        {
            var mock = new Mock<IContactProvider>();
            mock.Setup(x => x.CreateContactAsync(It.IsAny<ContactModel>())).ReturnsAsync(true);
            return mock;
        }

        public static Mock<IContactProvider> GetById_DoesntExist()
        {
            var mock = new Mock<IContactProvider>();
            ContactModel contact = null;
            mock.Setup(x => x.GetContactById(It.IsAny<int>())).ReturnsAsync(contact);
            return mock;
        }


        public static Mock<IContactProvider> GetById_Exists()
        {
            var mock = new Mock<IContactProvider>();
            ContactModel contact = new ContactModel() { 
                id = 1,
                name = "test"
            };
            mock.Setup(x => x.GetContactById(It.IsAny<int>())).ReturnsAsync(contact);
            return mock;
        }
    }
}
