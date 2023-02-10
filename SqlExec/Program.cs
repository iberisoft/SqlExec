using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace SqlExec
{
    static class Program
    {
        static Settings m_Settings;

        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            m_Settings = config.Get<Settings>();

            if (args.Length > 0 && File.Exists(args[0]))
            {
                try
                {
                    RunScript(args[0], args.Length > 1 ? args[1] : null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Usage: SqlExec script-file [output-file]");
            }
        }

        private static void RunScript(string scriptFilePath, string outputFilePath)
        {
            using (var connection = new SqlConnection(m_Settings.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = File.ReadAllText(scriptFilePath);
                    Console.WriteLine(command.CommandText);
                    if (outputFilePath != null)
                    {
                        WriteQueryRowsToFile(command, outputFilePath);
                    }
                    else
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private static void WriteQueryRowsToFile(SqlCommand command, string outputFilePath)
        {
            using (var writer = new StreamWriter(outputFilePath))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var line = string.Join(",", GetStringValues(reader));
                        writer.WriteLine(line);
                        Console.WriteLine(line);
                    }
                }
            }
        }

        private static IEnumerable<string> GetStringValues(SqlDataReader reader)
        {
            for (var i = 0; i < reader.FieldCount; ++i)
            {
                yield return reader.GetValue(i).ToString();
            }
        }
    }
}
