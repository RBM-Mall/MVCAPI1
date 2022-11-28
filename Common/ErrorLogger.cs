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
    public static class ErrorLogger
    {
        internal static void WriteErrorLog(Exception exception)
        {
            var trace = new StackTrace(exception, true);
            var lastFrame = trace.GetFrame(trace.FrameCount - 1);
            var exceptionLocation = lastFrame.GetFileName();
            var exceptionFunction = lastFrame.GetMethod();
            var exceptionLineNumber = lastFrame.GetFileLineNumber();
            var errorLog = $"{Environment.NewLine}Exception Time:[{DateTime.Now}], Exception Message:[{exception.Message}], Exception Function:[{exceptionFunction}], Exception Location:[{exceptionLocation}], Exception Line Number:[{exceptionLineNumber}]";

            var file = GetErrorLogPath();
            File.AppendAllText(file, errorLog);
        }
        internal static void WriteErrorLog(string exceptionMessage)
        {
            var callStack = new StackFrame(1, true);
            var exceptionLocation = callStack.GetFileName();
            var exceptionFunction = callStack.GetMethod();
            var exceptionLineNumber = callStack.GetFileLineNumber();

            var errorLog = $"{Environment.NewLine}Exception Time:[{DateTime.Now}], Exception Message:[{exceptionMessage}], Exception Function:[{exceptionFunction}], Exception Location:[{exceptionLocation}], Exception Line Number:[{exceptionLineNumber}]";

            var file = GetErrorLogPath();
            File.AppendAllText(file, errorLog);
        }
        internal static string GetErrorLogPath()
        {
            var filepath = HttpContext.Current.Server.MapPath("~/") + @"ErrorLogs\";
            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(filepath);
            var file = filepath + @"\ErrorLog.txt";
            if (File.Exists(file)) return file;
            var myFile = File.Create(file);
            myFile.Close();
            return file;
        }
        internal static string WriteDBErrorLog(Exception exception, string Query, object InsertObject = null)
        {
            try
            {
                var trace = new StackTrace(exception, true);
                var lastFrame = trace.GetFrame(trace.FrameCount - 1);
                var exceptionLocation = lastFrame.GetFileName();
                var exceptionFunction = lastFrame.GetMethod();
                var exceptionLineNumber = lastFrame.GetFileLineNumber();
                string insertObject = InsertObject == null ? "" : JsonConvert.SerializeObject(InsertObject);
                JObject jsonObject = new JObject()
                {
                    {
                        "Exception Time" , DateTime.Now
                    },
                    {
                        "Exception Message" , exception.Message
                    },
                    {
                        "Exception Function" , exceptionFunction.Name
                    },
                    {
                        "Exception Location" , exceptionLocation
                    },
                    {
                        "Exception Line Number" , exceptionLineNumber
                    },
                    {
                        "Exception Query" , Query
                    } ,
                    {
                        "Exception Object" , insertObject
                    }
                };
                var basePath = GetDBErrorLogPath();
                using (StreamWriter file = File.CreateText(basePath))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    jsonObject.WriteTo(writer);
                }
                return basePath;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
                return null;
            }
        }
        internal static string GetDBErrorLogPath()
        {
            var filepath = HttpContext.Current.Server.MapPath("~/") + @"DatabaseError\";
            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(filepath);
            filepath = filepath + $"DBErrorLog_{DateTime.Now.ToFileTime().ToString()}.txt";
            if (File.Exists(filepath))
                return filepath;
            var myFile = File.Create(filepath);
            myFile.Close();
            return filepath;
        }
    }
}