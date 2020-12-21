using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using KurLog.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.Language;
using Newtonsoft.Json.Linq;

namespace KurLog.Controllers
{
    [Authorize]
    public class RateLogController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly RequestCollectorService _requestCollectorService;
        public RateLogController(IHostingEnvironment hostingEnvironment, RequestCollectorService requestCollectorService)
        {
            _hostingEnvironment = hostingEnvironment;
            _requestCollectorService = requestCollectorService;
        }
        private WebClient webClient = new WebClient();
        public IActionResult Index()
        {
            _requestCollectorService.StartAsync(new System.Threading.CancellationToken());
            var _rateLog = GetRateLogList();
            _rateLog = _rateLog.OrderByDescending(x=>x.ApiUpdateDate).ThenByDescending(c=>c.LogDate).ToList();
            return View(_rateLog);
        }

        private List<RateLog> GetRateLogList()
        {
            List<RateLog> path = new List<RateLog>();
            string folderName = "RateLog";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string folderPath = Path.Combine(webRootPath, folderName);
            string fullPath = Path.Combine(folderPath, "rateLog.json");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (!System.IO.File.Exists(fullPath))
            {
                System.IO.File.CreateText(fullPath);
            }
            string rateLog = webClient.DownloadString(fullPath);
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            var jsonElement = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(rateLog);
            var getRateLog = System.Text.Json.JsonSerializer.Serialize(jsonElement, options);
            var array = JArray.Parse(getRateLog);
            foreach (var item in array)
            {
                try
                {
                    path.Add(item.ToObject<RateLog>());
                }
                catch (Exception ex)
                {
                }
            }
            return path;
        }
    }
}
