using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Data.SqlClient;

namespace BTS_LJ2_Projekt
{
    internal class SQLManual : SQLCon
    {
        SqlCommand cmd;
        SQLManual()
        {
            this.Con.Open();
        }
        public override void getData()
        {
            throw new NotImplementedException();
        }
        public void Insert(string Table,string Fields, string Values)
        {
            string query = $"INSERT INTO dbo.{Table} ({Fields}) VALUES ({Values})";
            cmd = new SqlCommand(query,this.Con);
        }

        ~SQLManual() 
        {
            this.Con.Close();
        }
    }
}
