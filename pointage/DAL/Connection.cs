using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace pointage.DAL
{
    class Connection
    {
        public OleDbConnection cnx = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb;Persist Security Info=False;");
        public void openConnection()
        {
            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
        }
        public void closeConnection()
        {
            if (cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
        }
    }
}
