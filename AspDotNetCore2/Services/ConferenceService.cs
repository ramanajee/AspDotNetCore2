using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCore2.Services
{
    public class ConferenceService : IConferenceService
    {
        private readonly List<ConferenceModel> conferences = new List<ConferenceModel>();
        public ConferenceService()
        {
            conferences.Add(new ConferenceModel { Id = 1, Name = "MDC", Location = "Oslo", Start = DateTime.Now, AttendeeTotal = 10 });
            conferences.Add(new ConferenceModel { Id = 2, Name = "IT/DevConnections", Location = "India", Start = DateTime.Now.AddDays(20), AttendeeTotal = 50 });
        }

        public Task Add(ConferenceModel conferenceModel)
        {
            conferenceModel.Id = conferences.Max(x => x.Id) + 1;
            conferences.Add(conferenceModel);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return Task.Run(() => conferences.AsEnumerable());
        }

        public Task<ConferenceModel> GetById(int id)
        {
            return Task.Run(() => conferences.FirstOrDefault(x => x.Id == id));
        }

        public Task<StatisticsModel> GetStatistics()
        {
            return Task.Run(() =>
            {
                return new StatisticsModel
                {
                    NumberOfAttendees = conferences.Sum(x => x.AttendeeTotal),
                    AverageConferenceAttendees = (int)conferences.Average(x => x.AttendeeTotal)
                };
            });
        }
    }
}
