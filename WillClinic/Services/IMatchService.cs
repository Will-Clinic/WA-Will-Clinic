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
        bool HasCompletedForm();
        bool IsVerified();
        VeteranQueue GetQueueItem();
        VeteranLawyerMatch GetMatch();
        List<LawyerAvailability> GetLawyerAvailability(string lawyerId);
        List<VeteranLawyerMatch> GetMatches();

        void AddtoQueue(string userId);
        void FindVeteran();
        void AcceptTimeSlot(int timeId);

        VeteranIntakeForm GetForm(int matchId);
    }
}
