using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Models;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Text;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        string Baseurl = "http://localhost:51818/";
        public async Task<ActionResult> Index()
        {
            List<Student> EmpInfo = new List<Student>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/HELLO");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Student>>(EmpResponse);
                }
                return View(EmpInfo);
            }
        }
         [AcceptVerbs(HttpVerbs.Get)]
        public async Task<ActionResult> Delete(int id)
        {
            Student EmpInfo = new Student();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.DeleteAsync("api/HELLO/" + id);
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<Student>(EmpResponse);
                }
                
            }
            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public async Task<ActionResult> Edit(int id)
        {
            Student EmpInfo = new Student();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/HELLO/" + id);
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<Student>(EmpResponse);
                }
                return View(EmpInfo);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Edit(FormCollection form)
        {
            Student EmpInfo = new Student();
            EmpInfo.Id = Convert.ToInt32(form["Id"]);
            EmpInfo.Name = form["Name"];
            EmpInfo.Gender = form["Gender"];
            EmpInfo.Marks = Convert.ToDouble(form["Marks"]);
            EmpInfo.Phone = Convert.ToInt64(form["Phone"]);
            EmpInfo.Address = form["Address"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                StringContent content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(EmpInfo).ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PutAsync("api/HELLO/", content);
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<Student>(EmpResponse);
                }
            }
            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public async Task<ActionResult> Post()
        {
            Student EmpInfo = new Student();

            return View(EmpInfo);
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Post(FormCollection form)
        {
            Student EmpInfo = new Student();
            EmpInfo.Name = form["Name"];
            EmpInfo.Gender = form["Gender"];
            EmpInfo.Marks = Convert.ToDouble(form["Marks"]);
            EmpInfo.Phone = Convert.ToInt64(form["Phone"]);
            EmpInfo.Address = form["Address"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                StringContent content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(EmpInfo).ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PostAsync("api/HELLO/", content);
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<Student>(EmpResponse);
                }
            }
            return RedirectToAction("Index");
        }
    }
}