using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.DTOs
{
    public class CompanyDTO
    {
        public long Id { get; set; }
        public bool? IsActive { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string PhoneNumberMobile { get; set; }
        public string PhoneNumberLandline { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Note { get; set; }
        public long? InternalContact { get; set; }
        public long? ExternalContact { get; set; }
        public string Name { get; set; }

        public static CompanyDTO Of(Company company)
        {
            return new CompanyDTO
            {
                Id = company.Id,
                IsActive = company.IsActive,
                City = company.City,
                PostalCode = company.PostalCode,
                Street = company.Street,
                Country = company.Country,
                PhoneNumberMobile = company.PhoneNumberMobile,
                PhoneNumberLandline = company.PhoneNumberLandline,
                Email = company.Email,
                Website = company.Website,
                Note = company.Note,
                InternalContact = company.InternalContact,
                ExternalContact = company.ExternalContact,
                Name = company.Name
            };
        }
    }
}
