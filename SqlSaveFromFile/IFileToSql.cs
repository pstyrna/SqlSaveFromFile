using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSaveFromFile
{
    interface IFileToSql
    {
        void SaveToSql(string file, string sqlConnection);
    }
}
