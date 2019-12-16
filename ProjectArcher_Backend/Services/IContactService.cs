using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.Services
{
    public interface IContactService
    {
        List<Contact> GetContacts();
        Contact AddContact(Contact contact);
        Contact UpdateContact(Contact contact);
        Contact DeleteContact(int id);
        Contact GetContact(int id);
        List<Keyword> GetKeywordsForContact(int contactId);
        KeywordContact AddKeywordToContact(KeywordContact keyword);
        KeywordContact DeleteKeywordFromContact(KeywordContact keyword);
    }
}
