using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSSPULL.Data;

namespace TSSPULL.Forms
{
    public partial class ImportarForm : Form
    {
        public ImportarForm()
        {
            InitializeComponent();
            btnSeleccionarArchivo.Click += BtnSeleccionarArchivo_Click;
            btnImportar.Click += BtnImportar_Click;
        }

        private void ImportarForm_Load(object sender, EventArgs e)
        {

        }
        private string rutaArchivo = "";
        private DataTable tablaDatos = new DataTable();

        private void BtnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de texto (*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = ofd.FileName;
                txtRutaArchivo.Text = rutaArchivo;
                CargarArchivoTemporal();
            }
        }

        private void CargarArchivoTemporal()
        {
            tablaDatos = new DataTable();
            tablaDatos.Columns.Add("Cedula");
            tablaDatos.Columns.Add("NombreCompleto");
            tablaDatos.Columns.Add("Sueldo");
            tablaDatos.Columns.Add("OtrosIngresos");
            tablaDatos.Columns.Add("DescuentoSeguridad");

            int total = 0, errores = 0;
            var erroresDetalle = "";

            try
            {
                foreach (var linea in File.ReadAllLines(rutaArchivo))
                {
                    total++;
                    var partes = linea.Split(',');

                    if (partes.Length != 5)
                    {
                        errores++;
                        erroresDetalle += $"Línea {total}: formato incorrecto.\n";
                        continue;
                    }

                    string cedula = partes[0].Trim();
                    string nombre = partes[1].Trim();
                    bool sueldoOk = decimal.TryParse(partes[2], out decimal sueldo);
                    bool otrosOk = decimal.TryParse(partes[3], out decimal otros);
                    bool descOk = decimal.TryParse(partes[4], out decimal desc);

                    // Validaciones
                    if (cedula.Length != 11 || !cedula.All(char.IsDigit))
                    {
                        errores++;
                        erroresDetalle += $"Línea {total}: cédula inválida.\n";
                        continue;
                    }

                    if (nombre.Length < 3)
                    {
                        errores++;
                        erroresDetalle += $"Línea {total}: nombre incompleto.\n";
                        continue;
                    }

                    if (!sueldoOk || sueldo <= 0)
                    {
                        errores++;
                        erroresDetalle += $"Línea {total}: sueldo inválido.\n";
                        continue;
                    }

                    if (!otrosOk || otros < 0)
                    {
                        errores++;
                        erroresDetalle += $"Línea {total}: otros ingresos inválidos.\n";
                        continue;
                    }

                    if (!descOk || desc < 0 || desc > sueldo)
                    {
                        errores++;
                        erroresDetalle += $"Línea {total}: descuento inválido.\n";
                        continue;
                    }

                    // Si pasa todas las validaciones:
                    tablaDatos.Rows.Add(cedula, nombre, sueldo, otros, desc);
                }

                dgvDatos.DataSource = tablaDatos;
                lblResultado.ForeColor = Color.DarkBlue;

                if (errores == 0)
                {
                    lblResultado.Text = $"✅ Archivo cargado correctamente: {tablaDatos.Rows.Count} registros válidos.";
                }
                else
                {
                    lblResultado.Text = $"⚠️ {errores} errores detectados. {tablaDatos.Rows.Count} registros válidos.";
                    MessageBox.Show("Errores encontrados:\n\n" + erroresDetalle, "Errores de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo: " + ex.Message);
            }
        }

        private void BtnImportar_Click(object sender, EventArgs e)
        {
            if (tablaDatos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos cargados.");
                return;
            }

            try
            {
                using (var conn = SqlConnectionHelper.GetConnection())
                {
                    conn.Open();

                    foreach (DataRow row in tablaDatos.Rows)
                    {
                        var cmd = new SqlCommand(@"INSERT INTO RegistroNominaImportado 
                            (Cedula, NombreCompleto, Sueldo, OtrosIngresos, DescuentoSeguridad)
                            VALUES (@Cedula, @Nombre, @Sueldo, @Otros, @Descuento)", conn);

                        cmd.Parameters.AddWithValue("@Cedula", row["Cedula"]);
                        cmd.Parameters.AddWithValue("@Nombre", row["NombreCompleto"]);
                        cmd.Parameters.AddWithValue("@Sueldo", Convert.ToDecimal(row["Sueldo"]));
                        cmd.Parameters.AddWithValue("@Otros", Convert.ToDecimal(row["OtrosIngresos"]));
                        cmd.Parameters.AddWithValue("@Descuento", Convert.ToDecimal(row["DescuentoSeguridad"]));
                        cmd.ExecuteNonQuery();
                    }
                }

                lblResultado.Text = $"✅ Se importaron {tablaDatos.Rows.Count} registros correctamente.";
                lblResultado.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al importar: " + ex.Message);
            }
        }
    }
}
