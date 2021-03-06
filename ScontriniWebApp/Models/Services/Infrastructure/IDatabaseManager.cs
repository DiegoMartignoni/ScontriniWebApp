﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.Services.Infrastructure
{
    public interface IDatabaseManager
    {
        Task<DataSet> QueryAsync(FormattableString formattableQuery);
    }
}
