﻿namespace CapaPresentacion
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.pbo4prendas = new System.Windows.Forms.PictureBox();
            this.pboCuatrovientos = new System.Windows.Forms.PictureBox();
            this.pboRecogida = new System.Windows.Forms.PictureBox();
            this.pboVenta = new System.Windows.Forms.PictureBox();
            this.pboAlmacenamiento = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbo4prendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboCuatrovientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboRecogida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboAlmacenamiento)).BeginInit();
            this.SuspendLayout();
            // 
            // pbo4prendas
            // 
            this.pbo4prendas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbo4prendas.Image = global::CapaPresentacion.Properties.Resources._4Prendas;
            this.pbo4prendas.Location = new System.Drawing.Point(333, 12);
            this.pbo4prendas.Name = "pbo4prendas";
            this.pbo4prendas.Size = new System.Drawing.Size(650, 140);
            this.pbo4prendas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbo4prendas.TabIndex = 57;
            this.pbo4prendas.TabStop = false;
            // 
            // pboCuatrovientos
            // 
            this.pboCuatrovientos.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.pboCuatrovientos.Image = global::CapaPresentacion.Properties.Resources.Logo4V;
            this.pboCuatrovientos.Location = new System.Drawing.Point(24, 12);
            this.pboCuatrovientos.Name = "pboCuatrovientos";
            this.pboCuatrovientos.Size = new System.Drawing.Size(137, 140);
            this.pboCuatrovientos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboCuatrovientos.TabIndex = 56;
            this.pboCuatrovientos.TabStop = false;
            // 
            // pboRecogida
            // 
            this.pboRecogida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pboRecogida.BackColor = System.Drawing.Color.Black;
            this.pboRecogida.Location = new System.Drawing.Point(112, 343);
            this.pboRecogida.Name = "pboRecogida";
            this.pboRecogida.Size = new System.Drawing.Size(143, 186);
            this.pboRecogida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pboRecogida.TabIndex = 58;
            this.pboRecogida.TabStop = false;
            this.pboRecogida.Click += new System.EventHandler(this.pboRecogida_Click);
            // 
            // pboVenta
            // 
            this.pboVenta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pboVenta.BackColor = System.Drawing.Color.Black;
            this.pboVenta.Location = new System.Drawing.Point(583, 343);
            this.pboVenta.Name = "pboVenta";
            this.pboVenta.Size = new System.Drawing.Size(143, 186);
            this.pboVenta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pboVenta.TabIndex = 59;
            this.pboVenta.TabStop = false;
            this.pboVenta.Click += new System.EventHandler(this.pboVenta_Click);
            // 
            // pboAlmacenamiento
            // 
            this.pboAlmacenamiento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pboAlmacenamiento.BackColor = System.Drawing.Color.Black;
            this.pboAlmacenamiento.Location = new System.Drawing.Point(1016, 343);
            this.pboAlmacenamiento.Name = "pboAlmacenamiento";
            this.pboAlmacenamiento.Size = new System.Drawing.Size(143, 186);
            this.pboAlmacenamiento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pboAlmacenamiento.TabIndex = 60;
            this.pboAlmacenamiento.TabStop = false;
            this.pboAlmacenamiento.Click += new System.EventHandler(this.pboAlmacenamiento_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(1225, 713);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 113);
            this.btnExit.TabIndex = 61;
            this.btnExit.Text = "&Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1312, 838);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pboAlmacenamiento);
            this.Controls.Add(this.pboVenta);
            this.Controls.Add(this.pboRecogida);
            this.Controls.Add(this.pbo4prendas);
            this.Controls.Add(this.pboCuatrovientos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbo4prendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboCuatrovientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboRecogida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboAlmacenamiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbo4prendas;
        private System.Windows.Forms.PictureBox pboCuatrovientos;
        private System.Windows.Forms.PictureBox pboRecogida;
        private System.Windows.Forms.PictureBox pboVenta;
        private System.Windows.Forms.PictureBox pboAlmacenamiento;
        private System.Windows.Forms.Button btnExit;
    }
}