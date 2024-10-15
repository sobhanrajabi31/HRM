using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;

namespace Project
{
    class db_connection
    {
        public static string connection_string = "Provider=Microsoft.Jet.Oledb.4.0; Data Source=project.mdb;";

        public static OleDbConnection connection = new OleDbConnection(connection_string);
    }
}
