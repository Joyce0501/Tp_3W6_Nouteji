using JuliePro_DataAccess.Repository.IRepository;
using JuliePro_Models;
using JuliePro_Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JuliePro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStringLocalizer<HomeController> _localizer;

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            // MODIFICATION ICI 

            IEnumerable<CalendarEvent> CalendarEventList = _unitOfWork.CalendarEvent.GetAll(includeProperties: "Category");

            return View(CalendarEventList);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            var cookie = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture));
            var name = CookieRequestCultureProvider.DefaultCookieName;

            Response.Cookies.Append(name, cookie, new CookieOptions
            {
                Path = "/",
                Expires = DateTimeOffset.UtcNow.AddYears(1),
            });

            return LocalRedirect(returnUrl);
        }

    }
}
