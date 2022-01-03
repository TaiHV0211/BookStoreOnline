using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.Areas.Admin.Models
{
    public class ConnectionDB
    {
        SqlConnection con = new SqlConnection("Server=.;Database=BookStore;Integrated Security=true;");
        public DataTable GetRecord()
        {
            SqlCommand com = new SqlCommand("select * from Categories", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
