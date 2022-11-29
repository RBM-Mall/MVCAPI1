using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace MindZoneConsultantAPI.Models
{
    /// <summary>
    /// Base Class For Response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponseModel<T>
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}