﻿using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.DTOs
{
    public class KeywordDTO
    {
        public long Id { get; set; }
        public string Keyword1 { get; set; }

        public static KeywordDTO Of(Keyword keyword)
        {
            return new KeywordDTO
            {
                Id = keyword.Id,
                Keyword1 = keyword.Keyword1
            };
        }
    }
}
