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
        public SQLManual()
        {
            this.con.Open();
        }
        public override void getData()
        {
            throw new NotImplementedException();
        }
        public void Insert(string Table,string[] Fields, string[] Values)
        {
            string fields = "";
            string values = "";
            for (int i = 0; i < Fields.Length; i++)
            {
                if (i != 0)
                {
                    fields += $",{Fields[i]}";
                    values += $",@{Fields[i]}";
                }
                else
                {
                    fields = $"{Fields[i]}";
                    values = $"@{Fields[i]}";
                }
            }
            string query = $"INSERT INTO [{Table}] ({fields}) VALUES ({values})";
            this.cmd = new SqlCommand(query,this.Con);
            for (int i = 0; i < Fields.Length; i++)
            {
                this.cmd.Parameters.AddWithValue($"@{Fields[i]}", $"{Values[i]}");
            }
            this.cmd.ExecuteNonQuery();
            this.cmd.Connection.Close();
            Login(Values[0], Values[1]);
        }

        public bool Login(string username, string password)
        {
            string query = $"SELECT * FROM [USER] WHERE Username='{username}' AND Password='{password}'";
            this.cmd = new SqlCommand (query,this.Con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(this.cmd);
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("username"));
            dt.Columns.Add(new DataColumn("password"));
            dt.Columns.Add(new DataColumn("name"));
            dt.Columns.Add(new DataColumn("lastname"));
            dataAdapter.Fill(dt);
            int test = dt.Rows.Count;
            Console.WriteLine(test.ToString());
            if (dt.Rows.Count>0)
            {
                mw.usr = new User(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(),dt.Rows[0][2].ToString(),dt.Rows[0][3].ToString());

                return true;
            }
            else return false;

        }
    }
}
