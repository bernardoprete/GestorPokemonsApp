namespace winform_app
{
    partial class frmPokemons
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbxPokemon = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvPokemons = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminarFisico = new System.Windows.Forms.Button();
            this.btnEliminarLogico = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.lblCampo = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblFiltroAvanzado = new System.Windows.Forms.Label();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.txtFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.btnRecargarBusqueda = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPokemon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPokemons)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxPokemon
            // 
            this.pbxPokemon.Location = new System.Drawing.Point(780, 51);
            this.pbxPokemon.Name = "pbxPokemon";
            this.pbxPokemon.Size = new System.Drawing.Size(262, 305);
            this.pbxPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPokemon.TabIndex = 1;
            this.pbxPokemon.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 399);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 28);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvPokemons
            // 
            this.dgvPokemons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPokemons.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPokemons.Location = new System.Drawing.Point(12, 51);
            this.dgvPokemons.MultiSelect = false;
            this.dgvPokemons.Name = "dgvPokemons";
            this.dgvPokemons.RowHeadersWidth = 51;
            this.dgvPokemons.RowTemplate.Height = 24;
            this.dgvPokemons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPokemons.Size = new System.Drawing.Size(740, 305);
            this.dgvPokemons.TabIndex = 0;
            this.dgvPokemons.SelectionChanged += new System.EventHandler(this.dgvPokemons_SelectionChanged);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(118, 399);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 28);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminarFisico
            // 
            this.btnEliminarFisico.Location = new System.Drawing.Point(224, 399);
            this.btnEliminarFisico.Name = "btnEliminarFisico";
            this.btnEliminarFisico.Size = new System.Drawing.Size(125, 28);
            this.btnEliminarFisico.TabIndex = 4;
            this.btnEliminarFisico.Text = "Eliminar Físico";
            this.btnEliminarFisico.UseVisualStyleBackColor = true;
            this.btnEliminarFisico.Click += new System.EventHandler(this.btnEliminarFisico_Click);
            // 
            // btnEliminarLogico
            // 
            this.btnEliminarLogico.Location = new System.Drawing.Point(355, 399);
            this.btnEliminarLogico.Name = "btnEliminarLogico";
            this.btnEliminarLogico.Size = new System.Drawing.Size(125, 28);
            this.btnEliminarLogico.TabIndex = 5;
            this.btnEliminarLogico.Text = "Eliminar Lógico";
            this.btnEliminarLogico.UseVisualStyleBackColor = true;
            this.btnEliminarLogico.Click += new System.EventHandler(this.btnEliminarLogico_Click);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(9, 20);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(84, 16);
            this.lblFiltro.TabIndex = 6;
            this.lblFiltro.Text = "Filtro Rapido";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(110, 14);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(190, 22);
            this.txtFiltro.TabIndex = 7;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(732, 475);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(69, 28);
            this.btnFiltro.TabIndex = 8;
            this.btnFiltro.Text = "Buscar";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(13, 483);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(51, 16);
            this.lblCampo.TabIndex = 9;
            this.lblCampo.Text = "Campo";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(234, 483);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(49, 16);
            this.lblCriterio.TabIndex = 10;
            this.lblCriterio.Text = "Criterio";
            // 
            // lblFiltroAvanzado
            // 
            this.lblFiltroAvanzado.AutoSize = true;
            this.lblFiltroAvanzado.Location = new System.Drawing.Point(476, 483);
            this.lblFiltroAvanzado.Name = "lblFiltroAvanzado";
            this.lblFiltroAvanzado.Size = new System.Drawing.Size(36, 16);
            this.lblFiltroAvanzado.TabIndex = 11;
            this.lblFiltroAvanzado.Text = "Filtro";
            // 
            // cboCampo
            // 
            this.cboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(82, 475);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(121, 24);
            this.cboCampo.TabIndex = 12;
            this.cboCampo.SelectedIndexChanged += new System.EventHandler(this.cboCampo_SelectedIndexChanged);
            // 
            // cboCriterio
            // 
            this.cboCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(304, 475);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(121, 24);
            this.cboCriterio.TabIndex = 13;
            // 
            // txtFiltroAvanzado
            // 
            this.txtFiltroAvanzado.Location = new System.Drawing.Point(551, 477);
            this.txtFiltroAvanzado.Name = "txtFiltroAvanzado";
            this.txtFiltroAvanzado.Size = new System.Drawing.Size(143, 22);
            this.txtFiltroAvanzado.TabIndex = 14;
            // 
            // btnRecargarBusqueda
            // 
            this.btnRecargarBusqueda.Location = new System.Drawing.Point(817, 476);
            this.btnRecargarBusqueda.Name = "btnRecargarBusqueda";
            this.btnRecargarBusqueda.Size = new System.Drawing.Size(110, 27);
            this.btnRecargarBusqueda.TabIndex = 15;
            this.btnRecargarBusqueda.Text = "Recargar";
            this.btnRecargarBusqueda.UseVisualStyleBackColor = true;
            this.btnRecargarBusqueda.Click += new System.EventHandler(this.btnRecargarBusqueda_Click);
            // 
            // frmPokemons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 595);
            this.Controls.Add(this.btnRecargarBusqueda);
            this.Controls.Add(this.txtFiltroAvanzado);
            this.Controls.Add(this.cboCriterio);
            this.Controls.Add(this.cboCampo);
            this.Controls.Add(this.lblFiltroAvanzado);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.btnEliminarLogico);
            this.Controls.Add(this.btnEliminarFisico);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pbxPokemon);
            this.Controls.Add(this.dgvPokemons);
            this.Name = "frmPokemons";
            this.Text = "form";
            this.Load += new System.EventHandler(this.frmPokemons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPokemon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPokemons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxPokemon;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvPokemons;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminarFisico;
        private System.Windows.Forms.Button btnEliminarLogico;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Label lblFiltroAvanzado;
        private System.Windows.Forms.ComboBox cboCampo;
        private System.Windows.Forms.ComboBox cboCriterio;
        private System.Windows.Forms.TextBox txtFiltroAvanzado;
        private System.Windows.Forms.Button btnRecargarBusqueda;
    }
}

