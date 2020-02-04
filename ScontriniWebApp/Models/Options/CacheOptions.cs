using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.Options
{
    public class CacheOptions : MemoryCacheOptions
    {
        public int ExpirationInSeconds { get; set; }
    }
}
