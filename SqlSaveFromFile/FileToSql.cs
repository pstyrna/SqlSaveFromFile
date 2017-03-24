using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSaveFromFile
{
    class FileToSql : IFileToSql
    {
        public void SaveToSql(string file, string sqlConnection)
        {
            var fileContent = File.ReadAllText(file);
            try
            {
                using (var conn = new SqlConnection(sqlConnection))
                {
                    foreach (var line in SplitToLines(fileContent))
                    {
                        var word = line.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                        var insertString = $@"INSERT INTO DB1.dbo.Person VALUES({word[0]}, '{word[1]}', '{word[2]}', {word[3]});";
                        var cmd = new SqlCommand(insertString, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occre while creating table:" + e.Message + "\t" + e.GetType());
            }
        }

        public static IEnumerable<string> SplitToLines(string input)
        {
            if (input == null)
            {
                yield break;
            }

            using (var reader = new System.IO.StringReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}