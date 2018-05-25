using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.Services
{
    public interface IVeteranService
    {
        Veteran Find(int id);
        Task<Veteran> FindAsync(int id);
        Task SaveAsync(Veteran veteran);
    }
}
