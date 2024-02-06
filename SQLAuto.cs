using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BTS_LJ2_Projekt
{
    internal class SQLAuto : SQLCon
    {

        public SQLAuto()
        {

        }
        public override void getData()
        {
            string query = $"SELECT * FROM [RESTAURANTS]"; 
            this.cmd = new SqlCommand(query, this.Con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(this.cmd);
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name"));
            dt.Columns.Add(new DataColumn("Adress"));
            dt.Columns.Add(new DataColumn("Website"));
            dataAdapter.Fill(dt);
            int test = dt.Rows.Count;
            Console.WriteLine(test.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Restaurant res = new Restaurant(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString());
                mw.restaurants.Add(res);
            }
        }
    }
}
