using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ScontriniWebApp.Models.Options
{

    public partial class ReceiptsOptions
    {
        public int PerPage { get; set; }

        public OrderOptions Order { get; set; }
    }

    public partial class OrderOptions
    {
        public string By { get; set; }

        public bool Ascending { get; set; }

        public string[] Allow { get; set; }
    }
}
