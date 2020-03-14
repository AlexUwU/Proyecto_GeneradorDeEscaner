namespace Proyecto_Generador_Escaner
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
            this.button2 = new System.Windows.Forms.Button();
            this.txtER = new System.Windows.Forms.TextBox();
            this.DGVTabla = new System.Windows.Forms.DataGridView();
            this.lbFirst = new System.Windows.Forms.ListBox();
            this.lbLast = new System.Windows.Forms.ListBox();
            this.lbFollows = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(395, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "BUSCAR ARCHIVO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(262, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "GENERAR AFD";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtER
            // 
            this.txtER.Location = new System.Drawing.Point(14, 43);
            this.txtER.Name = "txtER";
            this.txtER.Size = new System.Drawing.Size(234, 21);
            this.txtER.TabIndex = 2;
            // 
            // DGVTabla
            // 
            this.DGVTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTabla.Location = new System.Drawing.Point(395, 117);
            this.DGVTabla.Name = "DGVTabla";
            this.DGVTabla.Size = new System.Drawing.Size(630, 167);
            this.DGVTabla.TabIndex = 3;
            // 
            // lbFirst
            // 
            this.lbFirst.FormattingEnabled = true;
            this.lbFirst.ItemHeight = 15;
            this.lbFirst.Location = new System.Drawing.Point(0, 119);
            this.lbFirst.Name = "lbFirst";
            this.lbFirst.Size = new System.Drawing.Size(125, 139);
            this.lbFirst.TabIndex = 4;
            // 
            // lbLast
            // 
            this.lbLast.FormattingEnabled = true;
            this.lbLast.ItemHeight = 15;
            this.lbLast.Location = new System.Drawing.Point(132, 119);
            this.lbLast.Name = "lbLast";
            this.lbLast.Size = new System.Drawing.Size(125, 139);
            this.lbLast.TabIndex = 5;
            // 
            // lbFollows
            // 
            this.lbFollows.FormattingEnabled = true;
            this.lbFollows.ItemHeight = 15;
            this.lbFollows.Location = new System.Drawing.Point(262, 119);
            this.lbFollows.Name = "lbFollows";
            this.lbFollows.Size = new System.Drawing.Size(125, 139);
            this.lbFollows.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-4, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "FIRST";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "LAST";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(258, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "FOLLOWS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(406, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "TABLA TRANSICIONES";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Generador_Escaner.Properties.Resources.f6QOJjc_nerd_wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1030, 480);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFollows);
            this.Controls.Add(this.lbLast);
            this.Controls.Add(this.lbFirst);
            this.Controls.Add(this.DGVTabla);
            this.Controls.Add(this.txtER);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtER;
        private System.Windows.Forms.DataGridView DGVTabla;
        private System.Windows.Forms.ListBox lbFirst;
        private System.Windows.Forms.ListBox lbLast;
        private System.Windows.Forms.ListBox lbFollows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

