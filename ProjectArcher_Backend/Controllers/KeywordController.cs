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
    public class KeywordController : ControllerBase
    {
        private readonly IKeywordService _keywordService;
        public KeywordController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }

        [HttpGet]
        public ActionResult<List<Keyword>> GetAllKeywords()
        {
            return Ok(_keywordService.GetAllKeywords());
        }

        [HttpGet("{id}")]
        public ActionResult<Keyword> GetKeyword(int id)
        {
            return Ok(_keywordService.GetKeyword(id));
        }

        [HttpDelete("{id}")]
        public ActionResult<Keyword> DeleteKeyword(int id)
        {
            return Ok(_keywordService.DeleteKeyword(id));
        }

        [HttpPost]
        public ActionResult<Keyword> AddKeyword([FromBody] Keyword keyword)
        {
            return Ok(_keywordService.AddKeyword(keyword));
        }

        [HttpPut]
        public ActionResult<Keyword> UpdateKeyword([FromBody] Keyword keyword)
        {
            return Ok(_keywordService.UpdateKeyword(keyword));
        }
    }
}
