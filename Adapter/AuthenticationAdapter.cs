namespace MindZoneConsultantAPI.Adapter
{
    using System.Threading.Tasks;
    using System.Web;
    using MindZoneConsultantAPI.Interface;
    using MindZoneConsultantAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MindZoneConsultantAPI.Common;

    public class AuthenticationAdapter : BaseAdapter, IAuthentication
    {
        public async Task<BaseResponseModel<object>> AddUser()
        {
            try
            {
                return new BaseResponseModel<object>() { StatusCode="TXN",Message="User Details added Successfully."};
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResponseModel<object>> GetOTP()
        {
            try
            {
                int otp = Helper.OtpGenerator();
                return new BaseResponseModel<object>() { StatusCode = "TXN", Data = otp };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}