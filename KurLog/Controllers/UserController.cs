using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KurLog.Classes;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using KurLog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using NPOI.SS.Formula.Functions;


namespace KurLog.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        public UserController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        private WebClient webClient = new WebClient();
        public IActionResult Index()
        {
            var _user = GetUserList();
            _user = _user.Where(c => c.IsDelete.Equals(false)).ToList();
            return View(_user);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return View(userModel);
            }
            var userList = GetUserList();
            var fullPath = FullPath();
            userModel.Password = SecurityMethods.Encrypt(userModel.Password);
            userList.Add(new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = userModel.UserName,
                Password = userModel.Password,
                Authority = userModel.Authority,
                IsDelete = false
            });
            string JSONresult = JsonConvert.SerializeObject(userList.ToArray(), Formatting.Indented);
            System.IO.File.WriteAllText(fullPath, JSONresult);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateUser(string Id)
        {
            var userList = GetUserList();
            var user = userList.Where(c => c.Id.Trim().Equals(Id.Trim())).FirstOrDefault();
            user.Password = SecurityMethods.Decrypt(user.Password);
            UserModel userModel = new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password,
                Authority = user.Authority,
                IsDelete = false

            };
            return View("UpdateUser", userModel);
        }

        [HttpPost]
        public IActionResult UpdateUser(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return View(userModel);
            }
            var userList = GetUserList();
            var fullPath = FullPath();
            var userRemove = userList.Single(r => r.Id == userModel.Id);
            userList.Remove(userRemove);
            userModel.Password = SecurityMethods.Encrypt(userModel.Password);
            userList.Add(new User()
            {
                Id = userRemove.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = userModel.UserName,
                Password = userModel.Password,
                Authority = userModel.Authority,
                IsDelete = false
            });
            string JSONresult = JsonConvert.SerializeObject(userList.ToArray(), Formatting.Indented);
            System.IO.File.WriteAllText(fullPath, JSONresult);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteUser(string Id)
        {
            var userList = GetUserList();
            var fullPath = FullPath();
            var userRemove = userList.Single(r => r.Id == Id);
            userList.Remove(userRemove);
            userList.Add(new User()
            {
                Id = userRemove.Id,
                FirstName = userRemove.FirstName,
                LastName = userRemove.LastName,
                UserName = userRemove.UserName,
                Password = userRemove.Password,
                Authority = userRemove.Authority,
                IsDelete = true
            });
            string JSONresult = JsonConvert.SerializeObject(userList.ToArray(), Formatting.Indented);
            System.IO.File.WriteAllText(fullPath, JSONresult);
            return RedirectToAction("Index");
        }

        private string FullPath()
        {
            string folderName = "User";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string folderPath = Path.Combine(webRootPath, folderName);
            string fullPath = Path.Combine(folderPath, "user.json");
            return fullPath;
        }

        private List<User> GetUserList()
        {
            List<User> path = new List<User>();
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
            var array = JArray.Parse(getUser);
            foreach (var item in array)
            {
                try
                {
                    path.Add(item.ToObject<User>());
                }
                catch (Exception ex)
                {
                }
            }
            return path;
        }
    }
}
