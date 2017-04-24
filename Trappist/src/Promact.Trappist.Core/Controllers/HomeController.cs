﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promact.Trappist.Repository.BasicSetup;
using Promact.Trappist.Repository.TestConduct;
using System.Threading.Tasks;

namespace Promact.Trappist.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Private variables
        #region Dependencies
        private readonly IBasicSetupRepository _basicSetup;
        private readonly ITestConductRepository _testConduct;
        #endregion
        #endregion

        #region Constructor
        public HomeController(IBasicSetupRepository basicSetup, ITestConductRepository testConduct)
        {
            _basicSetup = basicSetup;
            _testConduct = testConduct;
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
        /// <returns>If link is valid than redirect to registration page else redirect to page not found view.</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Conduct(string link)
        {
            if (!string.IsNullOrWhiteSpace(link) && await _testConduct.IsTestLinkExistAsync(link))
            {
                ViewBag.Link = link;
                return View();
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult PageNotFound()
        {
            return View();
        }

        #endregion
    }
}
