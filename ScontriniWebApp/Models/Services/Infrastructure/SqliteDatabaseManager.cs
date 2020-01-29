using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.Services.Infrastructure
{
    public class SqliteDatabaseManager : IDatabaseManager
    {
        public async Task<DataSet> QueryAsync(FormattableString formattableQuery)
        {

            var queryArguments = formattableQuery.GetArguments();
            var sqliteParamaters = new List<SqliteParameter>();
            for (int i = 0; i < queryArguments.Length; i++)
            {
                var parameter = new SqliteParameter(i.ToString(), queryArguments[i]);
                sqliteParamaters.Add(parameter);
                queryArguments[i] = "@" + i;
            }
            string query = formattableQuery.ToString();

            using (var conn = new SqliteConnection("Data Source=Data/ScontriniWebApp.db"))
            {
                await conn.OpenAsync();
                using(var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddRange(sqliteParamaters);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        var dataSet = new DataSet();
                        var dataTable = new DataTable();
                        dataSet.Tables.Add(dataTable);
                        dataTable.Load(reader);
                        return dataSet;
                    }
                }
            }
        }
    }
}
