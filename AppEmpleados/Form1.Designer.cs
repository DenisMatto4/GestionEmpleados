namespace AppEmpleados
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtMaximo = new System.Windows.Forms.TextBox();
            this.txtMinimo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewJobs = new System.Windows.Forms.ListView();
            this.columnId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnConexion = new System.Windows.Forms.Button();
            this.labelConexion = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVaciar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 31);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 1;
            this.button1.Text = "Abrir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Enabled = false;
            this.btnCerrar.Location = new System.Drawing.Point(326, 31);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(56, 19);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Visible = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(49, 329);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 27);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "Guardar";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(49, 152);
            this.txtTitulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(188, 20);
            this.txtTitulo.TabIndex = 4;
            // 
            // txtMaximo
            // 
            this.txtMaximo.Location = new System.Drawing.Point(49, 264);
            this.txtMaximo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaximo.Name = "txtMaximo";
            this.txtMaximo.Size = new System.Drawing.Size(188, 20);
            this.txtMaximo.TabIndex = 5;
            // 
            // txtMinimo
            // 
            this.txtMinimo.Location = new System.Drawing.Point(49, 208);
            this.txtMinimo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMinimo.Name = "txtMinimo";
            this.txtMinimo.Size = new System.Drawing.Size(188, 20);
            this.txtMinimo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Título";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 189);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Salario mínimo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 245);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Salario máximo";
            // 
            // listViewJobs
            // 
            this.listViewJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnId,
            this.columnTitulo,
            this.columnMin,
            this.columnMax});
            this.listViewJobs.HideSelection = false;
            this.listViewJobs.Location = new System.Drawing.Point(326, 98);
            this.listViewJobs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listViewJobs.Name = "listViewJobs";
            this.listViewJobs.Size = new System.Drawing.Size(686, 258);
            this.listViewJobs.TabIndex = 10;
            this.listViewJobs.UseCompatibleStateImageBehavior = false;
            this.listViewJobs.View = System.Windows.Forms.View.Details;
            this.listViewJobs.SelectedIndexChanged += new System.EventHandler(this.listViewJobs_SelectedIndexChanged);
            // 
            // columnId
            // 
            this.columnId.Text = "Id";
            this.columnId.Width = 88;
            // 
            // columnTitulo
            // 
            this.columnTitulo.Text = "Título";
            this.columnTitulo.Width = 271;
            // 
            // columnMin
            // 
            this.columnMin.Text = "Salario mínimo";
            this.columnMin.Width = 166;
            // 
            // columnMax
            // 
            this.columnMax.Text = "Salario máximo";
            this.columnMax.Width = 133;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(53, 98);
            this.txtID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(105, 20);
            this.txtID.TabIndex = 11;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(504, 76);
            this.btnMostrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(106, 19);
            this.btnMostrar.TabIndex = 14;
            this.btnMostrar.Text = "Mostrar Jobs";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Visible = false;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnConexion
            // 
            this.btnConexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnConexion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConexion.Location = new System.Drawing.Point(992, 12);
            this.btnConexion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConexion.Name = "btnConexion";
            this.btnConexion.Size = new System.Drawing.Size(20, 18);
            this.btnConexion.TabIndex = 15;
            this.btnConexion.UseVisualStyleBackColor = false;
            this.btnConexion.Visible = false;
            // 
            // labelConexion
            // 
            this.labelConexion.AutoSize = true;
            this.labelConexion.Location = new System.Drawing.Point(872, 15);
            this.labelConexion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConexion.Name = "labelConexion";
            this.labelConexion.Size = new System.Drawing.Size(35, 13);
            this.labelConexion.TabIndex = 16;
            this.labelConexion.Text = "label5";
            this.labelConexion.Visible = false;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(162, 329);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 27);
            this.btnBorrar.TabIndex = 18;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(326, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Lista de trabajos";
            // 
            // btnVaciar
            // 
            this.btnVaciar.Location = new System.Drawing.Point(163, 98);
            this.btnVaciar.Name = "btnVaciar";
            this.btnVaciar.Size = new System.Drawing.Size(75, 20);
            this.btnVaciar.TabIndex = 20;
            this.btnVaciar.Text = "Vaciar info";
            this.btnVaciar.UseVisualStyleBackColor = true;
            this.btnVaciar.Click += new System.EventHandler(this.btnVaciar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Información";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 449);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnVaciar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.labelConexion);
            this.Controls.Add(this.btnConexion);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.listViewJobs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMinimo);
            this.Controls.Add(this.txtMaximo);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Gestionar los trabajos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtMaximo;
        private System.Windows.Forms.TextBox txtMinimo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewJobs;
        private System.Windows.Forms.ColumnHeader columnTitulo;
        private System.Windows.Forms.ColumnHeader columnMin;
        private System.Windows.Forms.ColumnHeader columnMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.ColumnHeader columnId;
        private System.Windows.Forms.Button btnConexion;
        private System.Windows.Forms.Label labelConexion;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnVaciar;
        private System.Windows.Forms.Label label6;
    }
}

