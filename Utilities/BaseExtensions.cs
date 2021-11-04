using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Utilities
{
    public static class BaseExtensions
    {
        public static string Random(this string[] list)
        {
            var rand = new Random();
            var randomIndex = rand.Next(0, list.Length);
            return list[randomIndex];
        }

        public static DateTime Random(this DateTime datetime)
        {
            return datetime;
        }
    }
}
