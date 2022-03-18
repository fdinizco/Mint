
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using SlotGroups.Models;
using SlotGroups.Models.Response;

namespace SlotGroups.Interfaces
{
    [Headers("User-Agent: :request:")]
    public interface IRemoteServices
    {
        [Get("/v3/d33a18c1-2561-40a8-b6c5-3c2b3012d440")]
        Task<string> SlotGroupInfo();

    }
}
