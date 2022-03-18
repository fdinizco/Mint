using System;
using System.Threading.Tasks;
using Refit;
using SlotGroups.Common;
using SlotGroups.Interfaces;
using SlotGroups.Models.Response;

namespace SlotGroups.Services.Remote
{
    public static class RESTServices
    {
        public static async Task<string> RetriveSlotGroupInfoFromServerAsync()
        {
            string response = String.Empty;
            IRemoteServices remoteServices;
            remoteServices = RestService.For<IRemoteServices>(AppConstants.ApiURL);
            try
            {
                response = await remoteServices.SlotGroupInfo();
                return response;
            }
            catch (Exception ex)
            {
                //var statusCode = ex.StatusCode;
                ErrorResponse errorResponse = new ErrorResponse
                {
                    Message = ex.ToString()
                };
                return errorResponse.Message;
            }
        }
    }
}
