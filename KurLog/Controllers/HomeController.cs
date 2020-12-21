using KurLog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using KurLog.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Microsoft.AspNetCore.Hosting;

namespace KurLog.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHostingEnvironment _hostingEnvironment;
        private readonly RequestCollectorService _requestCollectorService;
        public HomeController(ILogger<HomeController> logger, IHostingEnvironment hostingEnvironment, RequestCollectorService requestCollectorService)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _requestCollectorService = requestCollectorService;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public IActionResult Index()
        {
            var name = User.Claims.Where(c => c.Type == ClaimTypes.Name)
                .Select(c => c.Value).SingleOrDefault();
            _requestCollectorService.StopAsync(new System.Threading.CancellationToken());
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
