﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Citas
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario;
            string contrasena;

            usuario = textBox1.Text;
            contrasena = textBox2.Text;

            if (usuario == "admin" && contrasena == "123")
            {
                this.Close();
            }
            else if (usuario == "doctor" && contrasena == "passport")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}
