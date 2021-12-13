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
    public partial class Pacientes : MetroForm
    {
        public Pacientes()
        {
            InitializeComponent();

            this.BorderStyle = MetroFormBorderStyle.FixedSingle;
            this.ShadowType = MetroFormShadowType.AeroShadow;
        }

        private void bt_nuevo_Click(object sender, EventArgs e)
        {

        }


        private void limpiartextos()
        {
            bt_guardar.Enabled = true;
            bt_editar.Enabled = false;
            bt_eliminar.Enabled = false;
            txt_documento.ReadOnly = false;
            txt_documento.Text = "";
            txt_nombres.Text = "";
            txt_apellidos.Text = "";
            txt_direccion.Text = "";
            txt_edad.Text = "";
            txt_estatura.Text = "";
            cb_sexo.Text = "";
            txt_peso.Text = "";
            cb_dieta.Text = "NO";
            cb_fumador.Text = "NO";
            txt_añosfumador.Text = "";
            lb_añosfumador.Visible = false;
            txt_añosfumador.Visible = false;
        }

        private void solonumeros(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        int PesoEstatura;
        private void calculaPesoEstatura()
        {
            int peso = Convert.ToInt32(txt_peso.Text);
            int estatura = Convert.ToInt32(txt_estatura.Text);
            Double pesoestatura = (double) peso / estatura;
            if (pesoestatura <= (0.25))
            {
                PesoEstatura = 0;
            }
            else if ((pesoestatura <= (0.50)))
            {
                PesoEstatura = 1;
            }
            else if ((pesoestatura <= (0.75)))
            {
                PesoEstatura = 2;
            }
            else if ((pesoestatura <= (1)))
            {
                PesoEstatura = 3;
            }
            else
            {
                PesoEstatura = 4;
            }
        }

        Double Prioridad;
        private void calculaPrioridad()
        {
            int edad = Convert.ToInt32(txt_edad.Text);
            if (edad <= (5))
            {
                Prioridad = PesoEstatura + 3;
            }
            else if ((edad <= (12)))
            {
                Prioridad = PesoEstatura + 2;
            }
            else if ((edad <= (15)))
            {
                Prioridad = PesoEstatura + 1;
            }
            else if ((edad <= (40)))
            {
                if (cb_fumador.Text.Equals("SI"))
                {
                    Prioridad = (double) Convert.ToInt32(txt_añosfumador.Text) / 4 + 2;
                }
                else
                {
                    Prioridad = 2;
                }
            }
            else
            {
                if ((cb_dieta.Text.Equals("SI")) && (edad >= 60 && edad <= 100))
                {
                    Prioridad = (double) edad / 20 + 4;
                }
                else
                {
                    Prioridad = (double) edad / 30 + 3;
                }
            }
        }

        Double Riesgo;
        private void calculaRiesgo()
        {
            int edad = Convert.ToInt32(txt_edad.Text);
            if (edad <= (40))
            {
                Riesgo = (double) edad * Prioridad / 100;
            }
            else
            {
                Riesgo = (double) edad * Prioridad / 100 + 5.3;
            }
        }
        private void bt_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!string.IsNullOrEmpty(txt_documento.Text)) && (!string.IsNullOrEmpty(txt_nombres.Text)) && (!string.IsNullOrEmpty(txt_apellidos.Text)) && (!string.IsNullOrEmpty(txt_edad.Text)) && (!string.IsNullOrEmpty(txt_peso.Text)) && (!string.IsNullOrEmpty(txt_estatura.Text)))
                {
                    calculaPesoEstatura();
                    calculaPrioridad();
                    calculaRiesgo();
                    int status = basededatos.Insertar_Pacientes(txt_documento.Text, txt_nombres.Text, txt_apellidos.Text,txt_edad.Text,txt_direccion.Text,cb_sexo.Text,txt_peso.Text,txt_estatura.Text,cb_fumador.Text,txt_añosfumador.Text,cb_dieta.Text,PesoEstatura.ToString(),"Pendiente",Riesgo.ToString(),Prioridad.ToString());
                    if (status == 1)
                    {
                        MessageBox.Show("Se ha registrado correctamente el paciente", "Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiartextos();
                    }
                    else if (status == 0)
                    {
                        MessageBox.Show("No se ha registrado el paciente", "Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    String validacion = "Ingrese";
                    if (!string.IsNullOrEmpty(txt_documento.Text))
                    {
                    }
                    else
                    {
                        validacion += "" + " el número de documento, ";
                    }
                    if (!string.IsNullOrEmpty(txt_nombres.Text))
                    {
                    }
                    else
                    {
                        validacion += "" + " los nombres, ";
                    }
                    if (!string.IsNullOrEmpty(txt_apellidos.Text))
                    {
                    }
                    else
                    {
                        validacion += "" + " los apellidos, ";
                    }
                    if (!string.IsNullOrEmpty(txt_edad.Text))
                    {
                    }
                    else
                    {
                        validacion += "" + " la edad, ";
                    }
                    if (!string.IsNullOrEmpty(txt_peso.Text))
                    {
                    }
                    else
                    {
                        validacion += "" + " el peso en kilogramos, ";
                    }
                    if (!string.IsNullOrEmpty(txt_estatura.Text))
                    {
                    }
                    else
                    {
                        validacion += "" + " la estatura en centímetros.";
                    }
                    MessageBox.Show(validacion, "Error De Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error De Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_fumador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_fumador.Text.Equals("SI"))
            {
                lb_añosfumador.Visible = true;
                txt_añosfumador.Text = "";
                txt_añosfumador.Visible = true;
            }
            else
            {
                lb_añosfumador.Visible = false;
                txt_añosfumador.Visible = false;
                txt_añosfumador.Text = "0";
            }
        }

        private void Pacientes_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ConsultarPaciente consul = new ConsultarPaciente(txt_documento.Text);
            consul.ShowDialog();
            if (consul.DialogResult == DialogResult.OK)
            {
                String idpaciente = consul.dg_consulta.Rows[consul.dg_consulta.CurrentRow.Index].Cells[0].Value.ToString();
                SqlCommand comando = new SqlCommand(String.Format("SELECT * FROM pacientes " +
                    "where documento='" + idpaciente + "';"), basededatos.ObtenerConexion());
                SqlDataReader MyReader = comando.ExecuteReader();
                while (MyReader.Read())
                {
                    txt_documento.Text = MyReader["Documento"].ToString();
                    txt_nombres.Text = MyReader["Nombres"].ToString();
                    txt_apellidos.Text = MyReader["Apellidos"].ToString();
                    txt_direccion.Text = MyReader["Direccion"].ToString();
                    txt_edad.Text = MyReader["Edad"].ToString();
                    txt_estatura.Text = MyReader["Estatura"].ToString();
                    cb_sexo.Text = MyReader["Sexo"].ToString();
                    txt_peso.Text = MyReader["Peso"].ToString();
                    cb_dieta.Text = MyReader["Dieta"].ToString();
                    cb_fumador.Text = MyReader["Fumador"].ToString();
                    txt_añosfumador.Text = MyReader["Añosfumador"].ToString();
                }
                this.bt_guardar.Enabled = false;
                txt_documento.ReadOnly = true;
                this.bt_editar.Enabled = true;
                this.bt_eliminar.Enabled = true;
            }
        }

        private void bt_editar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!string.IsNullOrEmpty(txt_documento.Text)) && (!string.IsNullOrEmpty(txt_nombres.Text)) && (!string.IsNullOrEmpty(txt_apellidos.Text)) && (!string.IsNullOrEmpty(txt_edad.Text)) && (!string.IsNullOrEmpty(txt_peso.Text)) && (!string.IsNullOrEmpty(txt_estatura.Text)))
                {
                    calculaPesoEstatura();
                    calculaPrioridad();
                    calculaRiesgo();
                    int status = basededatos.editar_Pacientes(txt_documento.Text, txt_nombres.Text, txt_apellidos.Text, txt_edad.Text, txt_direccion.Text, cb_sexo.Text, txt_peso.Text, txt_estatura.Text, cb_fumador.Text, txt_añosfumador.Text, cb_dieta.Text, PesoEstatura.ToString(), "Pendiente", Riesgo.ToString(), Prioridad.ToString());
                    if (status == 1)
                    {
                        MessageBox.Show("Se ha editado correctamente el paciente", "Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiartextos();
                    }
                    else if (status == 0)
                    {
                        MessageBox.Show("No se editado el paciente", "Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    String validacion = "Ingrese";
                    if (!string.IsNullOrEmpty(txt_documento.Text))
                    {
                    }
                    else
                    {
                        validacion += "" + " el número de documento, ";
                    }
                    if (!string.IsNullOrEmpty(txt_nombres.Text))
                    {
                    }
                    else
                    {
                        validacion += "" + " los nombres, ";
                    }
                    if (!string.IsNullOrEmpty(txt_apellidos.Text))
                    {
                    }
                    else
                    {
                        validacion += "" + " los apellidos, ";
                    }
                    if (!string.IsNullOrEmpty(txt_edad.Text))
                    {
                    }
                    else
                    {
                        validacion += "" + " la edad, ";
                    }
                    if (!string.IsNullOrEmpty(txt_peso.Text))
                    {
                    }
                    else
                    {
                        validacion += "" + " el peso en kilogramos, ";
                    }
                    if (!string.IsNullOrEmpty(txt_estatura.Text))
                    {
                    }
                    else
                    {
                        validacion += "" + " la estatura en centímetros.";
                    }
                    MessageBox.Show(validacion, "Error De Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error De Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_eliminar_Click(object sender, EventArgs e)
        {
            string Borrar = "delete from pacientes where documento = '" + txt_documento.Text + "';";
            SqlCommand ComandBorrar = new SqlCommand(Borrar, basededatos.ObtenerConexion());
            SqlDataReader MyReader;
            MyReader = ComandBorrar.ExecuteReader();
            while (MyReader.Read())
            {
            }
            limpiartextos();
            MessageBox.Show("Se ha eliminado el paciente", "Eliminación de paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
