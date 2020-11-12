using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Client.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.WebApi.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Forgot()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Get(UserRoleVM UserRoleVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(UserRoleVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("/gateway/accounts/get", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };
                    var token = response.Content.ReadAsStringAsync().Result.ToString();
                    var handler = new JwtSecurityTokenHandler().ReadJwtToken(token.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("Role_Name")).Value;

                    HttpContext.Session.SetString("Role: ", handler);
                    //var decodeToken = GetRole(response.Content.ReadAsStringAsync().Result.ToString());
                    //HttpContext.Session.SetString(SessionEmail, decodeToken);
                    return Json(new { result = "Redirect", url = Url.Action("Privacy", "Home"), data = response.Content.ReadAsStringAsync().Result.ToString() });
                }
                else
                {
                    return Content("GAGAL");
                }
            }
        }

        [HttpPatch]
        public ActionResult Forgot(UserRoleVM user)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(user);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PatchAsync("/gateway/accounts/", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { result = "Redirect", url = Url.Action("Index", "Login"), data = response.StatusCode });
                    //return Json(response.Content.ReadAsStringAsync().Result.ToString());

                }
                else
                {
                    return Json(new { data = "Gagal" });
                }
            }
        }
    }
}
