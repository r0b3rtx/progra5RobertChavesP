namespace P620223_RobertChavesP.Formularios
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnIngresoDirecto = new System.Windows.Forms.Button();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.btnVerPassword = new System.Windows.Forms.Button();
            this.lblRecuperarContrasenia = new System.Windows.Forms.LinkLabel();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnIngresoDirecto);
            this.panel1.Controls.Add(this.lblContrasenia);
            this.panel1.Controls.Add(this.btnVerPassword);
            this.panel1.Controls.Add(this.lblRecuperarContrasenia);
            this.panel1.Controls.Add(this.lblNombreUsuario);
            this.panel1.Controls.Add(this.txtContrasenia);
            this.panel1.Controls.Add(this.txtNombreUsuario);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnIngresar);
            this.panel1.Location = new System.Drawing.Point(24, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 285);
            this.panel1.TabIndex = 0;
            // 
            // btnIngresoDirecto
            // 
            this.btnIngresoDirecto.Location = new System.Drawing.Point(22, 250);
            this.btnIngresoDirecto.Name = "btnIngresoDirecto";
            this.btnIngresoDirecto.Size = new System.Drawing.Size(75, 23);
            this.btnIngresoDirecto.TabIndex = 8;
            this.btnIngresoDirecto.Text = "INGRESAR\r\n";
            this.btnIngresoDirecto.UseVisualStyleBackColor = true;
            this.btnIngresoDirecto.Visible = false;
            this.btnIngresoDirecto.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblContrasenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenia.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblContrasenia.Location = new System.Drawing.Point(109, 87);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(110, 24);
            this.lblContrasenia.TabIndex = 2;
            this.lblContrasenia.Text = "Contrasenia";
            // 
            // btnVerPassword
            // 
            this.btnVerPassword.Location = new System.Drawing.Point(270, 127);
            this.btnVerPassword.Name = "btnVerPassword";
            this.btnVerPassword.Size = new System.Drawing.Size(46, 29);
            this.btnVerPassword.TabIndex = 2;
            this.btnVerPassword.Text = "Ver";
            this.btnVerPassword.UseVisualStyleBackColor = true;
            this.btnVerPassword.Click += new System.EventHandler(this.btnVerPassword_Click);
            this.btnVerPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnVerPassword_MouseDown);
            this.btnVerPassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnVerPassword_MouseUp);
            // 
            // lblRecuperarContrasenia
            // 
            this.lblRecuperarContrasenia.AutoSize = true;
            this.lblRecuperarContrasenia.LinkColor = System.Drawing.Color.Gold;
            this.lblRecuperarContrasenia.Location = new System.Drawing.Point(196, 159);
            this.lblRecuperarContrasenia.Name = "lblRecuperarContrasenia";
            this.lblRecuperarContrasenia.Size = new System.Drawing.Size(108, 13);
            this.lblRecuperarContrasenia.TabIndex = 5;
            this.lblRecuperarContrasenia.TabStop = true;
            this.lblRecuperarContrasenia.Text = "Olvide mi contrasenia";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblNombreUsuario.Location = new System.Drawing.Point(-1, 11);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(333, 23);
            this.lblNombreUsuario.TabIndex = 5;
            this.lblNombreUsuario.Text = "Nombre Usuario";
            this.lblNombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenia.Location = new System.Drawing.Point(22, 127);
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.Size = new System.Drawing.Size(251, 29);
            this.txtContrasenia.TabIndex = 1;
            this.txtContrasenia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContrasenia.UseSystemPasswordChar = true;
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(22, 37);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(294, 29);
            this.txtNombreUsuario.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(199, 188);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 34);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.Blue;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(22, 188);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(102, 34);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(440, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 234);
            this.panel2.TabIndex = 1;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso directo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lblRecuperarContrasenia;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVerPassword;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.Button btnIngresoDirecto;
    }
}