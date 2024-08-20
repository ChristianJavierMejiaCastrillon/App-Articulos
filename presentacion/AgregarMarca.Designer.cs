namespace presentacion
{
    partial class AgregarMarca
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
            this.buttonAceptarMarca = new System.Windows.Forms.Button();
            this.buttonCancelarMarca = new System.Windows.Forms.Button();
            this.textBoxAgregarMarca = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonAceptarMarca
            // 
            this.buttonAceptarMarca.Image = global::presentacion.Properties.Resources.gris;
            this.buttonAceptarMarca.Location = new System.Drawing.Point(33, 94);
            this.buttonAceptarMarca.Name = "buttonAceptarMarca";
            this.buttonAceptarMarca.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptarMarca.TabIndex = 0;
            this.buttonAceptarMarca.Text = "ACEPTAR";
            this.buttonAceptarMarca.UseVisualStyleBackColor = true;
            this.buttonAceptarMarca.Click += new System.EventHandler(this.buttonAceptarMarca_Click);
            // 
            // buttonCancelarMarca
            // 
            this.buttonCancelarMarca.Image = global::presentacion.Properties.Resources.gris;
            this.buttonCancelarMarca.Location = new System.Drawing.Point(188, 94);
            this.buttonCancelarMarca.Name = "buttonCancelarMarca";
            this.buttonCancelarMarca.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelarMarca.TabIndex = 1;
            this.buttonCancelarMarca.Text = "CANCELAR";
            this.buttonCancelarMarca.UseVisualStyleBackColor = true;
            this.buttonCancelarMarca.Click += new System.EventHandler(this.buttonCancelarMarca_Click);
            // 
            // textBoxAgregarMarca
            // 
            this.textBoxAgregarMarca.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxAgregarMarca.Location = new System.Drawing.Point(107, 43);
            this.textBoxAgregarMarca.Name = "textBoxAgregarMarca";
            this.textBoxAgregarMarca.Size = new System.Drawing.Size(100, 20);
            this.textBoxAgregarMarca.TabIndex = 2;
            // 
            // AgregarMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(317, 181);
            this.Controls.Add(this.textBoxAgregarMarca);
            this.Controls.Add(this.buttonCancelarMarca);
            this.Controls.Add(this.buttonAceptarMarca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AgregarMarca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Marca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAceptarMarca;
        private System.Windows.Forms.Button buttonCancelarMarca;
        private System.Windows.Forms.TextBox textBoxAgregarMarca;
    }
}