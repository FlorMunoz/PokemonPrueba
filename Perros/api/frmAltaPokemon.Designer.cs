namespace api
{
    partial class frmAltaPokemon
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
            this.label1Numero = new System.Windows.Forms.Label();
            this.textBox1Numero = new System.Windows.Forms.TextBox();
            this.label2Nombre = new System.Windows.Forms.Label();
            this.textBox2Nombre = new System.Windows.Forms.TextBox();
            this.label3Descripcion = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4UrlImagen = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5Tipo = new System.Windows.Forms.Label();
            this.comboBox1Tipo = new System.Windows.Forms.ComboBox();
            this.button1Aceptar = new System.Windows.Forms.Button();
            this.button2Cancelar = new System.Windows.Forms.Button();
            this.pbxUrlImagen = new System.Windows.Forms.PictureBox();
            this.btnCargarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUrlImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // label1Numero
            // 
            this.label1Numero.AutoSize = true;
            this.label1Numero.Location = new System.Drawing.Point(46, 25);
            this.label1Numero.Name = "label1Numero";
            this.label1Numero.Size = new System.Drawing.Size(44, 13);
            this.label1Numero.TabIndex = 0;
            this.label1Numero.Text = "Numero";
            // 
            // textBox1Numero
            // 
            this.textBox1Numero.Location = new System.Drawing.Point(105, 25);
            this.textBox1Numero.Name = "textBox1Numero";
            this.textBox1Numero.Size = new System.Drawing.Size(100, 20);
            this.textBox1Numero.TabIndex = 1;
            // 
            // label2Nombre
            // 
            this.label2Nombre.AutoSize = true;
            this.label2Nombre.Location = new System.Drawing.Point(49, 62);
            this.label2Nombre.Name = "label2Nombre";
            this.label2Nombre.Size = new System.Drawing.Size(44, 13);
            this.label2Nombre.TabIndex = 2;
            this.label2Nombre.Text = "Nombre";
            // 
            // textBox2Nombre
            // 
            this.textBox2Nombre.Location = new System.Drawing.Point(105, 62);
            this.textBox2Nombre.Name = "textBox2Nombre";
            this.textBox2Nombre.Size = new System.Drawing.Size(100, 20);
            this.textBox2Nombre.TabIndex = 3;
            // 
            // label3Descripcion
            // 
            this.label3Descripcion.AutoSize = true;
            this.label3Descripcion.Location = new System.Drawing.Point(49, 106);
            this.label3Descripcion.Name = "label3Descripcion";
            this.label3Descripcion.Size = new System.Drawing.Size(63, 13);
            this.label3Descripcion.TabIndex = 4;
            this.label3Descripcion.Text = "Descripcion";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(105, 106);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            // 
            // label4UrlImagen
            // 
            this.label4UrlImagen.AutoSize = true;
            this.label4UrlImagen.Location = new System.Drawing.Point(49, 162);
            this.label4UrlImagen.Name = "label4UrlImagen";
            this.label4UrlImagen.Size = new System.Drawing.Size(55, 13);
            this.label4UrlImagen.TabIndex = 6;
            this.label4UrlImagen.Text = "UrlImagen";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(105, 162);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 7;
            this.textBox4.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // label5Tipo
            // 
            this.label5Tipo.AutoSize = true;
            this.label5Tipo.Location = new System.Drawing.Point(49, 206);
            this.label5Tipo.Name = "label5Tipo";
            this.label5Tipo.Size = new System.Drawing.Size(28, 13);
            this.label5Tipo.TabIndex = 8;
            this.label5Tipo.Text = "Tipo";
            // 
            // comboBox1Tipo
            // 
            this.comboBox1Tipo.FormattingEnabled = true;
            this.comboBox1Tipo.Location = new System.Drawing.Point(105, 206);
            this.comboBox1Tipo.Name = "comboBox1Tipo";
            this.comboBox1Tipo.Size = new System.Drawing.Size(121, 21);
            this.comboBox1Tipo.TabIndex = 9;
            // 
            // button1Aceptar
            // 
            this.button1Aceptar.Location = new System.Drawing.Point(33, 286);
            this.button1Aceptar.Name = "button1Aceptar";
            this.button1Aceptar.Size = new System.Drawing.Size(75, 23);
            this.button1Aceptar.TabIndex = 10;
            this.button1Aceptar.Text = "Aceptar";
            this.button1Aceptar.UseVisualStyleBackColor = true;
            this.button1Aceptar.Click += new System.EventHandler(this.button1Aceptar_Click);
            // 
            // button2Cancelar
            // 
            this.button2Cancelar.Location = new System.Drawing.Point(142, 285);
            this.button2Cancelar.Name = "button2Cancelar";
            this.button2Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button2Cancelar.TabIndex = 11;
            this.button2Cancelar.Text = "Cancelar";
            this.button2Cancelar.UseVisualStyleBackColor = true;
            this.button2Cancelar.Click += new System.EventHandler(this.button2Cancelar_Click);
            // 
            // pbxUrlImagen
            // 
            this.pbxUrlImagen.Location = new System.Drawing.Point(275, 25);
            this.pbxUrlImagen.Name = "pbxUrlImagen";
            this.pbxUrlImagen.Size = new System.Drawing.Size(245, 202);
            this.pbxUrlImagen.TabIndex = 12;
            this.pbxUrlImagen.TabStop = false;
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.Location = new System.Drawing.Point(212, 158);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(43, 23);
            this.btnCargarImagen.TabIndex = 13;
            this.btnCargarImagen.Text = "+";
            this.btnCargarImagen.UseVisualStyleBackColor = true;
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // frmAltaPokemon
            // 
            this.ClientSize = new System.Drawing.Size(596, 356);
            this.Controls.Add(this.btnCargarImagen);
            this.Controls.Add(this.pbxUrlImagen);
            this.Controls.Add(this.button2Cancelar);
            this.Controls.Add(this.button1Aceptar);
            this.Controls.Add(this.comboBox1Tipo);
            this.Controls.Add(this.label5Tipo);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4UrlImagen);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3Descripcion);
            this.Controls.Add(this.textBox2Nombre);
            this.Controls.Add(this.label2Nombre);
            this.Controls.Add(this.textBox1Numero);
            this.Controls.Add(this.label1Numero);
            this.Name = "frmAltaPokemon";
            this.Load += new System.EventHandler(this.frmAltaPokemon_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pbxUrlImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Label label1Numero;
        private System.Windows.Forms.TextBox textBox1Numero;
        private System.Windows.Forms.Label label2Nombre;
        private System.Windows.Forms.TextBox textBox2Nombre;
        private System.Windows.Forms.Label label3Descripcion;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4UrlImagen;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5Tipo;
        private System.Windows.Forms.ComboBox comboBox1Tipo;
        private System.Windows.Forms.Button button1Aceptar;
        private System.Windows.Forms.Button button2Cancelar;
        private System.Windows.Forms.PictureBox pbxUrlImagen;
        private System.Windows.Forms.Button btnCargarImagen;
    }
}