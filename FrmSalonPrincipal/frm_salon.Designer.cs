namespace FrmSalonPrincipal
{
    partial class frm_salon
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_salon));
            this.btn_crearNuevaSala = new System.Windows.Forms.Button();
            this.dtg_listaSalas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_error = new System.Windows.Forms.Label();
            this.rtb_mostrarPartidasTerminadas = new System.Windows.Forms.RichTextBox();
            this.lbl_partidasTerminadas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_listaSalas)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_crearNuevaSala
            // 
            this.btn_crearNuevaSala.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_crearNuevaSala.Location = new System.Drawing.Point(150, 344);
            this.btn_crearNuevaSala.Name = "btn_crearNuevaSala";
            this.btn_crearNuevaSala.Size = new System.Drawing.Size(149, 56);
            this.btn_crearNuevaSala.TabIndex = 0;
            this.btn_crearNuevaSala.Text = "Crear Nueva Sala";
            this.btn_crearNuevaSala.UseVisualStyleBackColor = false;
            this.btn_crearNuevaSala.Click += new System.EventHandler(this.btn_crearNuevaSala_Click);
            // 
            // dtg_listaSalas
            // 
            this.dtg_listaSalas.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dtg_listaSalas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtg_listaSalas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtg_listaSalas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dtg_listaSalas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_listaSalas.Location = new System.Drawing.Point(80, 80);
            this.dtg_listaSalas.Name = "dtg_listaSalas";
            this.dtg_listaSalas.ReadOnly = true;
            this.dtg_listaSalas.RowHeadersWidth = 51;
            this.dtg_listaSalas.RowTemplate.Height = 29;
            this.dtg_listaSalas.Size = new System.Drawing.Size(295, 258);
            this.dtg_listaSalas.TabIndex = 1;
            this.dtg_listaSalas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_listaSalas_CellContentDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Serif Gothic Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(80, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Salas Disponibles";
            // 
            // lbl_error
            // 
            this.lbl_error.BackColor = System.Drawing.Color.White;
            this.lbl_error.Font = new System.Drawing.Font("Sony Sketch EF", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_error.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_error.Location = new System.Drawing.Point(93, 403);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(267, 72);
            this.lbl_error.TabIndex = 3;
            this.lbl_error.Text = "Errores";
            this.lbl_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_error.Visible = false;
            // 
            // rtb_mostrarPartidasTerminadas
            // 
            this.rtb_mostrarPartidasTerminadas.Location = new System.Drawing.Point(454, 80);
            this.rtb_mostrarPartidasTerminadas.Name = "rtb_mostrarPartidasTerminadas";
            this.rtb_mostrarPartidasTerminadas.Size = new System.Drawing.Size(306, 258);
            this.rtb_mostrarPartidasTerminadas.TabIndex = 4;
            this.rtb_mostrarPartidasTerminadas.Text = "";
            // 
            // lbl_partidasTerminadas
            // 
            this.lbl_partidasTerminadas.AutoSize = true;
            this.lbl_partidasTerminadas.BackColor = System.Drawing.Color.White;
            this.lbl_partidasTerminadas.Font = new System.Drawing.Font("Serif Gothic Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_partidasTerminadas.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_partidasTerminadas.Location = new System.Drawing.Point(473, 36);
            this.lbl_partidasTerminadas.Name = "lbl_partidasTerminadas";
            this.lbl_partidasTerminadas.Size = new System.Drawing.Size(264, 31);
            this.lbl_partidasTerminadas.TabIndex = 5;
            this.lbl_partidasTerminadas.Text = "Partidas Terminadas";
            // 
            // frm_salon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(843, 484);
            this.Controls.Add(this.lbl_partidasTerminadas);
            this.Controls.Add(this.rtb_mostrarPartidasTerminadas);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtg_listaSalas);
            this.Controls.Add(this.btn_crearNuevaSala);
            this.Name = "frm_salon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truco SAS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_salon_FormClosing);
            this.Load += new System.EventHandler(this.frm_salon_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frm_salon_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_listaSalas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_crearNuevaSala;
        private DataGridView dtg_listaSalas;
        private Label label1;
        private Label lbl_error;
        private RichTextBox rtb_mostrarPartidasTerminadas;
        private Label lbl_partidasTerminadas;
    }
}