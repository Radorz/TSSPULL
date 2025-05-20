namespace TSSPULL.Forms
{
    partial class InicioForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Button btnImportar;
        private Button btnConsultar;
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
            this.btnImportar = new Button();
            this.btnConsultar = new Button();

            // Título
            lblTitulo.Text = "Menú Principal - TSS Pull";
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(40, 20);
            lblTitulo.AutoSize = true;

            // Botón Importar
            btnImportar.Text = "📥 Importar Nómina";
            btnImportar.Font = new Font("Segoe UI", 12F);
            btnImportar.Size = new Size(250, 45);
            btnImportar.Location = new Point(50, 80);
            btnImportar.Click += (s, e) =>
            {
                var f = new ImportarForm();
                f.ShowDialog();
            };

            // Botón Consultar
            btnConsultar.Text = "📊 Consultar Importaciones";
            btnConsultar.Font = new Font("Segoe UI", 12F);
            btnConsultar.Size = new Size(250, 45);
            btnConsultar.Location = new Point(50, 140);
            btnConsultar.Click += (s, e) =>
            {
                var f = new ConsultaForm();
                f.ShowDialog();
            };

            // Configuración del formulario
            this.ClientSize = new Size(360, 230);
            this.Controls.Add(lblTitulo);
            this.Controls.Add(btnImportar);
            this.Controls.Add(btnConsultar);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "TSS - Panel Principal";
        }

        #endregion
    }
}