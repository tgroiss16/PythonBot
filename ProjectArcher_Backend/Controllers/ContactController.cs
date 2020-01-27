using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectArcher_Backend.DTOs;
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
        public ActionResult<List<ContactDTO>> GetAllContacts()
        {
            return Ok(_contactService.GetContacts().Select(x => ContactDTO.Of(x)));
        }

        [HttpGet("{id}")]
        public ActionResult<ContactDTO> GetContactPerId(int id)
        {
            return Ok(ContactDTO.Of(_contactService.GetContact(id)));
        }

        [HttpDelete("{id}")]
        public ActionResult<ContactDTO> DeleteContact(int id)
        {
            return Ok(ContactDTO.Of(_contactService.DeleteContact(id)));
        }

        [HttpPut]
        public ActionResult<ContactDTO> UpdateContact([FromBody] Contact contact)
        {
            return Ok(ContactDTO.Of(_contactService.UpdateContact(contact)));
        }

        [HttpPost]
        public ActionResult<ContactDTO> AddContact([FromBody] Contact contact)
        {
            return Ok(ContactDTO.Of(_contactService.AddContact(contact)));
        }

        [HttpPost("keyword")]
        public ActionResult<KeywordContactDTO> AddContactKeyword([FromBody] KeywordContact keyword)
        {
            return Ok(KeywordContactDTO.Of(_contactService.AddKeywordToContact(keyword)));
        }

        [HttpDelete("keyword")]
        public ActionResult<KeywordContactDTO> DeleteKeywordFromContact([FromBody] KeywordContact keyword)
        {
            return Ok(KeywordContactDTO.Of(_contactService.DeleteKeywordFromContact(keyword)));
        }

        [HttpGet("keyword/{id}")]
        public ActionResult<List<KeywordDTO>> GetKeywordsForContact(int contactId)
        {
            return Ok(_contactService.GetKeywordsForContact(contactId).Select(x => KeywordDTO.Of(x)));
        }

        [HttpPost("timeline")]
        public ActionResult<TimelineContactDTO> AddTimelineObjectToContact([FromBody] TimelineContact keyword)
        {
            return Ok(TimelineContactDTO.Of(_contactService.AddTimelineObjectToContact(keyword)));
        }

        [HttpDelete("timeline")]
        public ActionResult<TimelineContactDTO> DeleteTimelineFromCompany([FromBody] TimelineContact keyword)
        {
            return Ok(TimelineContactDTO.Of(_contactService.DeleteTimelineFromContact(keyword)));
        }

        [HttpGet("timeline/{id}")]
        public ActionResult<List<TimelineDTO>> DeleteTimelineFromContact(int contactId)
        {
            return Ok(_contactService.GetTimelineObjectsForContact(contactId).Select(x => TimelineDTO.Of(x)).ToList());
        }
    }
}
