namespace presentacion
{
    partial class AgregarCategoria
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
            this.textBoxAgregarCategoria = new System.Windows.Forms.TextBox();
            this.buttonAceptarCategoria = new System.Windows.Forms.Button();
            this.buttonCancelarCategoria = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAgregarCategoria
            // 
            this.textBoxAgregarCategoria.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxAgregarCategoria.Location = new System.Drawing.Point(128, 37);
            this.textBoxAgregarCategoria.Name = "textBoxAgregarCategoria";
            this.textBoxAgregarCategoria.Size = new System.Drawing.Size(100, 20);
            this.textBoxAgregarCategoria.TabIndex = 0;
            // 
            // buttonAceptarCategoria
            // 
            this.buttonAceptarCategoria.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAceptarCategoria.Image = global::presentacion.Properties.Resources.gris;
            this.buttonAceptarCategoria.Location = new System.Drawing.Point(53, 101);
            this.buttonAceptarCategoria.Name = "buttonAceptarCategoria";
            this.buttonAceptarCategoria.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptarCategoria.TabIndex = 1;
            this.buttonAceptarCategoria.Text = "ACEPTAR";
            this.buttonAceptarCategoria.UseVisualStyleBackColor = false;
            this.buttonAceptarCategoria.Click += new System.EventHandler(this.buttonAceptarCategoria_Click);
            // 
            // buttonCancelarCategoria
            // 
            this.buttonCancelarCategoria.Image = global::presentacion.Properties.Resources.gris;
            this.buttonCancelarCategoria.Location = new System.Drawing.Point(212, 101);
            this.buttonCancelarCategoria.Name = "buttonCancelarCategoria";
            this.buttonCancelarCategoria.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelarCategoria.TabIndex = 2;
            this.buttonCancelarCategoria.Text = "CANCELAR";
            this.buttonCancelarCategoria.UseVisualStyleBackColor = true;
            this.buttonCancelarCategoria.Click += new System.EventHandler(this.buttonCancelarCategoria_Click);
            // 
            // AgregarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(346, 171);
            this.Controls.Add(this.buttonCancelarCategoria);
            this.Controls.Add(this.buttonAceptarCategoria);
            this.Controls.Add(this.textBoxAgregarCategoria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AgregarCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Categoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAgregarCategoria;
        private System.Windows.Forms.Button buttonAceptarCategoria;
        private System.Windows.Forms.Button buttonCancelarCategoria;
    }
}