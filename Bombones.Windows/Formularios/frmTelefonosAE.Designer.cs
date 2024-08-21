namespace Bombones.Windows.Formularios
{
    partial class frmTelefonosAE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelefonosAE));
            cboTipoTelefono = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            txtTelefono = new TextBox();
            btnCancelar = new Button();
            btnOk = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cboTipoTelefono
            // 
            cboTipoTelefono.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoTelefono.FormattingEnabled = true;
            cboTipoTelefono.Location = new Point(173, 33);
            cboTipoTelefono.Name = "cboTipoTelefono";
            cboTipoTelefono.Size = new Size(311, 23);
            cboTipoTelefono.TabIndex = 55;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 36);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 56;
            label2.Text = "Tipo Teléfono:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 77);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 58;
            label1.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(173, 74);
            txtTelefono.MaxLength = 20;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(311, 23);
            txtTelefono.TabIndex = 57;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(445, 122);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 60;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(33, 122);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(289, 54);
            btnOk.TabIndex = 59;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmTelefonosAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 202);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(label1);
            Controls.Add(txtTelefono);
            Controls.Add(cboTipoTelefono);
            Controls.Add(label2);
            Name = "frmTelefonosAE";
            Text = "frmTelefonosAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboTipoTelefono;
        private Label label2;
        private Label label1;
        private TextBox txtTelefono;
        private Button btnCancelar;
        private Button btnOk;
        private ErrorProvider errorProvider1;
    }
}