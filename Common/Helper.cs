namespace MindZoneConsultantAPI.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Web;

    using Newtonsoft.Json.Linq;

    using Newtonsoft.Json;
    public class Helper
    {
        public static int OtpGenerator()
        {
            Random r = new Random();
            return r.Next(111111, 999999);
        }
    }
}