namespace Bombones.Windows.Formularios
{
    partial class frmFabricasAE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFabricasAE));
            label3 = new Label();
            cboProvinciasEstados = new ComboBox();
            cboPaises = new ComboBox();
            label2 = new Label();
            btnCancelar = new Button();
            btnOk = new Button();
            txtFabrica = new TextBox();
            label1 = new Label();
            txtDireccion = new TextBox();
            label4 = new Label();
            label5 = new Label();
            cboCiudades = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 42);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 29;
            label3.Text = "Fábrica:";
            // 
            // cboProvinciasEstados
            // 
            cboProvinciasEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProvinciasEstados.FormattingEnabled = true;
            cboProvinciasEstados.Location = new Point(145, 174);
            cboProvinciasEstados.Name = "cboProvinciasEstados";
            cboProvinciasEstados.Size = new Size(315, 23);
            cboProvinciasEstados.TabIndex = 3;
            cboProvinciasEstados.SelectedIndexChanged += cboProvinciasEstados_SelectedIndexChanged;
            // 
            // cboPaises
            // 
            cboPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaises.FormattingEnabled = true;
            cboPaises.Location = new Point(145, 130);
            cboPaises.Name = "cboPaises";
            cboPaises.Size = new Size(315, 23);
            cboPaises.TabIndex = 2;
            cboPaises.SelectedIndexChanged += cboPaises_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 133);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 26;
            label2.Text = "País:";
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(452, 274);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(40, 274);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(289, 54);
            btnOk.TabIndex = 5;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // txtFabrica
            // 
            txtFabrica.Location = new Point(145, 39);
            txtFabrica.MaxLength = 50;
            txtFabrica.Name = "txtFabrica";
            txtFabrica.Size = new Size(412, 23);
            txtFabrica.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 177);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 22;
            label1.Text = "Provincia/Estado:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(145, 84);
            txtDireccion.MaxLength = 50;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(412, 23);
            txtDireccion.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 87);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 29;
            label4.Text = "Dirección:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 220);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 22;
            label5.Text = "Ciudad:";
            // 
            // cboCiudades
            // 
            cboCiudades.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCiudades.FormattingEnabled = true;
            cboCiudades.Location = new Point(145, 217);
            cboCiudades.Name = "cboCiudades";
            cboCiudades.Size = new Size(315, 23);
            cboCiudades.TabIndex = 4;
            cboCiudades.SelectedIndexChanged += cboCiudades_SelectedIndexChanged;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmFabricasAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(637, 357);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cboCiudades);
            Controls.Add(cboProvinciasEstados);
            Controls.Add(cboPaises);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(txtDireccion);
            Controls.Add(label5);
            Controls.Add(txtFabrica);
            Controls.Add(label1);
            Name = "frmFabricasAE";
            Text = "frmFabricasAE";
            Load += frmFabricasAE_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private ComboBox cboProvinciasEstados;
        private ComboBox cboPaises;
        private Label label2;
        private Button btnCancelar;
        private Button btnOk;
        private TextBox txtFabrica;
        private Label label1;
        private TextBox txtDireccion;
        private Label label4;
        private Label label5;
        private ComboBox cboCiudades;
        private ErrorProvider errorProvider1;
    }
}