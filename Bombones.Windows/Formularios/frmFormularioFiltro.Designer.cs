namespace Bombones.Windows.Formularios
{
    partial class frmFormularioFiltro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormularioFiltro));
            cboCiudades = new ComboBox();
            cboProvinciasEstados = new ComboBox();
            cboPaises = new ComboBox();
            label2 = new Label();
            btnCancelar = new Button();
            btnOk = new Button();
            lblCiudad = new Label();
            lblEstado = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cboCiudades
            // 
            cboCiudades.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCiudades.FormattingEnabled = true;
            cboCiudades.Location = new Point(142, 125);
            cboCiudades.Name = "cboCiudades";
            cboCiudades.Size = new Size(315, 23);
            cboCiudades.TabIndex = 34;
            // 
            // cboProvinciasEstados
            // 
            cboProvinciasEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProvinciasEstados.FormattingEnabled = true;
            cboProvinciasEstados.Location = new Point(142, 82);
            cboProvinciasEstados.Name = "cboProvinciasEstados";
            cboProvinciasEstados.Size = new Size(315, 23);
            cboProvinciasEstados.TabIndex = 35;
            // 
            // cboPaises
            // 
            cboPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaises.FormattingEnabled = true;
            cboPaises.Location = new Point(142, 38);
            cboPaises.Name = "cboPaises";
            cboPaises.Size = new Size(315, 23);
            cboPaises.TabIndex = 36;
            cboPaises.SelectedIndexChanged += cboPaises_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 41);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 33;
            label2.Text = "País:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom;
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(449, 182);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 31;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom;
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(37, 182);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(289, 54);
            btnOk.TabIndex = 32;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Location = new Point(37, 128);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(48, 15);
            lblCiudad.TabIndex = 29;
            lblCiudad.Text = "Ciudad:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(37, 85);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(99, 15);
            lblEstado.TabIndex = 30;
            lblEstado.Text = "Provincia/Estado:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmFormularioFiltro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 261);
            Controls.Add(cboCiudades);
            Controls.Add(cboProvinciasEstados);
            Controls.Add(cboPaises);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(lblCiudad);
            Controls.Add(lblEstado);
            MaximumSize = new Size(620, 300);
            Name = "frmFormularioFiltro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Seleccionar";
            Load += frmFormularioFiltro_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboCiudades;
        private ComboBox cboProvinciasEstados;
        private ComboBox cboPaises;
        private Label label2;
        private Button btnCancelar;
        private Button btnOk;
        private Label lblCiudad;
        private Label lblEstado;
        private ErrorProvider errorProvider1;
    }
}