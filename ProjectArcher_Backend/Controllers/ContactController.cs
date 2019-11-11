using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectArcher_Backend.Models;
using ProjectArcher_Backend.Services;

namespace ProjectArcher_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult<List<Contact>> GetAllContacts()
        {
            return Ok(_contactService.GetContacts());
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetContactPerId(int id)
        {
            return Ok(_contactService.GetContact(id));
        }

        [HttpDelete("{id}")]
        public ActionResult<Contact> DeleteContact(int id)
        {
            return Ok(_contactService.DeleteContact(id));
        }

        [HttpPut]
        public ActionResult<Contact> UpdateContact([FromBody] Contact contact)
        {
            return Ok(_contactService.UpdateContact(contact));
        }

        [HttpPost]
        public ActionResult<Contact> AddContact([FromBody] Contact contact)
        {
            return Ok(_contactService.AddContact(contact));
        }
    }
}
