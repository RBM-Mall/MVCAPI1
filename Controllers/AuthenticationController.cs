﻿namespace MindZoneConsultantAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
        /// api use to add user
        /// </summary>
        /// <param name="addUserModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(Routes.AddUser)]
        public async Task<IHttpActionResult> AddUser(AddUserModel addUserModel)
        {
            try
            {
                IAuthentication authentication = new AuthenticationAdapter();
                var resp = await authentication.AddUser();

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
        public async Task<IHttpActionResult> UpdateUser()
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