namespace proyecto_DR_roque
{
    partial class Form3
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.txtsql = new System.Windows.Forms.TextBox();
            this.consultas = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rbtmostrar = new System.Windows.Forms.RadioButton();
            this.rbtconsulta = new System.Windows.Forms.RadioButton();
            this.dgvlista3 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.consultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlista3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtsql
            // 
            this.txtsql.Location = new System.Drawing.Point(18, 53);
            this.txtsql.Multiline = true;
            this.txtsql.Name = "txtsql";
            this.txtsql.Size = new System.Drawing.Size(559, 99);
            this.txtsql.TabIndex = 0;
            // 
            // consultas
            // 
            this.consultas.Controls.Add(this.button1);
            this.consultas.Controls.Add(this.rbtmostrar);
            this.consultas.Controls.Add(this.rbtconsulta);
            this.consultas.Controls.Add(this.txtsql);
            this.consultas.Location = new System.Drawing.Point(26, 58);
            this.consultas.Name = "consultas";
            this.consultas.Size = new System.Drawing.Size(716, 170);
            this.consultas.TabIndex = 1;
            this.consultas.TabStop = false;
            this.consultas.Text = "consultas";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(596, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 68);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbtmostrar
            // 
            this.rbtmostrar.AutoSize = true;
            this.rbtmostrar.Checked = true;
            this.rbtmostrar.Location = new System.Drawing.Point(604, 73);
            this.rbtmostrar.Name = "rbtmostrar";
            this.rbtmostrar.Size = new System.Drawing.Size(105, 17);
            this.rbtmostrar.TabIndex = 2;
            this.rbtmostrar.TabStop = true;
            this.rbtmostrar.Text = "mostrar resultado";
            this.rbtmostrar.UseVisualStyleBackColor = true;
            // 
            // rbtconsulta
            // 
            this.rbtconsulta.AutoSize = true;
            this.rbtconsulta.Location = new System.Drawing.Point(604, 37);
            this.rbtconsulta.Name = "rbtconsulta";
            this.rbtconsulta.Size = new System.Drawing.Size(87, 17);
            this.rbtconsulta.TabIndex = 1;
            this.rbtconsulta.Text = "solo consulta";
            this.rbtconsulta.UseVisualStyleBackColor = true;
            // 
            // dgvlista3
            // 
            this.dgvlista3.AllowUserToAddRows = false;
            this.dgvlista3.AllowUserToDeleteRows = false;
            this.dgvlista3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlista3.Location = new System.Drawing.Point(26, 234);
            this.dgvlista3.Name = "dgvlista3";
            this.dgvlista3.ReadOnly = true;
            this.dgvlista3.Size = new System.Drawing.Size(716, 233);
            this.dgvlista3.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(561, 514);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "Regresar ventana 2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(561, 566);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(181, 34);
            this.button3.TabIndex = 4;
            this.button3.Text = "Regresar ventana 1";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(26, 533);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 67);
            this.button4.TabIndex = 5;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Este espacio es para hacer consultas con comandos SQL ";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.Location = new System.Drawing.Point(207, 497);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(125, 103);
            this.button5.TabIndex = 7;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(754, 612);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvlista3);
            this.Controls.Add(this.consultas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "Consultas SQL";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.consultas.ResumeLayout(false);
            this.consultas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlista3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtsql;
        private System.Windows.Forms.GroupBox consultas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbtmostrar;
        private System.Windows.Forms.RadioButton rbtconsulta;
        private System.Windows.Forms.DataGridView dgvlista3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
    }
}