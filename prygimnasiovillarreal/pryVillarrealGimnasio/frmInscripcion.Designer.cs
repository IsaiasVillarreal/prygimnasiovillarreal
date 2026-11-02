namespace pryVillarrealGimnasio;

partial class frmInscripcion
{
    private System.ComponentModel.IContainer components = null!;
    private GroupBox grpDatos;
    private Label lblNombre;
    private TextBox txtNombre;
    private Label lblEdad;
    private TextBox txtEdad;
    private CheckBox chkEstudiante;
    private GroupBox grpPlan;
    private Label lblPlan;
    private ComboBox cboPlan;
    private Label lblTurno;
    private ComboBox cboTurno;
    private Label lblMeses;
    private TextBox txtMeses;
    private CheckBox chkCasillero;
    private GroupBox grpPago;
    private RadioButton rdoEfectivo;
    private RadioButton rdoTarjeta;
    private Label lblCuotas;
    private ComboBox cboCuotas;
    private Button btnCalcular;
    private Button btnLimpiar;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        grpDatos = new GroupBox(); lblNombre = new Label(); txtNombre = new TextBox();
        lblEdad = new Label(); txtEdad = new TextBox(); chkEstudiante = new CheckBox();
        grpPlan = new GroupBox(); lblPlan = new Label(); cboPlan = new ComboBox();
        lblTurno = new Label(); cboTurno = new ComboBox(); lblMeses = new Label();
        txtMeses = new TextBox(); chkCasillero = new CheckBox(); grpPago = new GroupBox();
        rdoEfectivo = new RadioButton(); rdoTarjeta = new RadioButton(); lblCuotas = new Label();
        cboCuotas = new ComboBox(); btnCalcular = new Button(); btnLimpiar = new Button();
        grpDatos.SuspendLayout(); grpPlan.SuspendLayout(); grpPago.SuspendLayout(); SuspendLayout();
        grpDatos.Text = "Datos personales"; grpDatos.Location = new Point(18, 18); grpDatos.Size = new Size(420, 105);
        lblNombre.Text = "Nombre:"; lblNombre.Location = new Point(18, 28); lblNombre.AutoSize = true;
        txtNombre.Location = new Point(105, 25); txtNombre.Size = new Size(285, 23); txtNombre.MaxLength = 30;
        txtNombre.TextChanged += txtNombre_TextChanged; txtNombre.KeyPress += txtNombre_KeyPress;
        lblEdad.Text = "Edad:"; lblEdad.Location = new Point(18, 65); lblEdad.AutoSize = true;
        txtEdad.Location = new Point(105, 62); txtEdad.Size = new Size(55, 23); txtEdad.MaxLength = 3;
        txtEdad.TextChanged += txtEdad_TextChanged; txtEdad.KeyPress += txtEdad_KeyPress;
        chkEstudiante.Text = "Estudiante"; chkEstudiante.Location = new Point(190, 64); chkEstudiante.AutoSize = true;
        grpDatos.Controls.AddRange(new Control[] { lblNombre, txtNombre, lblEdad, txtEdad, chkEstudiante });
        grpPlan.Text = "Plan y adicionales"; grpPlan.Location = new Point(18, 135); grpPlan.Size = new Size(420, 145);
        lblPlan.Text = "Plan:"; lblPlan.Location = new Point(18, 30); lblPlan.AutoSize = true;
        cboPlan.DropDownStyle = ComboBoxStyle.DropDownList; cboPlan.Location = new Point(105, 27); cboPlan.Size = new Size(140, 23);
        cboPlan.Items.AddRange(new object[] { "Musculación", "Funcional", "Natación" }); cboPlan.SelectedIndexChanged += cboPlan_SelectedIndexChanged;
        lblTurno.Text = "Turno:"; lblTurno.Location = new Point(18, 67); lblTurno.AutoSize = true;
        cboTurno.DropDownStyle = ComboBoxStyle.DropDownList; cboTurno.Location = new Point(105, 64); cboTurno.Size = new Size(140, 23);
        cboTurno.Items.AddRange(new object[] { "Mañana", "Tarde", "Noche" }); cboTurno.SelectedIndexChanged += cboTurno_SelectedIndexChanged;
        lblMeses.Text = "Meses:"; lblMeses.Location = new Point(18, 104); lblMeses.AutoSize = true;
        txtMeses.Location = new Point(105, 101); txtMeses.Size = new Size(55, 23); txtMeses.MaxLength = 2;
        txtMeses.TextChanged += txtMeses_TextChanged; txtMeses.KeyPress += txtMeses_KeyPress;
        chkCasillero.Text = "Casillero"; chkCasillero.Location = new Point(190, 103); chkCasillero.AutoSize = true;
        grpPlan.Controls.AddRange(new Control[] { lblPlan, cboPlan, lblTurno, cboTurno, lblMeses, txtMeses, chkCasillero });
        grpPago.Text = "Forma de pago"; grpPago.Location = new Point(18, 292); grpPago.Size = new Size(420, 95);
        rdoEfectivo.Text = "Efectivo"; rdoEfectivo.Location = new Point(18, 28); rdoEfectivo.AutoSize = true; rdoEfectivo.CheckedChanged += pago_CheckedChanged;
        rdoTarjeta.Text = "Tarjeta"; rdoTarjeta.Location = new Point(115, 28); rdoTarjeta.AutoSize = true; rdoTarjeta.CheckedChanged += pago_CheckedChanged;
        lblCuotas.Text = "Cuotas:"; lblCuotas.Location = new Point(210, 29); lblCuotas.AutoSize = true;
        cboCuotas.DropDownStyle = ComboBoxStyle.DropDownList; cboCuotas.Location = new Point(270, 26); cboCuotas.Size = new Size(100, 23);
        cboCuotas.Items.AddRange(new object[] { 1, 3, 6 });
        grpPago.Controls.AddRange(new Control[] { rdoEfectivo, rdoTarjeta, lblCuotas, cboCuotas });
        btnCalcular.Text = "Calcular"; btnCalcular.Location = new Point(230, 410); btnCalcular.Size = new Size(100, 32); btnCalcular.Click += btnCalcular_Click;
        btnLimpiar.Text = "Limpiar"; btnLimpiar.Location = new Point(338, 410); btnLimpiar.Size = new Size(100, 32); btnLimpiar.Click += (_, _) => EstadoInicial();
        ClientSize = new Size(456, 460); Controls.AddRange(new Control[] { grpDatos, grpPlan, grpPago, btnCalcular, btnLimpiar });
        Name = "frmInscripcion"; Text = "Gimnasio Siglo — Inscripción"; StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle; MaximizeBox = false; Load += frmInscripcion_Load;
        grpDatos.ResumeLayout(false); grpDatos.PerformLayout(); grpPlan.ResumeLayout(false); grpPlan.PerformLayout(); grpPago.ResumeLayout(false); grpPago.PerformLayout(); ResumeLayout(false);
    }
}
