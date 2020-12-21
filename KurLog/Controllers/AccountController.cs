using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using KurLog.Classes;
using KurLog.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace KurLog.Controllers
{
    public class AccountController : Controller
    {
        private IHostingEnvironment _hostingEnvironment; 
        private readonly RequestCollectorService _requestCollectorService;
        public AccountController(IHostingEnvironment hostingEnvironment, RequestCollectorService requestCollectorService)
        {
            _hostingEnvironment = hostingEnvironment;
            _requestCollectorService = requestCollectorService;
        }
        private WebClient webClient = new WebClient();
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            _requestCollectorService.StopAsync(new System.Threading.CancellationToken());
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (LoginUser(loginModel.Username, loginModel.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginModel.Username)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }

        private bool LoginUser(string username, string password)
        {
            List<User> _user = new List<User>();
            var path = FullPath();
            string folderPath = path[0].ToString();
            string fullPath = path[1].ToString();
            string getUser = path[2].ToString();
            var array = JArray.Parse(getUser);
            foreach (var item in array)
            {
                try
                {
                    _user.Add(item.ToObject<User>());
                }
                catch (Exception ex)
                {
                }
            }
            password = SecurityMethods.Encrypt(password);
             _user = _user.Where(c => c.UserName.Trim().Equals(username.Trim()) && c.Password.Trim().Equals(password.Trim()) && c.IsDelete.Equals(false)).ToList();
            if (_user.Count==1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private List<string> FullPath()
        {
            List<string> path = new List<string>();
            string folderName = "User";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string folderPath = Path.Combine(webRootPath, folderName);
            string fullPath = Path.Combine(folderPath, "user.json");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (!System.IO.File.Exists(fullPath))
            {
                System.IO.File.CreateText(fullPath);
            }
            string user = webClient.DownloadString(fullPath);
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            var jsonElement = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(user);
            var getUser = System.Text.Json.JsonSerializer.Serialize(jsonElement, options);
            path.Add(folderPath);
            path.Add(fullPath);
            path.Add(getUser);
            return path;
        }
    }
}
