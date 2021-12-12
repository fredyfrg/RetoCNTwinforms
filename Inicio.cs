using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RetoCntWinforms
{
    public partial class Inicio : MetroForm
    {
        public Inicio()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            //label1.Text = "" + circularProgressBar1.Value + " %";
            this.Opacity = this.Opacity + .02;
            if (circularProgressBar1.Value < circularProgressBar1.Maximum)
            {
                circularProgressBar1.Value = circularProgressBar1.Value + 1;
                //circleprogressBar1.Value = circleprogressBar1.Value + 1;
            }
            else
            { 
                ////timer1.Enabled = false;                
                //timer1.Stop();
                ////this.Hide();
                //Login iniciosesion = new Login();
                //iniciosesion.Show();
                //this.Hide();
            }
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
