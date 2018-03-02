using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.Interfaces
{
    public interface IMatchService
    {
        bool IsInQueue();
        bool IsMatched();
        void FindVeteran();
        VeteranLawyerMatch GetMatch();
        List<VeteranLawyerMatch> GetMatches();
        void AddtoQueue(string userId);
        List<VeteranIntakeForm> GetForms(VeteranLawyerMatch match);
    }
}
