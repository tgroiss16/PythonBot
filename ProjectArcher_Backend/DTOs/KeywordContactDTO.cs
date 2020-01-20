using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.DTOs
{
    public class KeywordContactDTO
    {
        public long KeywordId { get; set; }
        public long ContactId { get; set; }

        public static KeywordContactDTO Of(KeywordContact keyword)
        {
            return new KeywordContactDTO
            {
                KeywordId = keyword.KeywordId,
                ContactId = keyword.ContactId
            };
        }
    }
}
