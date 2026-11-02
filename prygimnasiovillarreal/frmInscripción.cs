using System;
using System.IO;
using System.Windows.Forms;

namespace prygimnasiovillarreal
{
    public partial class frmInscripción : Form
    {
        const int MUSCULACION = 15000;
        const int FUNCIONAL = 18000;
        const int NATACION = 22000;
        const int CASILLERO = 3000;

        const decimal DESCUENTO_MENOR = 0.25m;
        const decimal DESCUENTO_MAYOR = 0.30m;
        const decimal DESCUENTO_ESTUDIANTE = 0.15m;
        const decimal DESCUENTO_EFECTIVO = 0.10m;
        const decimal RECARGO_CUOTA3 = 0.10m;
        const decimal RECARGO_CUOTA6 = 0.30m;

        string nom, edad, planes, turno, meses, pago, estudiante, casillero;
        int Edad, Meses, Cuotas;
        decimal Total, SubTotal, Desc_Edad, Recargo_Pago, Desc_Pago;

        public frmInscripción()
        {
            InitializeComponent();

            // Evita duplicar opciones si el diseñador ya las carga.
            cmbPlanes.Items.Clear();
            cmbPlanes.Items.Add("Musculación");
            cmbPlanes.Items.Add("Funcional");
            cmbPlanes.Items.Add("Natación");

            cmbturnos.Items.Clear();
            cmbturnos.Items.Add("Mañana");
            cmbturnos.Items.Add("Tarde");
            cmbturnos.Items.Add("Noche");

            cmbPago.Items.Clear();
            cmbPago.Items.Add(1);
            cmbPago.Items.Add(3);
            cmbPago.Items.Add(6);
        }

        private void EstadoInicial()
        {
            txtNombre.Clear();
            txtEdad.Clear();
            txtMeses.Text = "1";

            cmbPlanes.SelectedIndex = 0;
            cmbturnos.SelectedIndex = 0;
            cmbPago.SelectedIndex = 0;

            cmbPlanes.Enabled = false;
            cmbturnos.Enabled = false;
            cmbPago.Enabled = false;
            txtEdad.Enabled = false;
            txtMeses.Enabled = false;

            chkCasillero.Checked = false;
            chkEstudiante.Checked = false;
            rbEfectivo.Checked = true;
            rbTarjeta.Checked = false;

            btnConfirmar.Enabled = false;
            btnLimpiar.Enabled = true;

            Edad = 0;
            Meses = 1;
            Cuotas = 1;
            Total = 0;
            SubTotal = 0;
            Desc_Edad = 0;
            Desc_Pago = 0;
            Recargo_Pago = 0;
            nom = edad = planes = turno = meses = "";
            pago = "Efectivo";

            txtNombre.Focus();
        }

        private void frmInscripción_Load(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {
            nom = txtNombre.Text.Trim();
            txtEdad.Enabled = nom != "";
            ValidarFormulario();
        }

        private void txtNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            edad = txtEdad.Text;

            if (int.TryParse(edad, out Edad))
            {
                cmbPlanes.Enabled = Edad >= 15;
                if (Edad < 15)
                    cmbPlanes.SelectedIndex = -1;
            }
            else
            {
                Edad = 0;
                cmbPlanes.Enabled = false;
            }

            ValidarFormulario();
        }

        private void txtEdad_Click_1(object sender, EventArgs e)
        {
        }

