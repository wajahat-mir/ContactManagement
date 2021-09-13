using ContactManagement.Bll.Core.Models.Contacts;
using ContactManagement.Bll.Services;
using ContactManagement.Tests.ProviderMocks;
using Moq;
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

        [Fact]
        public async void UpdateContact_ShouldReturnFalse_WhenFailure()
        {
            var contactRepo = ContactProviderMock.UpdateContact_Failure();
            var contactService = new ContactService(contactRepo.Object);

            var result = await contactService.UpdateContactAsync(It.IsAny<ContactModel>());

            Assert.False(result);
        }

        [Fact]
        public async void UpdateContact_ShouldReturnFalse_WhenSucceeds()
        {
            var contactRepo = ContactProviderMock.UpdateContact_Success();
            var contactService = new ContactService(contactRepo.Object);

            var result = await contactService.UpdateContactAsync(It.IsAny<ContactModel>());

            Assert.True(result);
        }

        [Fact]
        public async void CreateContact_ShouldReturnFalse_WhenFailure()
        {
            var contactRepo = ContactProviderMock.CreateContact_Failure();
            var contactService = new ContactService(contactRepo.Object);

            var result = await contactService.CreateContactAsync(It.IsAny<ContactModel>());

            Assert.False(result);
        }

        [Fact]
        public async void CreateContact_ShouldReturnFalse_WhenSucceeds()
        {
            var contactRepo = ContactProviderMock.CreateContact_Success();
            var contactService = new ContactService(contactRepo.Object);

            var result = await contactService.CreateContactAsync(It.IsAny<ContactModel>());

            Assert.True(result);
        }

        [Fact]
        public async void GetById_ShouldReturnNull_WhenDoesntExist()
        {
            var contactRepo = ContactProviderMock.GetById_DoesntExist();
            var contactService = new ContactService(contactRepo.Object);

            var result = await contactService.GetContactById(It.IsAny<int>());

            Assert.Null(result);
        }

        [Fact]
        public async void GetById_ShouldReturnContact_WhenExists()
        {
            var contactRepo = ContactProviderMock.GetById_Exists();
            var contactService = new ContactService(contactRepo.Object);

            var result = await contactService.GetContactById(It.IsAny<int>());

            Assert.NotNull(result);
        }
    }
}
