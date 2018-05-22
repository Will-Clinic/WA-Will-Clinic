﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Services
{
    public interface ILawyerVerificationService
    {
        Task<bool> IsValidLawyerAsync(string name, int number, string email);
    }
}
