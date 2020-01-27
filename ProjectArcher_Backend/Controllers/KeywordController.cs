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
    public class KeywordController : ControllerBase
    {
        private readonly IKeywordService _keywordService;
        public KeywordController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }

        [HttpGet]
        public ActionResult<List<KeywordDTO>> GetAllKeywords()
        {
            return Ok(_keywordService.GetAllKeywords().Select(keyword => KeywordDTO.Of(keyword)).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<KeywordDTO> GetKeyword(int id)
        {
            return Ok(KeywordDTO.Of(_keywordService.GetKeyword(id)));
        }

        [HttpDelete("{id}")]
        public ActionResult<KeywordDTO> DeleteKeyword(int id)
        {
            return Ok(KeywordDTO.Of(_keywordService.DeleteKeyword(id)));
        }

        [HttpPost]
        public ActionResult<KeywordDTO> AddKeyword([FromBody] Keyword keyword)
        {
            return Ok(KeywordDTO.Of(_keywordService.AddKeyword(keyword)));
        }

        [HttpPut]
        public ActionResult<KeywordDTO> UpdateKeyword([FromBody] Keyword keyword)
        {
            return Ok(KeywordDTO.Of(_keywordService.UpdateKeyword(keyword)));
        }
    }
}
