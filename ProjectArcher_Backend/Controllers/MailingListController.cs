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
    public class MailingListController : ControllerBase
    {

        private readonly IMailingListService _mailingListService;
        public MailingListController(IMailingListService mailingListService) {
            _mailingListService = mailingListService;
        }

        [HttpGet]
        public ActionResult<MailingListDTO> GetAllMailingLists()
        {
            return Ok(_mailingListService.GetAllMailingLists().Select(MailingListDTO.Of).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<MailingListDTO> GetMailingList(int id)
        {
            return Ok(MailingListDTO.Of(_mailingListService.GetMailingList(id)));
        }

        [HttpPost]
        public ActionResult<MailingListDTO> AddMailingList([FromBody] MailingList mailingList)
        {
            return Ok(MailingListDTO.Of(_mailingListService.AddMailingList(mailingList)));
        }

        [HttpPut]
        public ActionResult<MailingListDTO> UpdateMailingList([FromBody] MailingList mailingList) {
            return Ok(MailingListDTO.Of(_mailingListService.UpdateMailingList(mailingList)));
        }

        [HttpDelete("{id}")]
        public ActionResult<MailingListDTO> DeleteCompany(int id) {
            return Ok(MailingListDTO.Of(_mailingListService.DeleteMailingList(id)));
        }
    }
}
