using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace AspDotNetCore2.Services
{
    public class ProposalService : IProposalService
    {
        private readonly List<ProposalModel> proposals = new List<ProposalModel>();
        public ProposalService()
        {
            proposals.Add(new ProposalModel
            {
                Id = 1,
                ConferenceId = 1,
                Title = "Understanding ASP.NET Core Security",
                Speaker = "Roland Guijt"
            });
            proposals.Add(new ProposalModel
            {
                Id = 2,
                ConferenceId = 2,
                Speaker = "John Reynolds",
                Title = "Starting Your Developer Career"
            });
            proposals.Add(new ProposalModel
            {
                Id = 3,
                ConferenceId = 2,
                Speaker = "Stan Lipens",
                Title = "ASP.NET Core TagHelpers"
            });
        }
        public Task Add(ProposalModel model)
        {
            model.Id = proposals.Max(x => x.Id) + 1;
            proposals.Add(model);
            return Task.CompletedTask;
        }

        public Task<ProposalModel> Approved(int proposalId)
        {
            return Task.Run(() =>
            {
                var proposal = proposals.FirstOrDefault(x => x.Id == proposalId);
                proposal.Approved = true;
                return proposal;
            });
        }

        public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return Task.Run(() => proposals.Where(x => x.ConferenceId == conferenceId));
        }
    }
}
