using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Services
{
    interface ILawyerVerificationService
    {
        Task<bool> IsValidLawyer(string name, string number, string email);
    }
}
