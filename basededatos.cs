using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static int Insertar_Pacientes(String Documento, String Nombres, String Apellidos, String Edad, String Direccion, String Sexo, String Peso, String Estatura, String Fumador, String Añosfumador, String Dieta, String PesoEstatura, String Estado, String Riesgo, String Prioridad)
        {
            int registro;
            try
            {
                SqlCommand cmd = new SqlCommand("Insertar_Pacientes", basededatos.ObtenerConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Documento", Documento);
                cmd.Parameters.AddWithValue("@Nombres", Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                cmd.Parameters.AddWithValue("@Edad", Edad);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Sexo", Sexo);
                cmd.Parameters.AddWithValue("@Peso", Peso);
                cmd.Parameters.AddWithValue("@Estatura", Estatura);
                cmd.Parameters.AddWithValue("@Fumador", Fumador);
                cmd.Parameters.AddWithValue("@Añosfumador", Añosfumador);
                cmd.Parameters.AddWithValue("@Dieta", Dieta);
                cmd.Parameters.AddWithValue("@PesoEstatura", PesoEstatura);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@Riesgo", Riesgo);
                cmd.Parameters.AddWithValue("@Prioridad", Prioridad);
                registro = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                registro = 0;
            }
            return registro;
        }

        public static int editar_Pacientes(String Documento, String Nombres, String Apellidos, String Edad, String Direccion, String Sexo, String Peso, String Estatura, String Fumador, String Añosfumador, String Dieta, String PesoEstatura, String Estado, String Riesgo, String Prioridad)
        {
            int registro;
            try
            {
                SqlCommand cmd = new SqlCommand("editar_Pacientes", basededatos.ObtenerConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Documento", Documento);
                cmd.Parameters.AddWithValue("@Nombres", Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                cmd.Parameters.AddWithValue("@Edad", Edad);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Sexo", Sexo);
                cmd.Parameters.AddWithValue("@Peso", Peso);
                cmd.Parameters.AddWithValue("@Estatura", Estatura);
                cmd.Parameters.AddWithValue("@Fumador", Fumador);
                cmd.Parameters.AddWithValue("@Añosfumador", Añosfumador);
                cmd.Parameters.AddWithValue("@Dieta", Dieta);
                cmd.Parameters.AddWithValue("@PesoEstatura", PesoEstatura);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@Riesgo", Riesgo);
                cmd.Parameters.AddWithValue("@Prioridad", Prioridad);
                registro = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                registro = 0;
            }
            return registro;
        }

    }
}
