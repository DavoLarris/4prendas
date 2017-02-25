﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using System.IO;

namespace CapaPresentacion
{
    public partial class frmRegistro : Form
    {
        private List<Familia> familias;
        private List<Recogida> recogidas;

        public frmRegistro()
        {
            InitializeComponent();

            lblCodArticulo.Text = "2231014";

            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            hacerGboSubFamInvisible();
            cargarRecogidas();
            cargarEmpleados();
            cargarFamilias();

        }

        private void hacerGboSubFamInvisible()
        {
            foreach (Control c in gboSubfamilia.Controls)
            {
                c.Hide();
            }
        }

        private void cargarRecogidas()
        {
            recogidas = Modulo.miNegocio.getRecogidasSinTodosRegistros();
            cboRecogida.DataSource = recogidas;
            cboRecogida.DisplayMember = "IdRecogida";
        }

        private void cargarEmpleados()
        {
            this.cmbEmpleado.SelectedIndexChanged -= new EventHandler(cmbEmpleado_SelectedIndexChanged);
            cmbEmpleado.DataSource = Modulo.empleados;
            this.cmbEmpleado.SelectedIndexChanged += new EventHandler(cmbEmpleado_SelectedIndexChanged);
            cmbEmpleado.DisplayMember = "nombre";
            cmbEmpleado.SelectedItem = Modulo.empleadoActual;
        }

        private void cargarFamilias()
        {
            familias = Modulo.miNegocio.getFamiliasSubfamilias();

            for (int i = gboFamilia.Controls.Count - 1, j = 0; i >= 0; i--, j++)
            {
                if (j <= familias.Count - 1)
                {
                    Familia f = familias[j];
                    gboFamilia.Controls[i].Tag = f;
                    gboFamilia.Controls[i].BackgroundImage = !f.Imagen.Equals("") && File.Exists(f.Imagen) ? Image.FromFile(f.Imagen) : null;
                    gboFamilia.Controls[i].Text = f.CodFamilia;
                    gboFamilia.Controls[i].Click += new EventHandler(cargarSubfamilias);

                }
                else
                {
                    gboFamilia.Controls[i].Hide();
                }

            }
        }

        private void cargarSubfamilias(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Familia f = (Familia)b.Tag;

            for (int i = 0, j = 0; i < gboSubfamilia.Controls.Count; i++, j++)
            {
                if (j < f.SubFamilias.Count)
                {
                    gboSubfamilia.Controls[i].Show();
                    SubFamilia s = f.SubFamilias[j];
                    gboSubfamilia.Controls[i].Tag = s;
                    gboSubfamilia.Controls[i].BackgroundImage = !s.Imagen.Equals("") && File.Exists(s.Imagen) ? Image.FromFile(s.Imagen) : null;
                    gboSubfamilia.Controls[i].Text = s.CodSubFamilia;
                    gboSubfamilia.Controls[i].Click += new EventHandler(cargarProductosSubfam);
                }
                else
                {
                    gboSubfamilia.Controls[i].Hide();
                }

            }

        }

