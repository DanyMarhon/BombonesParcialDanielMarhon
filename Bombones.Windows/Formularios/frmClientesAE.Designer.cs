namespace Bombones.Windows.Formularios
{
    partial class frmClientesAE
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientesAE));
            btnCancelar = new Button();
            btnOk = new Button();
            tabCliente = new TabControl();
            tabPage1 = new TabPage();
            lblTelefonos = new Label();
            lblDirecciones = new Label();
            label3 = new Label();
            label6 = new Label();
            label4 = new Label();
            txtDocumento = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            tabPage2 = new TabPage();
            dgvDirecciones = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDireccion = new DataGridViewTextBoxColumn();
            btnEditarDireccion = new Button();
            btnBorrarDireccion = new Button();
            btnAgregarDireccion = new Button();
            tabPage3 = new TabPage();
            splitContainer1 = new SplitContainer();
            dgvTelefonos = new DataGridView();
            colTelId = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            btnEditarTelefono = new Button();
            btnBorrarTelefono = new Button();
            btnAgregarTelefono = new Button();
            errorProvider1 = new ErrorProvider(components);
            tabCliente.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDirecciones).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTelefonos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(462, 488);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 36;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(50, 488);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(289, 54);
            btnOk.TabIndex = 35;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // tabCliente
            // 
            tabCliente.Controls.Add(tabPage1);
            tabCliente.Controls.Add(tabPage2);
            tabCliente.Controls.Add(tabPage3);
            tabCliente.Location = new Point(25, 39);
            tabCliente.Name = "tabCliente";
            tabCliente.SelectedIndex = 0;
            tabCliente.Size = new Size(934, 415);
            tabCliente.TabIndex = 43;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lblTelefonos);
            tabPage1.Controls.Add(lblDirecciones);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(txtDocumento);
            tabPage1.Controls.Add(txtApellido);
            tabPage1.Controls.Add(txtNombre);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(926, 387);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Datos Cliente";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblTelefonos
            // 
            lblTelefonos.AutoSize = true;
            lblTelefonos.Location = new Point(46, 218);
            lblTelefonos.Name = "lblTelefonos";
            lblTelefonos.Size = new Size(38, 15);
            lblTelefonos.TabIndex = 42;
            lblTelefonos.Text = "label5";
            lblTelefonos.Visible = false;
            // 
            // lblDirecciones
            // 
            lblDirecciones.AutoSize = true;
            lblDirecciones.Location = new Point(46, 184);
            lblDirecciones.Name = "lblDirecciones";
            lblDirecciones.Size = new Size(38, 15);
            lblDirecciones.TabIndex = 42;
            lblDirecciones.Text = "label5";
            lblDirecciones.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 21);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 41;
            label3.Text = "Documento:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(37, 109);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 40;
            label6.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 66);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 40;
            label4.Text = "Apellido:";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(135, 15);
            txtDocumento.MaxLength = 8;
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(148, 23);
            txtDocumento.TabIndex = 30;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(135, 60);
            txtApellido.MaxLength = 50;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(412, 23);
            txtApellido.TabIndex = 31;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(135, 103);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(412, 23);
            txtNombre.TabIndex = 31;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvDirecciones);
            tabPage2.Controls.Add(btnEditarDireccion);
            tabPage2.Controls.Add(btnBorrarDireccion);
            tabPage2.Controls.Add(btnAgregarDireccion);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(926, 387);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Direcciones";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvDirecciones
            // 
            dgvDirecciones.AllowUserToAddRows = false;
            dgvDirecciones.AllowUserToDeleteRows = false;
            dgvDirecciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDirecciones.Columns.AddRange(new DataGridViewColumn[] { colId, colDireccion });
            dgvDirecciones.Location = new Point(3, 3);
            dgvDirecciones.MultiSelect = false;
            dgvDirecciones.Name = "dgvDirecciones";
            dgvDirecciones.ReadOnly = true;
            dgvDirecciones.RowHeadersVisible = false;
            dgvDirecciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDirecciones.Size = new Size(920, 278);
            dgvDirecciones.TabIndex = 0;
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colDireccion
            // 
            colDireccion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDireccion.HeaderText = "Dirección";
            colDireccion.Name = "colDireccion";
            colDireccion.ReadOnly = true;
            // 
            // btnEditarDireccion
            // 
            btnEditarDireccion.Image = Properties.Resources.edit_28px1;
            btnEditarDireccion.Location = new Point(269, 301);
            btnEditarDireccion.Name = "btnEditarDireccion";
            btnEditarDireccion.Size = new Size(119, 54);
            btnEditarDireccion.TabIndex = 35;
            btnEditarDireccion.Text = "Editar";
            btnEditarDireccion.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEditarDireccion.UseVisualStyleBackColor = true;
            // 
            // btnBorrarDireccion
            // 
            btnBorrarDireccion.Image = Properties.Resources.delete_sign_28px;
            btnBorrarDireccion.Location = new Point(144, 301);
            btnBorrarDireccion.Name = "btnBorrarDireccion";
            btnBorrarDireccion.Size = new Size(119, 54);
            btnBorrarDireccion.TabIndex = 35;
            btnBorrarDireccion.Text = "Borrar";
            btnBorrarDireccion.TextImageRelation = TextImageRelation.ImageAboveText;
            btnBorrarDireccion.UseVisualStyleBackColor = true;
            btnBorrarDireccion.Click += btnBorrarDireccion_Click;
            // 
            // btnAgregarDireccion
            // 
            btnAgregarDireccion.Image = Properties.Resources.add_28px;
            btnAgregarDireccion.Location = new Point(19, 301);
            btnAgregarDireccion.Name = "btnAgregarDireccion";
            btnAgregarDireccion.Size = new Size(119, 54);
            btnAgregarDireccion.TabIndex = 35;
            btnAgregarDireccion.Text = "Agregar";
            btnAgregarDireccion.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAgregarDireccion.UseVisualStyleBackColor = true;
            btnAgregarDireccion.Click += btnAgregarDireccion_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(splitContainer1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(926, 387);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Teléfonos";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvTelefonos);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnEditarTelefono);
            splitContainer1.Panel2.Controls.Add(btnBorrarTelefono);
            splitContainer1.Panel2.Controls.Add(btnAgregarTelefono);
            splitContainer1.Size = new Size(920, 381);
            splitContainer1.SplitterDistance = 247;
            splitContainer1.TabIndex = 0;
            // 
            // dgvTelefonos
            // 
            dgvTelefonos.AllowUserToAddRows = false;
            dgvTelefonos.AllowUserToDeleteRows = false;
            dgvTelefonos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTelefonos.Columns.AddRange(new DataGridViewColumn[] { colTelId, colTelefono });
            dgvTelefonos.Dock = DockStyle.Fill;
            dgvTelefonos.Location = new Point(0, 0);
            dgvTelefonos.MultiSelect = false;
            dgvTelefonos.Name = "dgvTelefonos";
            dgvTelefonos.ReadOnly = true;
            dgvTelefonos.RowHeadersVisible = false;
            dgvTelefonos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTelefonos.Size = new Size(920, 247);
            dgvTelefonos.TabIndex = 1;
            // 
            // colTelId
            // 
            colTelId.HeaderText = "Id";
            colTelId.Name = "colTelId";
            colTelId.ReadOnly = true;
            colTelId.Visible = false;
            // 
            // colTelefono
            // 
            colTelefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTelefono.HeaderText = "Teléfono";
            colTelefono.Name = "colTelefono";
            colTelefono.ReadOnly = true;
            // 
            // btnEditarTelefono
            // 
            btnEditarTelefono.Image = Properties.Resources.edit_28px1;
            btnEditarTelefono.Location = new Point(271, 37);
            btnEditarTelefono.Name = "btnEditarTelefono";
            btnEditarTelefono.Size = new Size(119, 54);
            btnEditarTelefono.TabIndex = 36;
            btnEditarTelefono.Text = "Editar";
            btnEditarTelefono.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEditarTelefono.UseVisualStyleBackColor = true;
            // 
            // btnBorrarTelefono
            // 
            btnBorrarTelefono.Image = Properties.Resources.delete_sign_28px;
            btnBorrarTelefono.Location = new Point(146, 37);
            btnBorrarTelefono.Name = "btnBorrarTelefono";
            btnBorrarTelefono.Size = new Size(119, 54);
            btnBorrarTelefono.TabIndex = 37;
            btnBorrarTelefono.Text = "Borrar";
            btnBorrarTelefono.TextImageRelation = TextImageRelation.ImageAboveText;
            btnBorrarTelefono.UseVisualStyleBackColor = true;
            // 
            // btnAgregarTelefono
            // 
            btnAgregarTelefono.Image = Properties.Resources.add_28px;
            btnAgregarTelefono.Location = new Point(21, 37);
            btnAgregarTelefono.Name = "btnAgregarTelefono";
            btnAgregarTelefono.Size = new Size(119, 54);
            btnAgregarTelefono.TabIndex = 38;
            btnAgregarTelefono.Text = "Agregar";
            btnAgregarTelefono.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAgregarTelefono.UseVisualStyleBackColor = true;
            btnAgregarTelefono.Click += btnAgregarTelefono_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmClientesAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 566);
            Controls.Add(tabCliente);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Name = "frmClientesAE";
            Text = "frmClientesAE";
            tabCliente.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDirecciones).EndInit();
            tabPage3.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTelefonos).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnCancelar;
        private Button btnOk;
        private TabControl tabCliente;
        private TabPage tabPage1;
        private Label lblTelefonos;
        private Label lblDirecciones;
        private Label label3;
        private Label label6;
        private Label label4;
        private TextBox txtDocumento;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private TabPage tabPage2;
        private DataGridView dgvDirecciones;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDireccion;
        private Button btnEditarDireccion;
        private Button btnBorrarDireccion;
        private Button btnAgregarDireccion;
        private TabPage tabPage3;
        private SplitContainer splitContainer1;
        private DataGridView dgvTelefonos;
        private DataGridViewTextBoxColumn colTelId;
        private DataGridViewTextBoxColumn colTelefono;
        private Button btnEditarTelefono;
        private Button btnBorrarTelefono;
        private Button btnAgregarTelefono;
        private ErrorProvider errorProvider1;
    }
}