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
                        var insertString = $@"INSERT INTO DB1.dbo.Person VALUES({word[0]}, '{word[1]}', '{word[2]}', {word[3]});"; //jak zrobić w SQL zeby ID sie samo inkrementowalo ? 
                        var cmd = new SqlCommand(insertString, conn); //o co chodzi z DB1.dbo.Person ? 
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception e)
            {
               //co tutaj wpisywac ?
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