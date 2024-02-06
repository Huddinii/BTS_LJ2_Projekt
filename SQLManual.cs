using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.Data;
using System.Data.Common;
using System.Windows;

namespace BTS_LJ2_Projekt
{
    internal class SQLManual : SQLCon
    {
        SqlCommand cmd;
        DataTable dt;
        MainWindow mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        public SQLManual()
        { }
        public override void getData()
        {
            throw new NotImplementedException();
        }
        public void Insert(string Table,string Fields, string Values)
        {
            string query = $"INSERT INTO dbo.{Table} ({Fields}) VALUES ({Values})";
            cmd = new SqlCommand(query,this.Con);
        }

        public bool Login(string username, string password)
        {
            string query = $"SELECT * FROM USER WHERE Username={username} and Password={password}";
            cmd = new SqlCommand (query,this.Con);
            cmd.Connection.Open();

            if (cmd.ExecuteNonQuery() > 0)
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dt.Columns.Add(new DataColumn("username"));
                dt.Columns.Add(new DataColumn("password"));
                dt.Columns.Add(new DataColumn("name"));
                dt.Columns.Add(new DataColumn("lastname"));
                dataAdapter.Fill(dt);

                mw.usr = new User(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(),dt.Rows[0][2].ToString(),dt.Rows[0][3].ToString());

                return true;
            }
            else return false;

        }
    }
}
