using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BTS_LJ2_Projekt
{
    internal abstract class SQLCon
    {
        
        protected SqlConnection con = new SqlConnection(@"Data Source=HUDDINI\SQLEXPRESS;Initial Catalog=BTS_LJ2;Integrated Security=true");
        
        DataTable table = new DataTable();

        public SqlConnection Con { get { return con; } }
        

        
        public abstract void getData();
    }
}
