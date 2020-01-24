using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.Services.Infrastructure
{
    public interface IDatabaseManager
    {
        void Query(string query);
    }
}
