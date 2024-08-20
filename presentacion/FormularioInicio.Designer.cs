namespace presentacion
{
    partial class FormularioInicio
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCliente = new System.Windows.Forms.Button();
            this.labelCliente = new System.Windows.Forms.Label();
            this.labelAdministrador = new System.Windows.Forms.Label();
            this.buttonAdministrador = new System.Windows.Forms.Button();
            this.labelBienvenida = new System.Windows.Forms.Label();
            this.labelCliente1 = new System.Windows.Forms.Label();
            this.labelAdministrador2 = new System.Windows.Forms.Label();
            this.buttonSalirInicio = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.labelCliente, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelAdministrador, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdministrador, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelBienvenida, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelCliente1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelAdministrador2, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonSalirInicio, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.buttonCliente, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonCliente
            // 
            this.buttonCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCliente.Image = global::presentacion.Properties.Resources.gris;
            this.buttonCliente.Location = new System.Drawing.Point(483, 171);
            this.buttonCliente.Name = "buttonCliente";
            this.buttonCliente.Size = new System.Drawing.Size(154, 50);
            this.buttonCliente.TabIndex = 0;
            this.buttonCliente.Text = "CLIENTE";
            this.buttonCliente.UseVisualStyleBackColor = true;
            this.buttonCliente.Click += new System.EventHandler(this.buttonCliente_Click);
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.BackColor = System.Drawing.SystemColors.HighlightText;
            this.labelCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCliente.Image = global::presentacion.Properties.Resources.gris;
            this.labelCliente.Location = new System.Drawing.Point(163, 168);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(147, 22);
            this.labelCliente.TabIndex = 1;
            this.labelCliente.Text = "Descripcion Cliente";
            this.labelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAdministrador
            // 
            this.labelAdministrador.AutoSize = true;
            this.labelAdministrador.BackColor = System.Drawing.SystemColors.HighlightText;
            this.labelAdministrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAdministrador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdministrador.Image = global::presentacion.Properties.Resources.gris;
            this.labelAdministrador.Location = new System.Drawing.Point(163, 280);
            this.labelAdministrador.Name = "labelAdministrador";
            this.labelAdministrador.Size = new System.Drawing.Size(109, 42);
            this.labelAdministrador.TabIndex = 2;
            this.labelAdministrador.Text = "Descripcion Administrador";
            this.labelAdministrador.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonAdministrador
            // 
            this.buttonAdministrador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAdministrador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdministrador.Image = global::presentacion.Properties.Resources.gris;
            this.buttonAdministrador.Location = new System.Drawing.Point(483, 283);
            this.buttonAdministrador.Name = "buttonAdministrador";
            this.buttonAdministrador.Size = new System.Drawing.Size(154, 50);
            this.buttonAdministrador.TabIndex = 1;
            this.buttonAdministrador.Text = "ADMINISTRADOR";
            this.buttonAdministrador.UseVisualStyleBackColor = true;
            this.buttonAdministrador.Click += new System.EventHandler(this.buttonAdministrador_Click);
            // 
            // labelBienvenida
            // 
            this.labelBienvenida.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelBienvenida.AutoSize = true;
            this.labelBienvenida.BackColor = System.Drawing.SystemColors.HighlightText;
            this.labelBienvenida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelBienvenida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBienvenida.Image = global::presentacion.Properties.Resources.gris;
            this.labelBienvenida.Location = new System.Drawing.Point(355, 56);
            this.labelBienvenida.Name = "labelBienvenida";
            this.labelBienvenida.Size = new System.Drawing.Size(89, 22);
            this.labelBienvenida.TabIndex = 0;
            this.labelBienvenida.Text = "Bienvenida";
            this.labelBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCliente1
            // 
            this.labelCliente1.AutoSize = true;
            this.labelCliente1.Location = new System.Drawing.Point(323, 168);
            this.labelCliente1.Name = "labelCliente1";
            this.labelCliente1.Size = new System.Drawing.Size(74, 13);
            this.labelCliente1.TabIndex = 5;
            this.labelCliente1.Text = "Cdescripcion2";
            // 
            // labelAdministrador2
            // 
            this.labelAdministrador2.AutoSize = true;
            this.labelAdministrador2.Location = new System.Drawing.Point(323, 280);
            this.labelAdministrador2.Name = "labelAdministrador2";
            this.labelAdministrador2.Size = new System.Drawing.Size(76, 13);
            this.labelAdministrador2.TabIndex = 6;
            this.labelAdministrador2.Text = "ADescripcion2";
            // 
            // buttonSalirInicio
            // 
            this.buttonSalirInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalirInicio.Image = global::presentacion.Properties.Resources.gris;
            this.buttonSalirInicio.Location = new System.Drawing.Point(643, 395);
            this.buttonSalirInicio.Name = "buttonSalirInicio";
            this.buttonSalirInicio.Size = new System.Drawing.Size(145, 43);
            this.buttonSalirInicio.TabIndex = 2;
            this.buttonSalirInicio.Text = "SALIR";
            this.buttonSalirInicio.UseVisualStyleBackColor = true;
            this.buttonSalirInicio.Click += new System.EventHandler(this.buttonSalirInicio_Click);
            // 
            // FormularioInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormularioInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario Inicio";
            this.Load += new System.EventHandler(this.FormularioInicio_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelBienvenida;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label labelAdministrador;
        private System.Windows.Forms.Button buttonCliente;
        private System.Windows.Forms.Button buttonAdministrador;
        private System.Windows.Forms.Label labelCliente1;
        private System.Windows.Forms.Label labelAdministrador2;
        private System.Windows.Forms.Button buttonSalirInicio;
    }
}