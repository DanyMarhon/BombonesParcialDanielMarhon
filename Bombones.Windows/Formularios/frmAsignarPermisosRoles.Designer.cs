namespace Bombones.Windows.Formularios
{
    partial class frmAsignarPermisosRoles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignarPermisosRoles));
            splitContainer1 = new SplitContainer();
            label1 = new Label();
            cboRoles = new ComboBox();
            panel1 = new Panel();
            panel2 = new Panel();
            btnAsignar = new Button();
            btnQuitarPermiso = new Button();
            dataGridView1 = new DataGridView();
            colSeleccionado = new DataGridViewCheckBoxColumn();
            colPermiso = new DataGridViewCheckBoxColumn();
            dataGridView2 = new DataGridView();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
            btnCancelar = new Button();
            btnOk = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(cboRoles);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnCancelar);
            splitContainer1.Panel2.Controls.Add(btnOk);
            splitContainer1.Panel2.Controls.Add(btnQuitarPermiso);
            splitContainer1.Panel2.Controls.Add(btnAsignar);
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(867, 641);
            splitContainer1.SplitterDistance = 106;
            splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 34);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 0;
            label1.Text = "Rol:";
            // 
            // cboRoles
            // 
            cboRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoles.FormattingEnabled = true;
            cboRoles.Location = new Point(58, 31);
            cboRoles.Name = "cboRoles";
            cboRoles.Size = new Size(232, 23);
            cboRoles.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(9, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(340, 412);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView2);
            panel2.Location = new Point(515, 8);
            panel2.Name = "panel2";
            panel2.Size = new Size(340, 412);
            panel2.TabIndex = 0;
            // 
            // btnAsignar
            // 
            btnAsignar.Image = Properties.Resources.arrow_20px;
            btnAsignar.Location = new Point(395, 99);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(75, 47);
            btnAsignar.TabIndex = 1;
            btnAsignar.Text = "Asignar";
            btnAsignar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAsignar.UseVisualStyleBackColor = true;
            // 
            // btnQuitarPermiso
            // 
            btnQuitarPermiso.Image = Properties.Resources.arrow_pointing_left_20px;
            btnQuitarPermiso.Location = new Point(395, 167);
            btnQuitarPermiso.Name = "btnQuitarPermiso";
            btnQuitarPermiso.Size = new Size(75, 47);
            btnQuitarPermiso.TabIndex = 1;
            btnQuitarPermiso.Text = "Quitar";
            btnQuitarPermiso.TextImageRelation = TextImageRelation.ImageAboveText;
            btnQuitarPermiso.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colSeleccionado, colPermiso });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(340, 412);
            dataGridView1.TabIndex = 0;
            // 
            // colSeleccionado
            // 
            colSeleccionado.HeaderText = "Seleccionar";
            colSeleccionado.Name = "colSeleccionado";
            colSeleccionado.ReadOnly = true;
            // 
            // colPermiso
            // 
            colPermiso.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPermiso.HeaderText = "Permiso";
            colPermiso.Name = "colPermiso";
            colPermiso.ReadOnly = true;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewCheckBoxColumn1, dataGridViewCheckBoxColumn2 });
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.Size = new Size(340, 412);
            dataGridView2.TabIndex = 1;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.HeaderText = "Seleccionar";
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            dataGridViewCheckBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCheckBoxColumn2.HeaderText = "Permiso";
            dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            dataGridViewCheckBoxColumn2.ReadOnly = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(529, 452);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(214, 452);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(289, 54);
            btnOk.TabIndex = 14;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            // 
            // frmAsignarPermisosRoles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 641);
            Controls.Add(splitContainer1);
            Name = "frmAsignarPermisosRoles";
            Text = "frmAsignarPermisosRoles";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ComboBox cboRoles;
        private Label label1;
        private Button btnQuitarPermiso;
        private Button btnAsignar;
        private Panel panel2;
        private Panel panel1;
        private DataGridView dataGridView1;
        private DataGridViewCheckBoxColumn colSeleccionado;
        private DataGridViewCheckBoxColumn colPermiso;
        private DataGridView dataGridView2;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private Button btnCancelar;
        private Button btnOk;
    }
}