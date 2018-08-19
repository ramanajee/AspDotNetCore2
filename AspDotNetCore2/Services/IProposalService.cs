using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCore2.Services
{
    public interface IProposalService
    {
        Task Add(ProposalModel model);
        Task<ProposalModel> Approved(int proposalId);
        Task<IEnumerable<ProposalModel>> GetAll(int conferenceId);
    }
}
