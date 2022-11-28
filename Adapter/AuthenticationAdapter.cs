namespace MindZoneConsultantAPI.Adapter
{
    using System.Threading.Tasks;
    using System.Web;
    using MindZoneConsultantAPI.Interface;
    using MindZoneConsultantAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AuthenticationAdapter : BaseAdapter, IAuthentication
    {
        public async Task<BaseResponseModel> AddUser()
        {
            try
            {
                return new BaseResponseModel()
                {
                    StatusCode = "TXN",
                    Message = "here",
                    Data = new Dictionary<string, object> { { "TXN",""} }
                };
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
    }
}