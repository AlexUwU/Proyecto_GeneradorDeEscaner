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
            ((System.ComponentModel.ISupportInitialize)(this.DGVTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "BUSCAR ARCHIVO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(225, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "GENERAR AFD";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtER
            // 
            this.txtER.Location = new System.Drawing.Point(12, 37);
            this.txtER.Name = "txtER";
            this.txtER.Size = new System.Drawing.Size(201, 20);
            this.txtER.TabIndex = 2;
            // 
            // DGVTabla
            // 
            this.DGVTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTabla.Location = new System.Drawing.Point(339, 101);
            this.DGVTabla.Name = "DGVTabla";
            this.DGVTabla.Size = new System.Drawing.Size(540, 145);
            this.DGVTabla.TabIndex = 3;
            // 
            // lbFirst
            // 
            this.lbFirst.FormattingEnabled = true;
            this.lbFirst.Location = new System.Drawing.Point(0, 103);
            this.lbFirst.Name = "lbFirst";
            this.lbFirst.Size = new System.Drawing.Size(108, 121);
            this.lbFirst.TabIndex = 4;
            // 
            // lbLast
            // 
            this.lbLast.FormattingEnabled = true;
            this.lbLast.Location = new System.Drawing.Point(113, 103);
            this.lbLast.Name = "lbLast";
            this.lbLast.Size = new System.Drawing.Size(108, 121);
            this.lbLast.TabIndex = 5;
            // 
            // lbFollows
            // 
            this.lbFollows.FormattingEnabled = true;
            this.lbFollows.Location = new System.Drawing.Point(225, 103);
            this.lbFollows.Name = "lbFollows";
            this.lbFollows.Size = new System.Drawing.Size(108, 121);
            this.lbFollows.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Generador_Escaner.Properties.Resources.f6QOJjc_nerd_wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(883, 416);
            this.Controls.Add(this.lbFollows);
            this.Controls.Add(this.lbLast);
            this.Controls.Add(this.lbFirst);
            this.Controls.Add(this.DGVTabla);
            this.Controls.Add(this.txtER);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
    }
}

