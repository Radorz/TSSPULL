namespace TSSPULL.Forms
{
    partial class ImportarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button btnSeleccionarArchivo;
        private Button btnImportar;
        private TextBox txtRutaArchivo;
        private DataGridView dgvDatos;
        private Label lblResultado;
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
            btnSeleccionarArchivo = new Button();
            btnImportar = new Button();
            txtRutaArchivo = new TextBox();
            dgvDatos = new DataGridView();
            lblResultado = new Label();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // btnSeleccionarArchivo
            // 
            btnSeleccionarArchivo.Location = new Point(430, 18);
            btnSeleccionarArchivo.Name = "btnSeleccionarArchivo";
            btnSeleccionarArchivo.Size = new Size(130, 27);
            btnSeleccionarArchivo.TabIndex = 1;
            btnSeleccionarArchivo.Text = "Seleccionar archivo";
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(570, 18);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(90, 27);
            btnImportar.TabIndex = 2;
            btnImportar.Text = "Importar";
            // 
            // txtRutaArchivo
            // 
            txtRutaArchivo.Location = new Point(20, 20);
            txtRutaArchivo.Name = "txtRutaArchivo";
            txtRutaArchivo.ReadOnly = true;
            txtRutaArchivo.Size = new Size(400, 23);
            txtRutaArchivo.TabIndex = 0;
            // 
            // dgvDatos
            // 
            dgvDatos.Location = new Point(20, 60);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(640, 300);
            dgvDatos.TabIndex = 3;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResultado.ForeColor = Color.Green;
            lblResultado.Location = new Point(20, 370);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(0, 19);
            lblResultado.TabIndex = 4;



            // 
            // ImportarForm
            // 
            ClientSize = new Size(700, 420);
            Controls.Add(txtRutaArchivo);
            Controls.Add(btnSeleccionarArchivo);
            Controls.Add(btnImportar);
            Controls.Add(dgvDatos);
            Controls.Add(lblResultado);
            Name = "ImportarForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "📥 Importar Nómina de Empresa";


            // Volver
            btnVolver = new Button();
            btnVolver.Text = "← Volver";
            btnVolver.Size = new Size(80, 25);
            btnVolver.Location = new Point(20, this.ClientSize.Height - 30);
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVolver.Click += (s, e) => this.Close();
            this.Controls.Add(btnVolver);

            Load += ImportarForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}