using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.Services
{
    public interface IKeywordService
    {
        Keyword DeleteKeyword(int id);
        Keyword AddKeyword(Keyword keyword);
        Keyword UpdateKeyword(Keyword keyword);
        Keyword GetKeyword(int id);
    }
}
