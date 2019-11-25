using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectArcher_Backend.Models;

namespace ProjectArcher_Backend.Services
{
    public class KeywordService : IKeywordService
    {
        private readonly postgresContext _context;
        public KeywordService(postgresContext context)
        {
            _context = context;
        }

        public Keyword AddKeyword(Keyword keyword)
        {
            var keywordToReturn = _context.Keyword.Add(keyword).Entity;
            _context.SaveChanges();
            return keywordToReturn;
        }

        public Keyword DeleteKeyword(int id)
        {
            var keyword = GetKeyword(id);
            var keywordToReturn = _context.Keyword.Remove(keyword).Entity;
            _context.SaveChanges();
            return keywordToReturn;
        }

        public Keyword GetKeyword(int id)
        {
            var keywordToReturn = _context.Keyword.Where(keyword => keyword.Id == id).Single();
            _context.SaveChanges();
            return keywordToReturn;
        }

        public Keyword UpdateKeyword(Keyword keyword)
        {
            var keywordToReturn = _context.Keyword.Update(keyword).Entity;
            _context.SaveChanges();
            return keywordToReturn;
        }
    }
}
