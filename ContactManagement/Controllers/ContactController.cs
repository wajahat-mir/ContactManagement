using AutoMapper;
using ContactManagement.Bll.Core.Interfaces;
using ContactManagement.Bll.Core.Models.Contacts;
using ContactManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(ILogger<ContactController> logger, IContactService contactService, IMapper mapper)
        {
            _logger = logger;
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _contactService.GetContactsAsync();
            var contactsView = _mapper.Map<IEnumerable<ContactViewModel>>(contacts);
            return View(contactsView);
        }

        public IActionResult Create()
        {
            return View(new ContactViewModel() 
            { 
                lastDateContacted = DateTime.Now
            });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var contact = await _contactService.GetContactById(id);
            var contactsView = _mapper.Map<ContactViewModel>(contact);
            return View(contactsView);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ContactViewModel contact)
        {
            var result = false;
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<ContactModel>(contact);
                result = await _contactService.CreateContactAsync(data);
            }
            if (!result)
                TempData.Add("CreateFailure", true);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ContactViewModel contact)
        {
            var result = false;
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<ContactModel>(contact);
                result = await _contactService.UpdateContactAsync(data);
            }
            if (!result)
                TempData.Add("UpdateFailure", true);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
