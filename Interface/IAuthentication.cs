namespace MindZoneConsultantAPI.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MindZoneConsultantAPI.Models;

    internal interface IAuthentication
    {
      Task<BaseResponseModel<object>> AddUser();
      Task<BaseResponseModel<object>> GetOTP();
    }
}
