using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.DTOs
{
    public class KeywordCompanyDTO
    {
        public long KeywordId { get; set; }
        public long CompanyId { get; set; }

        public static KeywordCompanyDTO Of(KeywordCompany keyword)
        {
            return new KeywordCompanyDTO
            {
                KeywordId = keyword.KeywordId,
                CompanyId = keyword.CompanyId
            };
        }
    }
}
