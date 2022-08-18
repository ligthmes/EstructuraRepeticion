namespace pjSegurosVidas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Captuando los datos 
            string Razon = txtRazonsocial.Text;
            string tipo = cboTipo.Text;
            int cantidad = int.Parse(txtCantidad.Text);

            // calculando el pago mensual por tiupo 
            double pagoMensual = 0;
            switch (tipo)
            {
                case "Inversion Clasica":
                    if (cantidad <= 10)
                        pagoMensual = 50 * cantidad;
                    else
                        pagoMensual = (50 * cantidad) + (10 * (cantidad - 10));
                    break;

                case "Inversion Platino":
                    if (cantidad <= 8)
                        pagoMensual = 80 * cantidad;
                    else
                        pagoMensual = (80 * cantidad) + (8 * (cantidad - 8));
                    break;

                case "Inversion Oro":
                    if (cantidad < 6)
                        pagoMensual = 150 * cantidad;
                    else
                        pagoMensual = (150 * cantidad + (15 * (cantidad - 6)));
                    break;
            }
            //Impriendo el detalle de la protoforma
            ListViewItem fila = new ListViewItem(tipo);
            fila.SubItems.Add(cantidad.ToString());
            fila.SubItems.Add(pagoMensual.ToString("0.00"));
            lvProtoforma.Items.Add(fila);
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            // Deternimar el total dde persoan aseguradas
            int totaAsegurados = 0;
            for (int i = 0; i < lvProtoforma.Items.Count; i++)
            {
                if (lvProtoforma.Items[i].SubItems[0].Text != "")
                    totaAsegurados += int.Parse(lvProtoforma.Items[i].SubItems[1].Text);
            }
            //Determinar el monto acumulado a cancelar
            double total = 0;
            for (int i = 0; i < lvProtoforma.Items.Count; i++)
            {
                if (lvProtoforma.Items[i].SubItems[0].Text != "")
                    total += double.Parse(lvProtoforma.Items[i].SubItems[2].Text);
            }

            // impresion de las estadistica
            lvEstadistica.Items.Clear();
            string[] elementosFilas = new string[2];
            ListViewItem row;
            elementosFilas[0] = "Total de  personas aseguradas";
            elementosFilas[1] = total.ToString();
            row = new ListViewItem(elementosFilas);
            lvEstadistica.Items.Add(row);

            elementosFilas[0] = "Monto total a cancelar";
            elementosFilas[1] = total.ToString("C");
            row = new ListViewItem(elementosFilas);
            lvEstadistica.Items.Add(row);
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            DialogResult  r = MessageBox.Show("Esta seguro de anular la protoforma?", "seguros", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes)
                txtRazonsocial.Clear();
            cboTipo.Text = ("Seleccione tipo");
            txtCantidad.Clear();
            txtRazonsocial.Focus();
            lvProtoforma.Items.Clear();
            lvEstadistica.Items.Clear();
              
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult o = MessageBox.Show("Esta seguro de salir", "seguro pendejo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (o == DialogResult.Yes)
                this.Close();
        }
    }
}