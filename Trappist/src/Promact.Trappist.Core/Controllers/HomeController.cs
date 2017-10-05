﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Promact.Trappist.Repository.BasicSetup;
using Promact.Trappist.Repository.TestConduct;
using Promact.Trappist.Utility.Constants;
using System.Threading.Tasks;

namespace Promact.Trappist.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Private variables
        #region Dependencies
        private readonly IBasicSetupRepository _basicSetup;
        private readonly ITestConductRepository _testConduct;
        private readonly IStringConstants _stringConstants;
        #endregion
        #endregion

        #region Constructor
        public HomeController(IBasicSetupRepository basicSetup, ITestConductRepository testConduct, IStringConstants stringConstants)
        {
            _basicSetup = basicSetup;
            _testConduct = testConduct;
            _stringConstants = stringConstants;
        }
        #endregion

        #region Public methods
        [Authorize]
        public IActionResult Index()
        {
            if (_basicSetup.IsFirstTimeUser())
                return RedirectToAction(nameof(HomeController.Setup), "Home");
            else
                return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Setup()
        {
            if (!_basicSetup.IsFirstTimeUser())
                return RedirectToAction(nameof(HomeController.Index), "Home");
            else
                return View();
        }

        /// <summary>
        /// This method is used to validate magic string.
        /// </summary>
        /// <param name="link">It contain magic string which uniquely identifies test</param>
        /// <returns>If link is valid than redirect to registration page else redirect to page not found action.</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Conduct(string link)
        {
            ViewBag.SessionId = HttpContext.Session.GetInt32(_stringConstants.AttendeeIdSessionKey);
            var ipAddress = HttpContext.Request.Headers["X-Forwarded-For"].ToString();
            if (string.IsNullOrEmpty(ipAddress))
                ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            if (!string.IsNullOrWhiteSpace(link) && await _testConduct.IsTestLinkExistForTestConductionAsync(link, ipAddress))
            {
                ViewBag.Link = link;
                return View();
            }
            return RedirectToAction("PageNotFound");
        }

        [AllowAnonymous]
        public IActionResult PageNotFound()
        {
            return View();
        }
        #endregion
    }
}
