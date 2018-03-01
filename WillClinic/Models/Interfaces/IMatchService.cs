using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.Interfaces
{
    public interface IMatchService
    {
        bool IsInQueue();
        void FindVeterans();
    }
}
