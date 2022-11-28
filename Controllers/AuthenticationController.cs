namespace MindZoneConsultantAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using MindZoneConsultantAPI.Adapter;
    using MindZoneConsultantAPI.Common;
    using MindZoneConsultantAPI.Interface;
    using MindZoneConsultantAPI.Models.AuthenticationModel;

    /// <summary>
    /// Authentication Of App
    /// </summary>
    public class AuthenticationController : BaseController
    {
        /// <summary>
        /// Add User Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route(Routes.AddUser)]
        public IHttpActionResult AddUser(AddUserModel addUserModel)
        {
            try
            {
                addUserModel.Id = 0;
                IAuthentication authentication = new AuthenticationAdapter();
                var resp = authentication.AddUser();

                return Ok(resp);
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteErrorLog(ex);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API To Update User Data
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route(Routes.UpdateUser)]
        public IHttpActionResult UpdateUser()
        {
            try
            {
                return Ok(new { User = User });
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteErrorLog(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}