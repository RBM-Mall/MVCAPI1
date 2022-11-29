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
        public async Task<BaseResponseModel<object>> AddUser()
        {
            try
            {
                return new BaseResponseModel<object>() { StatusCode="TXN",Message=null,Data = "ddata"};
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}