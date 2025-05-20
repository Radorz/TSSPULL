using System.Data;
using System.Data.SqlClient;
using TSSPULL.Data;

namespace TSSPULL.Forms
{
    partial class ConsultaForm: Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblDesde;
        private Label lblHasta;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnBuscar;
        private DataGridView dgvResultados;
        private Button btnVolver;

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
            this.lblTitulo = new Label();
            this.lblDesde = new Label();
            this.lblHasta = new Label();
            this.dtpDesde = new DateTimePicker();
            this.dtpHasta = new DateTimePicker();
            this.btnBuscar = new Button();
            this.dgvResultados = new DataGridView();
            this.btnVolver = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();

            // Título
            lblTitulo.Text = "📊 Consulta de Importaciones";
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.AutoSize = true;

            // Desde
            lblDesde.Text = "Desde:";
            lblDesde.Location = new Point(20, 50);
            lblDesde.AutoSize = true;

            dtpDesde.Location = new Point(80, 45);
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Value = DateTime.Now.AddDays(-7);

            // Hasta
            lblHasta.Text = "Hasta:";
            lblHasta.Location = new Point(240, 50);
            lblHasta.AutoSize = true;

            dtpHasta.Location = new Point(300, 45);
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Value = DateTime.Now;

            // Buscar
            btnBuscar.Text = "Buscar";
            btnBuscar.Location = new Point(510, 45);
            btnBuscar.Size = new Size(90, 27);
            btnBuscar.Click += BtnBuscar_Click;

            // DataGridView
            dgvResultados.Location = new Point(20, 90);
            dgvResultados.Size = new Size(600, 250);
            dgvResultados.ReadOnly = true;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Volver
            btnVolver.Text = "← Volver";
            btnVolver.Location = new Point(20, 355);
            btnVolver.Size = new Size(80, 25);
            btnVolver.Click += (s, e) => this.Close();

            // Form
            this.ClientSize = new Size(650, 400);
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblDesde);
            this.Controls.Add(dtpDesde);
            this.Controls.Add(lblHasta);
            this.Controls.Add(dtpHasta);
            this.Controls.Add(btnBuscar);
            this.Controls.Add(dgvResultados);
            this.Controls.Add(btnVolver);
            this.Text = "Consulta de Registros Importados";
            this.StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = SqlConnectionHelper.GetConnection())
                {
                    conn.Open();
                    var query = @"SELECT Cedula, NombreCompleto, Sueldo, OtrosIngresos, DescuentoSeguridad, FechaImportacion
                                  FROM RegistroNominaImportado
                                  WHERE FechaImportacion BETWEEN @Desde AND @Hasta
                                  ORDER BY FechaImportacion DESC";

                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Desde", dtpDesde.Value.Date);
                    cmd.Parameters.AddWithValue("@Hasta", dtpHasta.Value.Date.AddDays(1).AddTicks(-1));

                    var adapter = new SqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);

                    dgvResultados.DataSource = table;

                    if (table.Rows.Count == 0)
                        MessageBox.Show("No se encontraron registros en ese período.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar registros: " + ex.Message);
            }
        }

        #endregion
    }
}