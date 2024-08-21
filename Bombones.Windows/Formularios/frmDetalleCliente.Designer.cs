namespace Bombones.Windows.Formularios
{
    partial class frmDetalleCliente
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
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            btnCerrar = new Button();
            label3 = new Label();
            label6 = new Label();
            label4 = new Label();
            txtDocumento = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            dgvTelefonos = new DataGridView();
            colTelefonoId = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colNumero = new DataGridViewTextBoxColumn();
            dgvDirecciones = new DataGridView();
            colDireccionId = new DataGridViewTextBoxColumn();
            colTipoDireccion = new DataGridViewTextBoxColumn();
            colCalle = new DataGridViewTextBoxColumn();
            colAltura = new DataGridViewTextBoxColumn();
            colEntre1 = new DataGridViewTextBoxColumn();
            colEntre2 = new DataGridViewTextBoxColumn();
            colCiudad = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colPais = new DataGridViewTextBoxColumn();
            colCodPostal = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTelefonos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDirecciones).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvDirecciones);
            splitContainer1.Size = new Size(1121, 723);
            splitContainer1.SplitterDistance = 282;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(btnCerrar);
            splitContainer2.Panel1.Controls.Add(label3);
            splitContainer2.Panel1.Controls.Add(label6);
            splitContainer2.Panel1.Controls.Add(label4);
            splitContainer2.Panel1.Controls.Add(txtDocumento);
            splitContainer2.Panel1.Controls.Add(txtApellido);
            splitContainer2.Panel1.Controls.Add(txtNombre);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dgvTelefonos);
            splitContainer2.Size = new Size(1121, 282);
            splitContainer2.SplitterDistance = 559;
            splitContainer2.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.Image = Properties.Resources.Cancelar;
            btnCerrar.Location = new Point(225, 187);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(105, 54);
            btnCerrar.TabIndex = 55;
            btnCerrar.Text = "Cerrar";
            btnCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 59);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 54;
            label3.Text = "Documento:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 147);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 52;
            label6.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 104);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 53;
            label4.Text = "Apellido:";
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtDocumento.Location = new Point(127, 56);
            txtDocumento.MaxLength = 8;
            txtDocumento.Name = "txtDocumento";
            txtDocumento.ReadOnly = true;
            txtDocumento.Size = new Size(148, 23);
            txtDocumento.TabIndex = 49;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtApellido.Location = new Point(127, 101);
            txtApellido.MaxLength = 50;
            txtApellido.Name = "txtApellido";
            txtApellido.ReadOnly = true;
            txtApellido.Size = new Size(412, 23);
            txtApellido.TabIndex = 50;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtNombre.Location = new Point(127, 144);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(412, 23);
            txtNombre.TabIndex = 51;
            // 
            // dgvTelefonos
            // 
            dgvTelefonos.AllowUserToAddRows = false;
            dgvTelefonos.AllowUserToDeleteRows = false;
            dgvTelefonos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTelefonos.Columns.AddRange(new DataGridViewColumn[] { colTelefonoId, colTipo, colNumero });
            dgvTelefonos.Dock = DockStyle.Fill;
            dgvTelefonos.Location = new Point(0, 0);
            dgvTelefonos.MultiSelect = false;
            dgvTelefonos.Name = "dgvTelefonos";
            dgvTelefonos.ReadOnly = true;
            dgvTelefonos.RowHeadersVisible = false;
            dgvTelefonos.Size = new Size(558, 282);
            dgvTelefonos.TabIndex = 1;
            // 
            // colTelefonoId
            // 
            colTelefonoId.HeaderText = "Id";
            colTelefonoId.Name = "colTelefonoId";
            colTelefonoId.ReadOnly = true;
            colTelefonoId.Visible = false;
            // 
            // colTipo
            // 
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTipo.HeaderText = "Tipo Teléfono";
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            // 
            // colNumero
            // 
            colNumero.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNumero.HeaderText = "Número";
            colNumero.Name = "colNumero";
            colNumero.ReadOnly = true;
            // 
            // dgvDirecciones
            // 
            dgvDirecciones.AllowUserToAddRows = false;
            dgvDirecciones.AllowUserToDeleteRows = false;
            dgvDirecciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDirecciones.Columns.AddRange(new DataGridViewColumn[] { colDireccionId, colTipoDireccion, colCalle, colAltura, colEntre1, colEntre2, colCiudad, colEstado, colPais, colCodPostal });
            dgvDirecciones.Dock = DockStyle.Fill;
            dgvDirecciones.Location = new Point(0, 0);
            dgvDirecciones.MultiSelect = false;
            dgvDirecciones.Name = "dgvDirecciones";
            dgvDirecciones.ReadOnly = true;
            dgvDirecciones.RowHeadersVisible = false;
            dgvDirecciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDirecciones.Size = new Size(1121, 437);
            dgvDirecciones.TabIndex = 1;
            // 
            // colDireccionId
            // 
            colDireccionId.HeaderText = "Id";
            colDireccionId.Name = "colDireccionId";
            colDireccionId.ReadOnly = true;
            colDireccionId.Visible = false;
            // 
            // colTipoDireccion
            // 
            colTipoDireccion.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colTipoDireccion.HeaderText = "Tipo Dirección";
            colTipoDireccion.Name = "colTipoDireccion";
            colTipoDireccion.ReadOnly = true;
            colTipoDireccion.Width = 108;
            // 
            // colCalle
            // 
            colCalle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCalle.HeaderText = "Calle";
            colCalle.Name = "colCalle";
            colCalle.ReadOnly = true;
            // 
            // colAltura
            // 
            colAltura.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colAltura.HeaderText = "Altura";
            colAltura.Name = "colAltura";
            colAltura.ReadOnly = true;
            colAltura.Width = 64;
            // 
            // colEntre1
            // 
            colEntre1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEntre1.HeaderText = "Entre";
            colEntre1.Name = "colEntre1";
            colEntre1.ReadOnly = true;
            // 
            // colEntre2
            // 
            colEntre2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEntre2.HeaderText = "Y";
            colEntre2.Name = "colEntre2";
            colEntre2.ReadOnly = true;
            // 
            // colCiudad
            // 
            colCiudad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCiudad.HeaderText = "Ciudad";
            colCiudad.Name = "colCiudad";
            colCiudad.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEstado.HeaderText = "Pcia.";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // colPais
            // 
            colPais.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPais.HeaderText = "País";
            colPais.Name = "colPais";
            colPais.ReadOnly = true;
            // 
            // colCodPostal
            // 
            colCodPostal.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colCodPostal.HeaderText = "Cod. Postal";
            colCodPostal.Name = "colCodPostal";
            colCodPostal.ReadOnly = true;
            colCodPostal.Width = 92;
            // 
            // frmDetalleCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1121, 723);
            Controls.Add(splitContainer1);
            Name = "frmDetalleCliente";
            Text = "frmDetalleCliente";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTelefonos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDirecciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Button btnCerrar;
        private Label label3;
        private Label label6;
        private Label label4;
        private TextBox txtDocumento;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private DataGridView dgvTelefonos;
        private DataGridViewTextBoxColumn colTelefonoId;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colNumero;
        private DataGridView dgvDirecciones;
        private DataGridViewTextBoxColumn colDireccionId;
        private DataGridViewTextBoxColumn colTipoDireccion;
        private DataGridViewTextBoxColumn colCalle;
        private DataGridViewTextBoxColumn colAltura;
        private DataGridViewTextBoxColumn colEntre1;
        private DataGridViewTextBoxColumn colEntre2;
        private DataGridViewTextBoxColumn colCiudad;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colPais;
        private DataGridViewTextBoxColumn colCodPostal;
    }
}