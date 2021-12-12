using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoCntWinforms
{
    class basededatos
    {

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conectar = new SqlConnection("Server=(local); database=CntNetCore; Integrated Security = True;MultipleActiveResultSets=true");
            conectar.Open();
            return conectar;
        }




    }
}
