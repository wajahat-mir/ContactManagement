using ContactManagement.Bll.Services;
using ContactManagement.Tests.ProviderMocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactManagement.Tests
{
    public class ContactServiceTests
    {
        [Fact]
        public async void GetContacts_ShouldReturnNothing_WhenEmpty()
        {
            var contactRepo = ContactProviderMock.GetContacts_ReturnsNull();
            var contactService = new ContactService(contactRepo.Object);

            var result = await contactService.GetContactsAsync();

            Assert.Null(result);
        }
    }
}
