using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace amir_apparel_demo_api_dotnet_5.Controllers
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("https://localhost:5001", "*", "GET, POST");
            config.EnableCors(cors);
        }
    }
}
