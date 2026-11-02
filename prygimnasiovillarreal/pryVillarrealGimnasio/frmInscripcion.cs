namespace pryVillarrealGimnasio;

public partial class frmInscripcion : Form
{
    private const decimal PRECIO_MUSCULACION = 15000m;
    private const decimal PRECIO_FUNCIONAL = 18000m;
    private const decimal PRECIO_NATACION = 22000m;
    private const decimal PRECIO_CASILLERO = 3000m;
    private const decimal DESCUENTO_MENOR = 0.25m;
    private const decimal DESCUENTO_MAYOR = 0.30m;
    private const decimal DESCUENTO_ESTUDIANTE = 0.15m;
    private const decimal DESCUENTO_EFECTIVO = 0.10m;
    private const decimal RECARGO_TRES_CUOTAS = 0.10m;
    private const decimal RECARGO_SEIS_CUOTAS = 0.20m;
    private const int EDAD_MINIMA = 14;
    private const int MESES_MINIMOS = 1;
    private const int MESES_MAXIMOS = 12;

    private struct Socio
    {
        public string Nombre, Plan, Turno, FormaPago;
        public int Edad, Meses, Cuotas;
        public bool Estudiante, Casillero;
    }

    public frmInscripcion() => InitializeComponent();

    private void frmInscripcion_Load(object? sender, EventArgs e) => EstadoInicial();

    private void EstadoInicial()
    {
        txtNombre.Clear(); txtEdad.Clear(); txtMeses.Text = MESES_MINIMOS.ToString();
        cboPlan.SelectedIndex = 0; cboTurno.SelectedIndex = 0; cboCuotas.SelectedIndex = -1;
        chkEstudiante.Checked = false; chkCasillero.Checked = false; rdoEfectivo.Checked = true;
        cboCuotas.Enabled = false; btnCalcular.Enabled = false; txtEdad.Enabled = false;
        cboPlan.Enabled = false; cboTurno.Enabled = false; txtMeses.Enabled = false;
        txtNombre.Focus();
    }

    private void txtNombre_TextChanged(object? sender, EventArgs e)
    {
        var posicion = txtNombre.SelectionStart; txtNombre.Text = txtNombre.Text.ToUpperInvariant(); txtNombre.SelectionStart = posicion;
        txtEdad.Enabled = txtNombre.Text.Trim() != ""; ValidarFormulario();
    }

    private void txtNombre_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) e.Handled = true;
    }

    private void txtEdad_TextChanged(object? sender, EventArgs e)
    {
        if (int.TryParse(txtEdad.Text, out var edad)) { cboPlan.Enabled = edad >= EDAD_MINIMA; if (edad < EDAD_MINIMA) cboPlan.SelectedIndex = -1; }
        else { cboPlan.Enabled = false; cboPlan.SelectedIndex = -1; }
        ValidarFormulario();
    }

    private void txtEdad_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
    }

    private void cboPlan_SelectedIndexChanged(object? sender, EventArgs e)
    {
        cboTurno.Enabled = cboPlan.SelectedIndex >= 0; ValidarFormulario();
    }

    private void cboTurno_SelectedIndexChanged(object? sender, EventArgs e)
    {
        txtMeses.Enabled = cboTurno.SelectedIndex >= 0; ValidarFormulario();
    }

    private void txtMeses_TextChanged(object? sender, EventArgs e) => ValidarFormulario();

    private void txtMeses_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
    }

    private void pago_CheckedChanged(object? sender, EventArgs e)
    {
        cboCuotas.Enabled = rdoTarjeta.Checked;
        if (rdoTarjeta.Checked && cboCuotas.SelectedIndex < 0) cboCuotas.SelectedIndex = 0;
        if (rdoEfectivo.Checked) cboCuotas.SelectedIndex = -1;
    }

    private void ValidarFormulario()
    {
        var edadOk = int.TryParse(txtEdad.Text, out var edad) && edad >= EDAD_MINIMA;
        var mesesOk = int.TryParse(txtMeses.Text, out var meses) && meses >= MESES_MINIMOS && meses <= MESES_MAXIMOS;
        btnCalcular.Enabled = txtNombre.Text.Trim() != "" && edadOk && cboPlan.SelectedIndex >= 0 && cboTurno.SelectedIndex >= 0 && mesesOk && (!rdoTarjeta.Checked || cboCuotas.SelectedIndex >= 0);
    }

    private void btnCalcular_Click(object? sender, EventArgs e)
    {
        if (!int.TryParse(txtEdad.Text, out var edad) || edad < EDAD_MINIMA)
        { MessageBox.Show($"La edad mínima para inscribirse es de {EDAD_MINIMA} años.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        if (!int.TryParse(txtMeses.Text, out var meses) || meses < MESES_MINIMOS || meses > MESES_MAXIMOS)
        { MessageBox.Show($"La cantidad de meses debe estar entre {MESES_MINIMOS} y {MESES_MAXIMOS}.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

        var socio = new Socio { Nombre = txtNombre.Text.Trim(), Edad = edad, Plan = cboPlan.Text, Turno = cboTurno.Text, Meses = meses, Estudiante = chkEstudiante.Checked, Casillero = chkCasillero.Checked, FormaPago = rdoTarjeta.Checked ? "Tarjeta" : "Efectivo", Cuotas = rdoTarjeta.Checked ? Convert.ToInt32(cboCuotas.SelectedItem) : 1 };
        var precioPlan = PrecioSegunPlan(socio.Plan);
        var precioMensual = precioPlan + (socio.Casillero ? PRECIO_CASILLERO : 0m);
        var subtotal = precioMensual * socio.Meses;
        var descuento = socio.Edad < 18 ? DESCUENTO_MENOR : socio.Edad >= 65 ? DESCUENTO_MAYOR : socio.Estudiante ? DESCUENTO_ESTUDIANTE : 0m;
        var total = subtotal * (1m - descuento);
        var recargo = socio.FormaPago == "Tarjeta" ? RecargoSegunCuotas(socio.Cuotas) : 0m;
        total *= 1m + recargo;
        if (socio.FormaPago == "Efectivo") total *= 1m - DESCUENTO_EFECTIVO;
        var categoria = socio.Edad < 18 ? "Menor" : socio.Edad >= 65 ? "Adulto mayor" : socio.Estudiante ? "Estudiante" : "General";
        var cuota = total / socio.Cuotas;
        var detalle = $"SOCIO: {socio.Nombre}\nCategoría: {categoria}\nPlan: {socio.Plan} - Turno: {socio.Turno}\nMeses: {socio.Meses}\nForma de pago: {socio.FormaPago} ({socio.Cuotas} cuota(s))\n\nSubtotal: {subtotal:C0}\nDescuento: {descuento:P0}\nTotal: {total:C0}\nValor de cada cuota: {cuota:C0}";
        MessageBox.Show(detalle, "Detalle de inscripción", MessageBoxButtons.OK, MessageBoxIcon.Information); EstadoInicial();
    }

    private static decimal PrecioSegunPlan(string plan) => plan switch
    {
        "Musculación" => PRECIO_MUSCULACION,
        "Funcional" => PRECIO_FUNCIONAL,
        "Natación" => PRECIO_NATACION,
        _ => 0m
    };

    private static decimal RecargoSegunCuotas(int cuotas) => cuotas switch
    {
        3 => RECARGO_TRES_CUOTAS,
        6 => RECARGO_SEIS_CUOTAS,
        _ => 0m
    };
}
