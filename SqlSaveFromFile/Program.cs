using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSaveFromFile
{
    class Program
    {
        const string FileUrl = @"D:\SqlAdd.txt";
        const string Database = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void Main(string[] args)
        {
            var iFileToSql = new FileToSql();

            iFileToSql.SaveToSql(FileUrl, Database);

        }
    }
}
