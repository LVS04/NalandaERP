using System;
using System.Reflection;
using System.Data.Common;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;



namespace DNXTest.Dal
{

    public static class PGUtil
    {

        public static bool SanitizeParamPostgres(string param)
        {

            if ( param == null ) return true;

            string[] _BLACK_LIST_ = { "/*", "*/", "--", ";", "0x", "*", "(", ")", "_", "+", "@", "pg", "concat", "char", "chr", "hex", "ascii", "drop", "truncate", "table", "if ", "union", "all", "use", "collate", "dbo", "admin", "md5", "having", "by", "order by", "null", "cast", "convert", "insert", "into", "values", "delete", "substring", "create", "exec", "postgres", "declare", "limit", "select", "top", "update", "varchar", "aspnet" };

            param = param.ToLower();

            foreach (string badString in _BLACK_LIST_)
            {
                if (param.Contains(badString)) return false;
            }
            return true;
        }

        public static bool SanitizeParamPostgres(string[] paramArray)
        {
            if ( paramArray == null ) return true;

            foreach (string param in paramArray)
            {
                if (!SanitizeParamPostgres(param))
                    return false;
            }

            return true;
        }

        public static IEnumerable<Dictionary<string, object>> Serialize(NpgsqlDataReader reader)
        {
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRow(cols, reader));

            return results;
        }

        private static Dictionary<string, object> SerializeRow(IEnumerable<string> cols, NpgsqlDataReader reader)
        {
            var result = new Dictionary<string, object>();
            foreach (var col in cols)
                result.Add(col, reader[col]);
            return result;
        }

        public static IEnumerable<Dictionary<string, object>> QueryToEnumerable(string query)
        {
            return Serialize(RunQuery(query));
        }

        public static int RunCountQuery(string query)
        {
            NpgsqlDataReader dataReader = RunQuery(query);
            dataReader.Read();
            if (!dataReader.HasRows) return 0;
            int count = dataReader.GetInt32(0);
            dataReader.Close();
            return count;
        }

        public static NpgsqlDataReader RunQuery(string query)
        {
            //  Fetch ConnectionStringzezeze
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json").Build();
            var connectionStringConfig = builder.Build();

            var setting = connectionStringConfig["Data:Direct:ConnectionString"];

            NpgsqlConnection conn = new NpgsqlConnection(setting);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(query, conn);

            NpgsqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            return dr;
        }
    }
}
