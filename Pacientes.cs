using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void bt_nuevo_Click(object sender, EventArgs e)
        {

        }

        private void limpiartextos()
        {
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
            lb_añosfumador.Enabled = false;
            txt_añosfumador.Enabled = false;
        }

        private void bt_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!string.IsNullOrEmpty(txt_documento.Text)) && (!string.IsNullOrEmpty(txt_nombres.Text)) && (!string.IsNullOrEmpty(txt_apellidos.Text)) && (!string.IsNullOrEmpty(txt_edad.Text)) && (!string.IsNullOrEmpty(txt_peso.Text)) && (!string.IsNullOrEmpty(txt_estatura.Text)))
                {
                    
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
    }
}