        // Se conserva por si el diseñador tiene asociado este evento.
        private void cmbPlanes_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtEdad.Text, out Edad) && Edad < 15)
            {
                MessageBox.Show("La edad mínima para inscribirse es de 15 años.");
                txtEdad.Clear();
                txtEdad.Focus();
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void cmbPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            planes = cmbPlanes.Text;
            cmbturnos.Enabled = cmbPlanes.SelectedIndex != -1;
            ValidarFormulario();
        }

        private void cmbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            turno = cmbturnos.Text;
            txtMeses.Enabled = cmbturnos.SelectedIndex != -1;
            ValidarFormulario();
        }

        private void txtMeses_TextChanged(object sender, EventArgs e)
        {
            meses = txtMeses.Text;

            if (int.TryParse(meses, out Meses))
            {
                if (Meses > 12)
                {
                    MessageBox.Show("No se puede ingresar más de 12 meses.");
                    txtMeses.Text = "12";
                    txtMeses.SelectAll();
                }
            }
            else
            {
                Meses = 0;
            }

            ValidarFormulario();
        }

        private void txtMeses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEfectivo.Checked)
                pago = "Efectivo";
            cmbPago.Enabled = rbTarjeta.Checked;
        }

        private void rbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTarjeta.Checked)
            {
                pago = "Tarjeta";
                cmbPago.Enabled = true;
                if (cmbPago.SelectedIndex == -1)
                    cmbPago.SelectedIndex = 0;
            }
            else
            {
                cmbPago.Enabled = false;
                pago = "Efectivo";
            }
        }

        private void cmbPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarFormulario();
        }

        private void ValidarFormulario()
        {
            bool edadValida = int.TryParse(txtEdad.Text, out int edadIngresada)
                              && edadIngresada >= 15;
            bool mesesValidos = int.TryParse(txtMeses.Text, out int mesesIngresados)
                                && mesesIngresados >= 1 && mesesIngresados <= 12;

            bool pagoValido = !rbTarjeta.Checked || cmbPago.SelectedItem != null;

            btnConfirmar.Enabled =
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                edadValida &&
                mesesValidos &&
                cmbPlanes.SelectedIndex != -1 &&
                cmbturnos.SelectedIndex != -1 &&
                pagoValido;
        }

        // Si Confirmar ya estaba conectado a btnCalcular_Click, sigue funcionando.
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            CalcularYGuardar();
        }

        // Asociá el Click del botón Confirmar a este método si aún no está conectado.
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            CalcularYGuardar();
        }

        private void CalcularYGuardar()
        {
            if (!int.TryParse(txtEdad.Text, out Edad) || Edad < 15)
            {
                MessageBox.Show("Ingresá una edad válida (mínimo 15 años).");
                txtEdad.Focus();
                return;
            }

            if (!int.TryParse(txtMeses.Text, out Meses) || Meses < 1 || Meses > 12)
            {
                MessageBox.Show("Ingresá una cantidad de meses entre 1 y 12.");
                txtMeses.Focus();
                return;
            }

            if (cmbPlanes.SelectedIndex == -1 || cmbturnos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccioná un plan y un turno.");
                return;
            }

            if (rbTarjeta.Checked && cmbPago.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná la cantidad de cuotas.");
                return;
            }

            nom = txtNombre.Text.Trim();
            planes = cmbPlanes.Text;
            turno = cmbturnos.Text;
            meses = txtMeses.Text;
            estudiante = chkEstudiante.Checked ? "SI" : "NO";
            casillero = chkCasillero.Checked ? "SI" : "NO";
            pago = rbEfectivo.Checked ? "Efectivo" : "Tarjeta";

            // Precio del plan
            int precioPlan;
            switch (planes)
            {
                case "Musculación": precioPlan = MUSCULACION; break;
                case "Funcional": precioPlan = FUNCIONAL; break;
                case "Natación": precioPlan = NATACION; break;
                default:
                    MessageBox.Show("El plan seleccionado no es válido.");
                    return;
            }

            if (chkCasillero.Checked)
                precioPlan += CASILLERO;

            SubTotal = precioPlan * Meses;
            Desc_Edad = 0;
            Desc_Pago = 0;
            Recargo_Pago = 0;
            Cuotas = 1;

            // Descuento por edad o estudiante (se aplica uno solo).
            decimal porcentajeEdad = 0;
            if (Edad < 18)
                porcentajeEdad = DESCUENTO_MENOR;
            else if (Edad >= 65)
                porcentajeEdad = DESCUENTO_MAYOR;
            else if (chkEstudiante.Checked)
                porcentajeEdad = DESCUENTO_ESTUDIANTE;

            Desc_Edad = SubTotal * porcentajeEdad;
            decimal importe = SubTotal - Desc_Edad;

            if (rbEfectivo.Checked)
            {
                Desc_Pago = importe * DESCUENTO_EFECTIVO;
                Total = importe - Desc_Pago;
            }
            else
            {
                Cuotas = Convert.ToInt32(cmbPago.SelectedItem);
                if (Cuotas == 3)
                {
                    Recargo_Pago = importe * RECARGO_CUOTA3;
                    Total = importe + Recargo_Pago;
                }
                else if (Cuotas == 6)
                {
                    Recargo_Pago = importe * RECARGO_CUOTA6;
                    Total = importe + Recargo_Pago;
                }
                else
                {
                    Total = importe;
                }
            }

            // Guardar en Documentos/GimnasioVillarreal.
            string carpeta = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "GimnasioVillarreal");
            string rutaArchivo = Path.Combine(carpeta, "RegistroInscripciones.txt");

            try
            {
                Directory.CreateDirectory(carpeta);

                using (StreamWriter archivo = new StreamWriter(rutaArchivo, true))
                {
                    archivo.WriteLine("--- Datos de Inscripción ---");
                    archivo.WriteLine("Nombre: " + nom);
                    archivo.WriteLine("Edad: " + Edad);
                    archivo.WriteLine("Estudiante: " + estudiante);
                    archivo.WriteLine("Plan: " + planes);
                    archivo.WriteLine("Turno: " + turno);
                    archivo.WriteLine("Meses: " + Meses);
                    archivo.WriteLine("Casillero: " + casillero);
                    archivo.WriteLine("Forma de pago: " + pago);
                    archivo.WriteLine("Cuotas: " + (pago == "Efectivo" ? "-" : Cuotas.ToString()));
                    archivo.WriteLine("Subtotal: $" + SubTotal.ToString("N2"));
                    archivo.WriteLine("Descuento edad/estudiante: $" + Desc_Edad.ToString("N2"));
                    archivo.WriteLine("Descuento por efectivo: $" + Desc_Pago.ToString("N2"));
                    archivo.WriteLine("Recargo: $" + Recargo_Pago.ToString("N2"));
                    archivo.WriteLine("Total: $" + Total.ToString("N2"));
                    archivo.WriteLine("------------------------------");
                    archivo.WriteLine();
                }

                MessageBox.Show(
                    "Inscripción guardada correctamente.\n" +
                    "Total a pagar: $" + Total.ToString("N2") +
                    "\n\nArchivo:\n" + rutaArchivo,
                    "Inscripción confirmada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                EstadoInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo guardar la inscripción.\n\n" +
                    ex.Message + "\n\nRuta:\n" + rutaArchivo,
                    "Error al guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }
    }
}
