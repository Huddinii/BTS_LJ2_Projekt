using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Runtime.Remoting.Contexts;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows;

namespace BTS_LJ2_Projekt
{
    internal abstract class SQLCon
    {

        protected SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BTS_LJ2;Integrated Security=true");
        protected SqlCommand cmd;
        protected MainWindow mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        protected DataTable dt;
        protected string query;
        protected SqlDataAdapter dataAdapter;
        DataTable table = new DataTable();
        public SqlConnection Con { get { return con; } }
        public SqlCommand Cmd { get { return cmd; }  }



        public virtual void getData() 
        {
            this.cmd = new SqlCommand(query, this.Con);
            dataAdapter = new SqlDataAdapter(this.cmd);
            dt = new DataTable();
        }
        
    }
}
