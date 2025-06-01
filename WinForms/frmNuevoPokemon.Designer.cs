namespace ADO_POKEMONS_EJEMPLO
{
    partial class frmNuevoPokemon
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
            this.lblNombrePoke = new System.Windows.Forms.Label();
            this.lblNumeroPoke = new System.Windows.Forms.Label();
            this.lblDescPoke = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblDebilidad = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.cboDebilidad = new System.Windows.Forms.ComboBox();
            this.lblUrlImagen = new System.Windows.Forms.Label();
            this.txtUrlImagenAlta = new System.Windows.Forms.TextBox();
            this.pbxAlta = new System.Windows.Forms.PictureBox();
            this.btnAgregarImagenLocal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombrePoke
            // 
            this.lblNombrePoke.AutoSize = true;
            this.lblNombrePoke.Location = new System.Drawing.Point(41, 61);
            this.lblNombrePoke.Name = "lblNombrePoke";
            this.lblNombrePoke.Size = new System.Drawing.Size(47, 13);
            this.lblNombrePoke.TabIndex = 0;
            this.lblNombrePoke.Text = "Nombre:";
            // 
            // lblNumeroPoke
            // 
            this.lblNumeroPoke.AutoSize = true;
            this.lblNumeroPoke.Location = new System.Drawing.Point(41, 35);
            this.lblNumeroPoke.Name = "lblNumeroPoke";
            this.lblNumeroPoke.Size = new System.Drawing.Size(47, 13);
            this.lblNumeroPoke.TabIndex = 0;
            this.lblNumeroPoke.Text = "Numero:";
            // 
            // lblDescPoke
            // 
            this.lblDescPoke.AutoSize = true;
            this.lblDescPoke.Location = new System.Drawing.Point(22, 87);
            this.lblDescPoke.Name = "lblDescPoke";
            this.lblDescPoke.Size = new System.Drawing.Size(66, 13);
            this.lblDescPoke.TabIndex = 0;
            this.lblDescPoke.Text = "Descripción:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(94, 28);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(133, 20);
            this.txtNumero.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(94, 54);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(133, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(94, 80);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(133, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(57, 204);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(79, 24);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(148, 204);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 24);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(54, 139);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(34, 13);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo: ";
            // 
            // lblDebilidad
            // 
            this.lblDebilidad.AutoSize = true;
            this.lblDebilidad.Location = new System.Drawing.Point(34, 165);
            this.lblDebilidad.Name = "lblDebilidad";
            this.lblDebilidad.Size = new System.Drawing.Size(54, 13);
            this.lblDebilidad.TabIndex = 0;
            this.lblDebilidad.Text = "Debilidad:";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(94, 132);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(133, 21);
            this.cboTipo.TabIndex = 4;
            // 
            // cboDebilidad
            // 
            this.cboDebilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDebilidad.FormattingEnabled = true;
            this.cboDebilidad.Location = new System.Drawing.Point(94, 159);
            this.cboDebilidad.Name = "cboDebilidad";
            this.cboDebilidad.Size = new System.Drawing.Size(133, 21);
            this.cboDebilidad.TabIndex = 5;
            // 
            // lblUrlImagen
            // 
            this.lblUrlImagen.AutoSize = true;
            this.lblUrlImagen.Location = new System.Drawing.Point(27, 113);
            this.lblUrlImagen.Name = "lblUrlImagen";
            this.lblUrlImagen.Size = new System.Drawing.Size(61, 13);
            this.lblUrlImagen.TabIndex = 0;
            this.lblUrlImagen.Text = "Url Imagen:";
            // 
            // txtUrlImagenAlta
            // 
            this.txtUrlImagenAlta.Location = new System.Drawing.Point(94, 106);
            this.txtUrlImagenAlta.Name = "txtUrlImagenAlta";
            this.txtUrlImagenAlta.Size = new System.Drawing.Size(133, 20);
            this.txtUrlImagenAlta.TabIndex = 3;
            this.txtUrlImagenAlta.Leave += new System.EventHandler(this.txtUrlImagen_Leave);
            // 
            // pbxAlta
            // 
            this.pbxAlta.Location = new System.Drawing.Point(282, 28);
            this.pbxAlta.Name = "pbxAlta";
            this.pbxAlta.Size = new System.Drawing.Size(235, 200);
            this.pbxAlta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAlta.TabIndex = 7;
            this.pbxAlta.TabStop = false;
            // 
            // btnAgregarImagenLocal
            // 
            this.btnAgregarImagenLocal.Location = new System.Drawing.Point(233, 100);
            this.btnAgregarImagenLocal.Name = "btnAgregarImagenLocal";
            this.btnAgregarImagenLocal.Size = new System.Drawing.Size(33, 30);
            this.btnAgregarImagenLocal.TabIndex = 8;
            this.btnAgregarImagenLocal.Text = "+";
            this.btnAgregarImagenLocal.UseVisualStyleBackColor = true;
            this.btnAgregarImagenLocal.Click += new System.EventHandler(this.btnAgregarImagenLocal_Click);
            // 
            // frmNuevoPokemon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 275);
            this.Controls.Add(this.btnAgregarImagenLocal);
            this.Controls.Add(this.pbxAlta);
            this.Controls.Add(this.cboDebilidad);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtUrlImagenAlta);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblDebilidad);
            this.Controls.Add(this.lblUrlImagen);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblDescPoke);
            this.Controls.Add(this.lblNumeroPoke);
            this.Controls.Add(this.lblNombrePoke);
            this.Name = "frmNuevoPokemon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo pokemon";
            this.Load += new System.EventHandler(this.frmNuevoPokemon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombrePoke;
        private System.Windows.Forms.Label lblNumeroPoke;
        private System.Windows.Forms.Label lblDescPoke;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblDebilidad;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.ComboBox cboDebilidad;
        private System.Windows.Forms.Label lblUrlImagen;
        private System.Windows.Forms.TextBox txtUrlImagenAlta;
        private System.Windows.Forms.PictureBox pbxAlta;
        private System.Windows.Forms.Button btnAgregarImagenLocal;
    }
}