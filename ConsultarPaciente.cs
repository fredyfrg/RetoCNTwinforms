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
    public partial class ConsultarPaciente : MetroForm
    {
        public ConsultarPaciente(String Documento)
        {
            InitializeComponent();
            txt_docpaciente.Text = Documento;
        }

        private void ConsultarPaciente_Load(object sender, EventArgs e)
        {
            buscarlictotal(txt_docpaciente.Text);
        }
        private void buscarlictotal(String docpaciente)
        {
            if (docpaciente.Equals(""))
            {
                docpaciente = "%";
            }

            String busqueda = "select Documento, Nombres, Apellidos, Edad, Direccion, Sexo, Peso, Estatura, Fumador, añosfumador as 'Años fumando', Dieta from pacientes where documento like '" + docpaciente + "%' ; ";
            SqlCommand comando = new SqlCommand(busqueda, basededatos.ObtenerConexion());
            SqlDataAdapter MyAdapter = new SqlDataAdapter();
            MyAdapter.SelectCommand = comando;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            dg_consulta.DataSource = dTable;
            int num = dg_consulta.Rows.Count;
            lb_total.Text = num.ToString();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            buscarlictotal(txt_docpaciente.Text);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (dg_consulta.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void txt_docpaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            buscarlictotal(txt_docpaciente.Text);
        }
    }
}
