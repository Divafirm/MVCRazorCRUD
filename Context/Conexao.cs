using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRazorCRUD.Context
{
    public class Conexao
    {
        //private static string ConnStr = @"Data Source=LAB07-PC03\SERVIDORTARDE;Initial Catalog=EscolaSenai;Integrated Security=True";
        private static string ConnStr = @"Data Source=DIVANILDO-NOTE\SERVIDOR_DIVAN;Initial Catalog=EscolaSenai;Integrated Security=True";
        public static SqlConnection GetConnect()
        {
            var conn = new SqlConnection(ConnStr);
            return conn;
        }
    }
}
