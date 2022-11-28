using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MindZoneConsultantAPI.Models
{
    public class BaseResponseModel
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}