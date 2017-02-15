﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmLoginAdmin : Form
    {
        public frmLoginAdmin()
        {
            InitializeComponent();
        }

        private void frmLoginAdmin_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
            lblPassError.Hide();
            lblUserError.Hide();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Modulo.miNegocio.getAdministrador(txtUser.Text, txtPass.Text) != null)
            {
                (new frmConfig()).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            (new frmMenu()).Show();
            this.Close();
        }
    }
}
