namespace EjemploCarga_Csharp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCargar = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnFichero = new System.Windows.Forms.Button();
            this.txtFichero = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.cboCampaña = new System.Windows.Forms.ComboBox();
            this.cboCartera = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(223, 109);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 23);
            this.btnCargar.TabIndex = 15;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(10, 73);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(42, 13);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "Fichero";
            // 
            // btnFichero
            // 
            this.btnFichero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFichero.Location = new System.Drawing.Point(268, 69);
            this.btnFichero.Name = "btnFichero";
            this.btnFichero.Size = new System.Drawing.Size(29, 23);
            this.btnFichero.TabIndex = 13;
            this.btnFichero.Text = "...";
            this.btnFichero.UseVisualStyleBackColor = true;
            this.btnFichero.Click += new System.EventHandler(this.btnFichero_Click);
            // 
            // txtFichero
            // 
            this.txtFichero.Location = new System.Drawing.Point(80, 70);
            this.txtFichero.Name = "txtFichero";
            this.txtFichero.Size = new System.Drawing.Size(183, 20);
            this.txtFichero.TabIndex = 12;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(10, 46);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(52, 13);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Campaña";
            // 
            // cboCampaña
            // 
            this.cboCampaña.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampaña.FormattingEnabled = true;
            this.cboCampaña.Location = new System.Drawing.Point(80, 43);
            this.cboCampaña.Name = "cboCampaña";
            this.cboCampaña.Size = new System.Drawing.Size(218, 21);
            this.cboCampaña.TabIndex = 10;
            // 
            // cboCartera
            // 
            this.cboCartera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCartera.FormattingEnabled = true;
            this.cboCartera.Location = new System.Drawing.Point(80, 16);
            this.cboCartera.Name = "cboCartera";
            this.cboCartera.Size = new System.Drawing.Size(218, 21);
            this.cboCartera.TabIndex = 9;
            this.cboCartera.SelectionChangeCommitted += new System.EventHandler(this.cboCartera_SelectionChangeCommitted);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Cartera";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 146);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.btnFichero);
            this.Controls.Add(this.txtFichero);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cboCampaña);
            this.Controls.Add(this.cboCartera);
            this.Controls.Add(this.Label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
        internal System.Windows.Forms.Button btnCargar;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnFichero;
        internal System.Windows.Forms.TextBox txtFichero;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cboCampaña;
        internal System.Windows.Forms.ComboBox cboCartera;
        internal System.Windows.Forms.Label Label1;
    }
}

