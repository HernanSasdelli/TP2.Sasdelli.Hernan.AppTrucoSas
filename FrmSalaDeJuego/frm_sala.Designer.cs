namespace FrmSalaDeJuego
{
    partial class frm_sala
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
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.rtb_mostrarJugadas = new System.Windows.Forms.RichTextBox();
            this.lbl_mostrarPartida = new System.Windows.Forms.Label();
            this.lbl_jugadorUno = new System.Windows.Forms.Label();
            this.lbl_jugadorDos = new System.Windows.Forms.Label();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Location = new System.Drawing.Point(203, 333);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(170, 79);
            this.btn_cerrar.TabIndex = 0;
            this.btn_cerrar.Text = "Cerrar";
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // rtb_mostrarJugadas
            // 
            this.rtb_mostrarJugadas.EnableAutoDragDrop = true;
            this.rtb_mostrarJugadas.ImeMode = System.Windows.Forms.ImeMode.On;
            this.rtb_mostrarJugadas.Location = new System.Drawing.Point(203, 46);
            this.rtb_mostrarJugadas.Name = "rtb_mostrarJugadas";
            this.rtb_mostrarJugadas.ReadOnly = true;
            this.rtb_mostrarJugadas.Size = new System.Drawing.Size(396, 249);
            this.rtb_mostrarJugadas.TabIndex = 1;
            this.rtb_mostrarJugadas.Text = "";
            this.rtb_mostrarJugadas.UseWaitCursor = true;
            this.rtb_mostrarJugadas.TextChanged += new System.EventHandler(this.rtb_mostrarJugadas_TextChanged);
            // 
            // lbl_mostrarPartida
            // 
            this.lbl_mostrarPartida.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_mostrarPartida.ForeColor = System.Drawing.Color.White;
            this.lbl_mostrarPartida.Location = new System.Drawing.Point(306, 9);
            this.lbl_mostrarPartida.Name = "lbl_mostrarPartida";
            this.lbl_mostrarPartida.Size = new System.Drawing.Size(186, 31);
            this.lbl_mostrarPartida.TabIndex = 2;
            this.lbl_mostrarPartida.Text = "muestra partida";
            // 
            // lbl_jugadorUno
            // 
            this.lbl_jugadorUno.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_jugadorUno.ForeColor = System.Drawing.Color.White;
            this.lbl_jugadorUno.Location = new System.Drawing.Point(30, 46);
            this.lbl_jugadorUno.Name = "lbl_jugadorUno";
            this.lbl_jugadorUno.Size = new System.Drawing.Size(154, 57);
            this.lbl_jugadorUno.TabIndex = 3;
            this.lbl_jugadorUno.Text = "muestra jugador 1";
            // 
            // lbl_jugadorDos
            // 
            this.lbl_jugadorDos.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_jugadorDos.ForeColor = System.Drawing.Color.White;
            this.lbl_jugadorDos.Location = new System.Drawing.Point(30, 132);
            this.lbl_jugadorDos.Name = "lbl_jugadorDos";
            this.lbl_jugadorDos.Size = new System.Drawing.Size(154, 59);
            this.lbl_jugadorDos.TabIndex = 4;
            this.lbl_jugadorDos.Text = "muestra jugador 2";
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(429, 333);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(170, 79);
            this.btn_Cancelar.TabIndex = 5;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // frm_sala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.lbl_jugadorDos);
            this.Controls.Add(this.lbl_jugadorUno);
            this.Controls.Add(this.lbl_mostrarPartida);
            this.Controls.Add(this.rtb_mostrarJugadas);
            this.Controls.Add(this.btn_cerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_sala";
            this.Text = "sala";
            this.Load += new System.EventHandler(this.frm_sala_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_cerrar;
        private RichTextBox rtb_mostrarJugadas;
        private Label lbl_mostrarPartida;
        private Label lbl_jugadorUno;
        private Label lbl_jugadorDos;
        private Button btn_Cancelar;
    }
}