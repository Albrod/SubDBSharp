namespace SubDBSharp
{
    partial class Form1
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
            this.tb_filepath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_algo = new System.Windows.Forms.Button();
            this.tb_pruebas = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_filepath
            // 
            this.tb_filepath.AllowDrop = true;
            this.tb_filepath.Location = new System.Drawing.Point(12, 12);
            this.tb_filepath.Name = "tb_filepath";
            this.tb_filepath.ReadOnly = true;
            this.tb_filepath.Size = new System.Drawing.Size(497, 20);
            this.tb_filepath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 1;
            this.label1.Tag = "";
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(413, 42);
            this.label2.TabIndex = 2;
            this.label2.Text = "Just Drop your file here.";
            // 
            // bt_algo
            // 
            this.bt_algo.Location = new System.Drawing.Point(371, 192);
            this.bt_algo.Name = "bt_algo";
            this.bt_algo.Size = new System.Drawing.Size(75, 23);
            this.bt_algo.TabIndex = 3;
            this.bt_algo.Text = "button1";
            this.bt_algo.UseVisualStyleBackColor = true;
            this.bt_algo.Click += new System.EventHandler(this.bt_algo_Click);
            // 
            // tb_pruebas
            // 
            this.tb_pruebas.Location = new System.Drawing.Point(58, 194);
            this.tb_pruebas.Name = "tb_pruebas";
            this.tb_pruebas.Size = new System.Drawing.Size(180, 20);
            this.tb_pruebas.TabIndex = 4;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 311);
            this.Controls.Add(this.tb_pruebas);
            this.Controls.Add(this.bt_algo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_filepath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_filepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_algo;
        private System.Windows.Forms.TextBox tb_pruebas;

    }
}

