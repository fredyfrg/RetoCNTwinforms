using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetoCntWinforms
{
    public partial class Riesgo : MetroForm
    {
        public Riesgo()
        {
            InitializeComponent();
            this.BorderStyle = MetroFormBorderStyle.FixedSingle;
            this.ShadowType = MetroFormShadowType.AeroShadow;
        }

        private void Riesgo_Load(object sender, EventArgs e)
        {
            busqueda();
        }

        private void busqueda()
        {
            String busqueda = "select Documento, Nombres, Apellidos, Edad, Direccion, Sexo, Peso, Estatura, Fumador, añosfumador as 'Años fumando', Dieta, Riesgo from pacientes WHERE (Estado ='Pendiente') ORDER BY Riesgo DESC ; ";
            SqlCommand comando = new SqlCommand(busqueda, basededatos.ObtenerConexion());
            SqlDataAdapter MyAdapter = new SqlDataAdapter();
            MyAdapter.SelectCommand = comando;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            dg_consulta.DataSource = dTable;
            int num = dg_consulta.Rows.Count;
            lb_total.Text = num.ToString();
            lb_menoredad.Text = "Paciente con menor edad: " + basededatos.Menoredadpendiente();
            lb_mayoredad.Text = "Paciente con mayor edad: " + basededatos.Mayoredadpendiente();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            String idpaciente = dg_consulta.Rows[dg_consulta.CurrentRow.Index].Cells[0].Value.ToString();
            String consupdate = "update pacientes set Estado='Atendido' where documento=@Id;";
            SqlCommand comando = new SqlCommand(consupdate, basededatos.ObtenerConexion());
            comando.Parameters.AddWithValue("@Id", idpaciente);
            comando.ExecuteNonQuery();
            busqueda();
            MessageBox.Show("Paciente atendido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
