using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using KurLog.Controllers;
using KurLog.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace KurLog.Classes
{
    public class GetDoviz: IGetDoviz
    {
        private IHostingEnvironment _hostingEnvironment;
        public GetDoviz(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        private WebClient webClient = new WebClient();
        public void dovizGet()
        {
            //List<string> dovizAdlari = new List<string> { "ABD DOLARI", "EURO", "Gümüş", "Ons Altın", "Gram Altın" };
            string doviz = webClient.DownloadString("https://finans.truncgil.com/today.json");
            var dovizDizi = JObject.Parse(doviz).Children();

            string folderName = "RateLog";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            string fullPath = Path.Combine(newPath, "rateLog.json");
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            if (!System.IO.File.Exists(fullPath))
            {
                System.IO.File.CreateText(fullPath);
            }
            /********/
            List<JToken> tokensDate = dovizDizi.Where(k => k.Path.Contains("Güncelleme Tarihi")).Children().ToList();
            List<JToken> tokensDollar = dovizDizi.Children().Where(k => k.Path.Contains("ABD DOLARI")).Children().ToList();
            List<JToken> tokensEuro = dovizDizi.Children().Where(k => k.Path.Contains("EURO")).Children().ToList();
            List<JToken> tokensSilver = dovizDizi.Children().Where(k => k.Path.Contains("Gümüş")).Children().ToList();
            List<JToken> tokensGold = dovizDizi.Children().Where(k => k.Path.Contains("Gram Altın")).Children().ToList();


            var rateLogList = GetRateLogList();
            RateLog rateLog = new RateLog();
            rateLog.LogDate = DateTime.Now.ToString();
            rateLog.ApiUpdateDate = tokensDate[0].ToString();
            rateLog.DollarBuying = (string)tokensDollar[0];
            rateLog.DollarSales = (string)tokensDollar[1];
            rateLog.EuroBuying = (string)tokensEuro[0];
            rateLog.EuroSales = (string)tokensEuro[1];
            rateLog.SilverBuying = (string)tokensSilver[0];
            rateLog.SilverSales = (string)tokensSilver[1];
            rateLog.GoldBuying = (string)tokensGold[0];
            rateLog.GoldSales = (string)tokensGold[1];
            rateLogList.Add(rateLog);
            string JSONresult = JsonConvert.SerializeObject(rateLogList.ToArray(), Formatting.Indented);
            System.IO.File.WriteAllText(fullPath, JSONresult);
            /********/
            /*StreamWriter sw = System.IO.File.AppendText(fullPath);
            List<JToken> tokensDate = dovizDizi.Where(k => k.Path.Contains("Güncelleme Tarihi")).Children().ToList();
            sw.WriteLine("Log Tarihi: " + DateTime.Now);
            sw.WriteLine("Api Güncelleme Tarihi: " + tokensDate[0].ToString());
            foreach (var dovizAdi in dovizAdlari)
            {
                List<JToken> tokens = dovizDizi.Children().Where(k => k.Path.Contains(dovizAdi)).Children().ToList();
                sw.WriteLine(dovizAdi);
                sw.WriteLine("   Alış : " + (string)tokens[0]);
                sw.WriteLine("   Satış: " + (string)tokens[1]);
            }

            //using (StreamReader sr = System.IO.File.OpenText(fullPath))
            //{
            //    string s = "";
            //    while ((s = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
            sw.Flush();
            sw.Close();*/
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
