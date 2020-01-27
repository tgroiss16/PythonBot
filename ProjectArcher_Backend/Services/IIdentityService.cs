using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.Services
{
    public interface IIdentityService
    {
        bool Login(string username, string password);
        bool Register(string username, string password);
    }
}
