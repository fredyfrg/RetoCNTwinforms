using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetoCntWinforms
{
    public partial class MenuUss : Form
    {
        String Codus;
        Int32 nrol;
        public MenuUss(String id, Int32 rol)
        {
            InitializeComponent();
            Codus = id;
            nrol = rol;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            lbNombre.Text = basededatos.ConsultanombresUsuario(Codus);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login log = new Login();
            log.Show();
        }

        private void AbrirFormEnPanel(object Formhijo)
        {
            if(this.Panelcontenedor.Controls.Count > 0)
                this.Panelcontenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Panelcontenedor.Controls.Add(fh);
            this.Panelcontenedor.Tag = fh;
            fh.Show();
        }
        private void RUR_Click(object sender, EventArgs e)
        {
            RUR rur = new RUR(Codus, nrol);
            rur.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(rur);
            //AbrirFormEnPanel(new RUR(Codus, nrol));
        }

        private void MostrarFormLogo()
        {
            AbrirFormEnPanel(new Logos());
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            MostrarFormLogo();
            tmFecha.Start();
            MenuNodos.IsMainMenu = true;
            MenuUsuarios.IsMainMenu = true;
            MenuNodos.Items.Clear();
            
            //ToolStripMenuItem item,item2, submenu;
            
            //SqlCommand comando = new SqlCommand(String.Format("select id_lugar as lugar, descripcion from Nodos where nivel = 0;"), basededatos.ObtenerConexion());
            //SqlDataReader MyReader;
            //MyReader = comando.ExecuteReader();
            //while (MyReader.Read())
            //{
            //    submenu = new ToolStripMenuItem();
            //    submenu.Text = MyReader["descripcion"].ToString();
            //    string cabecera = MyReader["lugar"].ToString();
            //    SqlCommand comando2 = new SqlCommand(String.Format("select id_lugar as lugar, descripcion from Nodos where nivel=2 and cabecera='"+cabecera+"';"), basededatos.ObtenerConexion());
            //    SqlDataReader MyReader2;
            //    MyReader2 = comando2.ExecuteReader();
            //    while (MyReader2.Read())
            //    {
            //        item = new ToolStripMenuItem();
            //        item.Text = MyReader2["descripcion"].ToString();
            //        string cabecera2 = MyReader2["lugar"].ToString();
            //        SqlCommand comando3 = new SqlCommand(String.Format("select id_lugar as lugar, descripcion from Nodos where nivel=1 and cabecera='" + cabecera2 + "';"), basededatos.ObtenerConexion());
            //        SqlDataReader MyReader3;
            //        MyReader3 = comando3.ExecuteReader();
            //        while (MyReader3.Read())
            //        {
            //            item2 = new ToolStripMenuItem();
            //            item2.Text = MyReader3["descripcion"].ToString();
            //            item.DropDownItems.Add(item2);
            //        }
            //        submenu.DropDownItems.Add(item);
            //    }
            //    MenuNodos.Items.Add(submenu);
            //}
        }

        private void MostrarFormLogoAlCerrarForms(object sender, FormClosedEventArgs e)
        {
            MostrarFormLogo();
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            MostrarFormLogo();
        }

        private void Barratitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Historico his = new Historico(Codus, nrol);
            his.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(his);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://192.168.0.8:82/hesk/");
            //Pruebaa.Show(button8, button8.Width, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Novedades nov = new Novedades(Codus, nrol);
            nov.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(nov);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EnvioCorreo env = new EnvioCorreo(Codus, nrol);
            env.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(env);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 50;
                pictureBox2.Image = global::MetroFramework.Demo.Properties.Resources.menu;
                lblHora.Visible = false;
                lbFecha.Visible = false;
            }
            else
            {
                MenuVertical.Width = 250;
                pictureBox2.Image = global::MetroFramework.Demo.Properties.Resources.menu1;
                lblHora.Visible = true;
                lbFecha.Visible = true;
            }
        }

        private void tmFecha_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void ubatéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbNodo.Text = "Ubaté";
        }

        private void MenuNodos_Opening(object sender, CancelEventArgs e)
        {

        }

        private void zipaquiráToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nrol == 1)
            {
                CrearUsuario us = new CrearUsuario(Codus, nrol);
                us.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
                AbrirFormEnPanel(us);
            }
            else
            {
                MessageBox.Show("Su usuario no cuenta con permisos para usar este modulo", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nrol == 1)
            {
                ModificarUsuarios us = new ModificarUsuarios(Codus, nrol);
                us.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
                AbrirFormEnPanel(us);
            }
            else
            {
                MessageBox.Show("Su usuario no cuenta con permisos para usar este modulo", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MenuUsuarios.Show(button10, button10.Width, 0);
        }

        private void MenuNodos_Click(object sender, EventArgs e)
        {
            
        }

        private void Pruebaa_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            

        }

        private void MenuNodos_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            lbNodo.Text = e.ClickedItem.Text;
        }

        private void MenuNodos_Click_1(object sender, EventArgs e)
        {
            

        }
    }
}
