using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ClienteWebApiLibrero.Models;
using Newtonsoft.Json;


namespace ClienteWebApiLibrero.Controllers
{
    public class BooksController : Controller
    {
        //URL WebApi
        string BaseUrl = "https://fakerestapi.azurewebsites.net/";

        public async Task<ActionResult> Index()
        {
            List<Books> bookInfo = new List<Books>();
            using (var cli = new HttpClient())
            {
                cli.BaseAddress = new Uri(BaseUrl);
                cli.DefaultRequestHeaders.Clear();
                cli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Obtiene todos los libros usando el httpClient
                HttpResponseMessage res = await cli.GetAsync("api/v1/Books/");
                if (res.IsSuccessStatusCode)
                {
                    //asignacion
                    var bookResponse = res.Content.ReadAsStringAsync().Result;
                    bookInfo = JsonConvert.DeserializeObject<List<Books>>(bookResponse);
                }

                //Muestra la lista
                return View(bookInfo);
            }
        }
    }
}