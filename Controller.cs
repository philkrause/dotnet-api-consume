using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
namespace atlas_backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FetchController : ControllerBase
  {
    public class Attraction
    {
      public string location { get; set; }
      public string name { get; set; }
      public string description { get; set; }
      public List<double> coordinates { get; set; }
      public string img { get; set; }
      public string path { get; set; }
    }
    public class RootObject
    {
      public string status { get; set; }
      public int results { get; set; }
      public List<Attraction> Attractions { get; set; }
    }
    [HttpGet]
    public async Task<RootObject> GetAsync()
    {
      var API_URL = "https://atlas-obscura-api.herokuapp.com/api/atlas/attractions/United-States?state=florida&sort=recent";
      using (HttpClient client = new HttpClient())
      using (HttpResponseMessage response = await client.GetAsync(API_URL))
      using (HttpContent content = response.Content)
      {
        string str = await content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<RootObject>(str);
        Console.WriteLine(result);
        return result;
      }
    }
  }
}