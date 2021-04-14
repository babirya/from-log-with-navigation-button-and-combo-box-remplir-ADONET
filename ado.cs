using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace country2
{
    class ado
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader rd;
        public DataTable dt = new DataTable(); 

        // connecter  
        public void connecter()
        {
            if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed) 
            {
                con.ConnectionString = @"Data Source=DESKTOP-3GHSQJ4\SQLEXPRESS;Initial Catalog=devtech2;Integrated Security=True";
                con.Open(); 
            }

        }
        // deconnecter

        public void deconnecter()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

        }
    }
}
