namespace Bombones.Windows.Formularios
{
    partial class frmDireccionAE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDireccionAE));
            label6 = new Label();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            cboCiudades = new ComboBox();
            txtCalle = new TextBox();
            cboProvinciasEstados = new ComboBox();
            txtCodPostal = new TextBox();
            cboPaises = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            cboTipoDireccion = new ComboBox();
            txtAltura = new TextBox();
            label7 = new Label();
            txtEntre1 = new TextBox();
            label8 = new Label();
            txtEntre2 = new TextBox();
            label9 = new Label();
            txtPiso = new TextBox();
            label10 = new Label();
            txtDepto = new TextBox();
            label11 = new Label();
            btnCancelar = new Button();
            btnOk = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(492, 250);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 49;
            label6.Text = "Cod, Postal:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 207);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 47;
            label1.Text = "Provincia/Estado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 66);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 50;
            label4.Text = "Calle:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 250);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 46;
            label5.Text = "Ciudad:";
            // 
            // cboCiudades
            // 
            cboCiudades.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCiudades.FormattingEnabled = true;
            cboCiudades.Location = new Point(148, 247);
            cboCiudades.Name = "cboCiudades";
            cboCiudades.Size = new Size(315, 23);
            cboCiudades.TabIndex = 45;
            cboCiudades.SelectedIndexChanged += cboCiudades_SelectedIndexChanged;
            // 
            // txtCalle
            // 
            txtCalle.Location = new Point(148, 63);
            txtCalle.MaxLength = 50;
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(412, 23);
            txtCalle.TabIndex = 41;
            // 
            // cboProvinciasEstados
            // 
            cboProvinciasEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProvinciasEstados.FormattingEnabled = true;
            cboProvinciasEstados.Location = new Point(148, 204);
            cboProvinciasEstados.Name = "cboProvinciasEstados";
            cboProvinciasEstados.Size = new Size(315, 23);
            cboProvinciasEstados.TabIndex = 44;
            cboProvinciasEstados.SelectedIndexChanged += cboProvinciasEstados_SelectedIndexChanged;
            // 
            // txtCodPostal
            // 
            txtCodPostal.Location = new Point(581, 247);
            txtCodPostal.MaxLength = 50;
            txtCodPostal.Name = "txtCodPostal";
            txtCodPostal.Size = new Size(207, 23);
            txtCodPostal.TabIndex = 42;
            // 
            // cboPaises
            // 
            cboPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaises.FormattingEnabled = true;
            cboPaises.Location = new Point(148, 160);
            cboPaises.Name = "cboPaises";
            cboPaises.Size = new Size(315, 23);
            cboPaises.TabIndex = 43;
            cboPaises.SelectedIndexChanged += cboPaises_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 163);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 48;
            label2.Text = "País:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 26);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 48;
            label3.Text = "Tipo Dirección:";
            // 
            // cboTipoDireccion
            // 
            cboTipoDireccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoDireccion.FormattingEnabled = true;
            cboTipoDireccion.Location = new Point(148, 23);
            cboTipoDireccion.Name = "cboTipoDireccion";
            cboTipoDireccion.Size = new Size(315, 23);
            cboTipoDireccion.TabIndex = 43;
            // 
            // txtAltura
            // 
            txtAltura.Location = new Point(626, 63);
            txtAltura.MaxLength = 50;
            txtAltura.Name = "txtAltura";
            txtAltura.Size = new Size(144, 23);
            txtAltura.TabIndex = 41;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(574, 66);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 50;
            label7.Text = "Altura:";
            // 
            // txtEntre1
            // 
            txtEntre1.Location = new Point(148, 92);
            txtEntre1.MaxLength = 50;
            txtEntre1.Name = "txtEntre1";
            txtEntre1.Size = new Size(412, 23);
            txtEntre1.TabIndex = 41;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(47, 95);
            label8.Name = "label8";
            label8.Size = new Size(34, 15);
            label8.TabIndex = 50;
            label8.Text = "Entre";
            // 
            // txtEntre2
            // 
            txtEntre2.Location = new Point(148, 121);
            txtEntre2.MaxLength = 50;
            txtEntre2.Name = "txtEntre2";
            txtEntre2.Size = new Size(412, 23);
            txtEntre2.TabIndex = 41;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(47, 124);
            label9.Name = "label9";
            label9.Size = new Size(17, 15);
            label9.TabIndex = 50;
            label9.Text = "Y:";
            // 
            // txtPiso
            // 
            txtPiso.Location = new Point(148, 310);
            txtPiso.MaxLength = 50;
            txtPiso.Name = "txtPiso";
            txtPiso.Size = new Size(129, 23);
            txtPiso.TabIndex = 42;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(59, 313);
            label10.Name = "label10";
            label10.Size = new Size(32, 15);
            label10.TabIndex = 49;
            label10.Text = "Piso:";
            // 
            // txtDepto
            // 
            txtDepto.Location = new Point(396, 310);
            txtDepto.MaxLength = 50;
            txtDepto.Name = "txtDepto";
            txtDepto.Size = new Size(129, 23);
            txtDepto.TabIndex = 42;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(307, 313);
            label11.Name = "label11";
            label11.Size = new Size(42, 15);
            label11.TabIndex = 49;
            label11.Text = "Depto:";
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(537, 367);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 52;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(125, 367);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(289, 54);
            btnOk.TabIndex = 51;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmDireccionAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(cboCiudades);
            Controls.Add(txtAltura);
            Controls.Add(txtEntre2);
            Controls.Add(txtEntre1);
            Controls.Add(txtCalle);
            Controls.Add(cboProvinciasEstados);
            Controls.Add(txtDepto);
            Controls.Add(txtPiso);
            Controls.Add(txtCodPostal);
            Controls.Add(cboTipoDireccion);
            Controls.Add(label3);
            Controls.Add(cboPaises);
            Controls.Add(label2);
            Name = "frmDireccionAE";
            Text = "frmDireccionAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label1;
        private Label label4;
        private Label label5;
        private ComboBox cboCiudades;
        private TextBox txtCalle;
        private ComboBox cboProvinciasEstados;
        private TextBox txtCodPostal;
        private ComboBox cboPaises;
        private Label label2;
        private Label label3;
        private ComboBox cboTipoDireccion;
        private TextBox txtAltura;
        private Label label7;
        private TextBox txtEntre1;
        private Label label8;
        private TextBox txtEntre2;
        private Label label9;
        private TextBox txtPiso;
        private Label label10;
        private TextBox txtDepto;
        private Label label11;
        private Button btnCancelar;
        private Button btnOk;
        private ErrorProvider errorProvider1;
    }
}