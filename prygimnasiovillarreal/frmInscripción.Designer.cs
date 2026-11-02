namespace prygimnasiovillarreal
{
    partial class frmInscripción
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
            lblTitulo = new Label();
            lblNombre = new Label();
            lblEdad = new Label();
            lblPlanes = new Label();
            lblturnos = new Label();
            txtNombre = new TextBox();
            txtEdad = new TextBox();
            cmbPlanes = new ComboBox();
            cmbturnos = new ComboBox();
            chkEstudiante = new CheckBox();
            lblMeses = new Label();
            txtMeses = new TextBox();
            chkCasillero = new CheckBox();
            lblFormasdepago = new Label();
            grpPago = new GroupBox();
            cmbPago = new ComboBox();
            rbTarjeta = new RadioButton();
            rbEfectivo = new RadioButton();
            btnLimpiar = new Button();
            btnConfirmar = new Button();
            grpPago.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(87, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(68, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Inscripcion ";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 66);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre";
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Location = new Point(12, 104);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(33, 15);
            lblEdad.TabIndex = 2;
            lblEdad.Text = "Edad";
            // 
            // lblPlanes
            // 
            lblPlanes.AutoSize = true;
            lblPlanes.Location = new Point(12, 151);
            lblPlanes.Name = "lblPlanes";
            lblPlanes.Size = new Size(41, 15);
            lblPlanes.TabIndex = 3;
            lblPlanes.Text = "planes";
            // 
            // lblTurnos
            // 
            lblturnos.AutoSize = true;
            lblturnos.Location = new Point(12, 194);
            lblturnos.Name = "lblTurnos";
            lblturnos.Size = new Size(41, 15);
            lblturnos.TabIndex = 4;
            lblturnos.Text = "turnos";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(69, 63);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 5;
            // 
            // txtEdad
            // 
            txtEdad.Location = new Point(69, 104);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(33, 23);
            txtEdad.TabIndex = 6;
            // 
            // cmbPlanes
            // 
            cmbPlanes.FormattingEnabled = true;
            cmbPlanes.Location = new Point(69, 148);
            cmbPlanes.Name = "cmbPlanes";
            cmbPlanes.Size = new Size(100, 23);
            cmbPlanes.TabIndex = 7;
            // 
            // cmbturnos
            // 
            cmbturnos.FormattingEnabled = true;
            cmbturnos.Items.AddRange(new object[] { "Mañana", "Tarde", "Noche" });
            cmbturnos.Location = new Point(69, 191);
            cmbturnos.Name = "cmbturnos";
            cmbturnos.Size = new Size(100, 23);
            cmbturnos.TabIndex = 8;
            // 
            // chkEstudiante
            // 
            chkEstudiante.AutoSize = true;
            chkEstudiante.Location = new Point(126, 104);
            chkEstudiante.Name = "chkEstudiante";
            chkEstudiante.Size = new Size(81, 19);
            chkEstudiante.TabIndex = 9;
            chkEstudiante.Text = "Estudiante";
            chkEstudiante.UseVisualStyleBackColor = true;
            // 
            // lblMeses
            // 
            lblMeses.AutoSize = true;
            lblMeses.Location = new Point(12, 245);
            lblMeses.Name = "lblMeses";
            lblMeses.Size = new Size(40, 15);
            lblMeses.TabIndex = 10;
            lblMeses.Text = "meses";
            // 
            // txtMeses
            // 
            txtMeses.Location = new Point(69, 242);
            txtMeses.Name = "txtMeses";
            txtMeses.Size = new Size(33, 23);
            txtMeses.TabIndex = 11;
            // 
            // chkCasillero
            // 
            chkCasillero.AutoSize = true;
            chkCasillero.Location = new Point(126, 244);
            chkCasillero.Name = "chkCasillero";
            chkCasillero.Size = new Size(69, 19);
            chkCasillero.TabIndex = 12;
            chkCasillero.Text = "casillero";
            chkCasillero.UseVisualStyleBackColor = true;
            // 
            // lblFormasdepago
            // 
            lblFormasdepago.AutoSize = true;
            lblFormasdepago.Location = new Point(6, 19);
            lblFormasdepago.Name = "lblFormasdepago";
            lblFormasdepago.Size = new Size(92, 15);
            lblFormasdepago.TabIndex = 13;
            lblFormasdepago.Text = "Formas de pago";
            // 
            // grpPago
            // 
            grpPago.Controls.Add(cmbPago);
            grpPago.Controls.Add(rbTarjeta);
            grpPago.Controls.Add(rbEfectivo);
            grpPago.Controls.Add(lblFormasdepago);
            grpPago.Location = new Point(36, 271);
            grpPago.Name = "grpPago";
            grpPago.Size = new Size(212, 108);
            grpPago.TabIndex = 14;
            grpPago.TabStop = false;
            // 
            // cmbPago
            // 
            cmbPago.FormattingEnabled = true;
            cmbPago.Location = new Point(106, 71);
            cmbPago.Name = "cmbPago";
            cmbPago.Size = new Size(100, 23);
            cmbPago.TabIndex = 15;
            // 
            // rbTarjeta
            // 
            rbTarjeta.AutoSize = true;
            rbTarjeta.Location = new Point(33, 71);
            rbTarjeta.Name = "rbTarjeta";
            rbTarjeta.Size = new Size(58, 19);
            rbTarjeta.TabIndex = 15;
            rbTarjeta.TabStop = true;
            rbTarjeta.Text = "tarjeta";
            rbTarjeta.UseVisualStyleBackColor = true;
            // 
            // rbEfectivo
            // 
            rbEfectivo.AutoSize = true;
            rbEfectivo.Location = new Point(33, 46);
            rbEfectivo.Name = "rbEfectivo";
            rbEfectivo.Size = new Size(67, 19);
            rbEfectivo.TabIndex = 14;
            rbEfectivo.TabStop = true;
            rbEfectivo.Text = "efectivo";
            rbEfectivo.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(52, 389);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 16;
            btnLimpiar.Text = "limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(151, 389);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(75, 23);
            btnConfirmar.TabIndex = 17;
            btnConfirmar.Text = "confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // frmInscripción
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(292, 424);
            Controls.Add(btnConfirmar);
            Controls.Add(btnLimpiar);
            Controls.Add(grpPago);
            Controls.Add(chkCasillero);
            Controls.Add(txtMeses);
            Controls.Add(lblMeses);
            Controls.Add(chkEstudiante);
            Controls.Add(cmbturnos);
            Controls.Add(cmbPlanes);
            Controls.Add(txtEdad);
            Controls.Add(txtNombre);
            Controls.Add(lblturnos);
            Controls.Add(lblPlanes);
            Controls.Add(lblEdad);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Name = "frmInscripción";
            Text = "Inscripcion-Gymnasio";
            grpPago.ResumeLayout(false);
            grpPago.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNombre;
        private Label lblEdad;
        private Label lblPlanes;
        private Label lblturnos;
        private TextBox txtNombre;
        private TextBox txtEdad;
        private ComboBox cmbPlanes;
        private ComboBox cmbturnos;
        private CheckBox chkEstudiante;
        private Label lblMeses;
        private TextBox txtMeses;
        private CheckBox chkCasillero;
        private Label lblFormasdepago;
        private GroupBox grpPago;
        private RadioButton rbTarjeta;
        private RadioButton rbEfectivo;
        private ComboBox cmbPago;
        private Button btnLimpiar;
        private Button btnConfirmar;
    }
}
