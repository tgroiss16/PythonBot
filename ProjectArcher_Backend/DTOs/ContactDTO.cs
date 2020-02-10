using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.DTOs
{
    public class ContactDTO
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TitlePrefix { get; set; }
        public string TitlePostfix { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumberMobile { get; set; }
        public string PhoneNumberLandline { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string Source { get; set; }
        public long InternalContact { get; set; }

        public static ContactDTO Of (Contact contact)
        {
            return new ContactDTO()
            {
                Id = contact.Id,
                CompanyId = contact.CompanyId,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                TitlePrefix = contact.TitlePrefix,
                TitlePostfix = contact.TitlePostfix,
                Gender = contact.Gender,
                Position = contact.Position,
                IsActive = contact.IsActive,
                PhoneNumberMobile = contact.PhoneNumberMobile,
                PhoneNumberLandline = contact.PhoneNumberLandline,
                Email = contact.Email,
                Note = contact.Note,
                Source = contact.Source,
                InternalContact = contact.InternalContact
            };
        }
    }
}
