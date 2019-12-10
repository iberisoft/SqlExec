using SqlExec.Properties;
using System;
using System.Data.SqlClient;
using System.IO;

namespace SqlExec
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1 && File.Exists(args[0]))
            {
                try
                {
                    RunScript(args[0]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Usage: SqlExec script-file");
            }
        }

        private static void RunScript(string scriptFilePath)
        {
            using (var connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = File.ReadAllText(scriptFilePath);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
