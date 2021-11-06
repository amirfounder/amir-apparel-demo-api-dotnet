﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.API.CustomQueries
{
    public interface IPaginationOptions
    {
        public int Page { get; set; }

        public int Size { get; set; }

        public string[] Sort { get; set; }
    }
}