        private void cargarProductosSubfam(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            SubFamilia s = (SubFamilia)b.Tag;

            Familia f = familias.Where((fam) => fam.CodFamilia.ToLower().Equals(s.CodFamilia.ToLower())).SingleOrDefault();

            if (lblCodArticulo.Text.Length != 7)
            {
                lblCodArticulo.Text = "2231014";
            }

            //int id = Modulo.miNegocio.getSiguienteID(s.CodFamilia, s.CodSubfamilia);
            //lblCodArticulo.Text += s.NumeroCodigo.ToString() + f.NumCodigo.ToString() + id.toString();

            if (chb.Checked)
            {
                cargarProductos(s);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {

            if (hayErrores())
            {
                MessageBox.Show("Los campos obligatorios deben ser introducidos.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Producto producto = new Producto();
            Lugar lugar = new Lugar(txtEstanteria.Text, int.Parse(nudEstante.Value.ToString()), int.Parse(nudAltura.Value.ToString()));

            producto.CodigoArticulo = lblCodArticulo.Text;
            producto.Coste = int.Parse(nudCoste.Text);
            producto.Descripcion = txtDescripcion.Text;
            producto.Medida = txtMedida.Text;
            producto.Stock = int.Parse(nudUnidades.Text);
            producto.EmpleadoId = ((Empleado)cmbEmpleado.SelectedItem).EmpleadoId;
            producto.FechaEntrada = DateTime.Now;
            producto.RecogidaId = ((Recogida)cboRecogida.SelectedItem).IdRecogida;
            string codfamilia = producto.CodigoArticulo.Substring(8, 10);
            producto.CodFamilia = codfamilia;
            string codsubfamilia = producto.CodigoArticulo.Substring(10, 12);
            producto.CodSubFamilia = codsubfamilia;
            //Lugar lugar =  Modulo.miNegocio.comprobarLugar(lugar);
            //producto.LugarId = lugar.id;

            /*
            Lugar lugarFinal;
            string sql = "SELECT Count(IdLugar) FROM Lugar WHERE Estanteria = @estanteria AND Estante = @estante AND Altura = @altura";
            OleDbConnection conTabla = new OleDbConnection(cadenaConexion);
            OleDbCommand cmd = new OleDbCommand(sql, conTabla);
            cmd.Parameters.AddWithValue("@estanteria", lugar.Estanteria);
            cmd.Parameters.AddWithValue("@estante", lugar.Estante);
            cmd.Parameters.AddWithValue("@altura", lugar.Altura);
            try
            {
                conTabla.Open();
                int result = (int)cmd.ExecuteScalar();
                if (result <= 0)
                {
                    sql = "INSERT INTO Lugar(Estanteria, Estante, Altura) VALUES(@estanteria, @estante, @altura)";
                    OleDbCommand cmd = new OleDbCommand(sql, conTabla);
                    cmd.Parameters.AddWithValue("@estanteria", lugar.Estanteria);
                    cmd.Parameters.AddWithValue("@estante", lugar.Estante);
                    cmd.Parameters.AddWithValue("@altura", lugar.Altura);
                    cmd.ExecuteNonQuery();
                    return lugarFinal;
                }

                sql = "SELECT * FROM Lugar WHERE Estanteria = @estanteria AND Estante = @estante AND Altura = @altura";
                OleDbCommand cmd = new OleDbCommand(sql, conTabla);

                OleDbDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    return lugarFinal; //sale vacío
                }
                dr.Read();
                lugarFinal = new Lugar();
                lugarFinal.id = (int)dr["IdLugar"];
                lugarFinal.Estanteria = dr.IsDBNull(dr.GetOrdinal("Estanteria")) ? "" : (string)dr["Estanteria"];
                lugarFinal.Estante = dr.IsDBNull(dr.GetOrdinal("Estante")) ? 0 : (int)dr["Estante"];
                lugarFinal.Altura = dr.IsDBNull(dr.GetOrdinal("Altura")) ? 0 : (int)dr["Altura"];

                return lugarFinal;
            }
            catch (Exception ex)
            {
                //RaiseEvent errorBaseDatos(Me, New BaseDatosEventArgs("Error de base de datos"))
                return null;
            }
            finally
            {
                conTabla.Close();
            }
             */
            //Modulo.miNegocio.InsertarProducto(producto)
        }

        private bool hayErrores()
        {
            if (lblCodArticulo.Text.Length != 12)
            {
                return true;
            }

            if (cboRecogida.SelectedItem == null)
            {
                cboRecogida.Focus();
                return true;
            }

            if (cmbEmpleado.SelectedItem == null)
            {
                cmbEmpleado.Focus();
                return true;
            }

            return false;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            //confirmar salida?
            //comprobar si se han añadido para la recogida tantos productos como hubiese en la recogida

            if (MessageBox.Show("¿Seguro que deseas salir?", "Salir",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Form frmMenu = new frmMenu();
                frmMenu.Show();
                this.Close();
            }
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedItem != null)
            {
                Modulo.empleadoActual = (Empleado)cmbEmpleado.SelectedItem;
                lblNombreEmpleado.Text = ((Empleado)cmbEmpleado.SelectedItem).Nombre;
                if (System.IO.File.Exists(((Empleado)cmbEmpleado.SelectedItem).Foto))
                {
                    imgEmpleado.Image = new System.Drawing.Bitmap(((Empleado)cmbEmpleado.SelectedItem).Foto);
                }
                else
                {
                    imgEmpleado.Image = CapaPresentacion.Properties.Resources.newsle_empty_icon;
                }
            }

        }

        private void soloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void chb_CheckedChanged(object sender, EventArgs e)
        {
            dgvProducts.Visible = !dgvProducts.Visible;

            if(lblCodArticulo.Text.Length == 9)
            {
                lblCodArticulo.Text = "2231014";
                gboFamilia.Focus();
            }
        }

        private void cargarProductos(SubFamilia s)
        {
            List<Producto> productos = Modulo.miNegocio.getProductos(s.CodFamilia, s.CodSubFamilia);
            if (productos != null)
            {
                dgvProducts.DataSource = productos.Select((p) => new { CodigoArticulo = p.CodigoArticulo, Descripcion = p.Descripcion, Coste = p.Coste, Unidades = p.Unidades }).ToList();
            }
            else
            {
                //TODO CONTROLAR ERROR
            }
        }
    }
}
