namespace Cestovni_nahrady
{
    partial class UvodniStranka
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonNastaveni = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonSpocitaneCesty = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonZpet = new System.Windows.Forms.Button();
            this.buttonDalsi = new System.Windows.Forms.Button();
            this.panelNavigacniBtny = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelNavigacniBtny.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNastaveni
            // 
            this.buttonNastaveni.Location = new System.Drawing.Point(49, 135);
            this.buttonNastaveni.Name = "buttonNastaveni";
            this.buttonNastaveni.Size = new System.Drawing.Size(155, 23);
            this.buttonNastaveni.TabIndex = 17;
            this.buttonNastaveni.Text = "Nastavení";
            this.buttonNastaveni.UseVisualStyleBackColor = true;
            this.buttonNastaveni.Click += new System.EventHandler(this.buttonNastaveni_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(49, 31);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(155, 23);
            this.buttonStart.TabIndex = 40;
            this.buttonStart.Text = "Nový výpočet";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonSpocitaneCesty
            // 
            this.buttonSpocitaneCesty.Location = new System.Drawing.Point(49, 84);
            this.buttonSpocitaneCesty.Name = "buttonSpocitaneCesty";
            this.buttonSpocitaneCesty.Size = new System.Drawing.Size(155, 23);
            this.buttonSpocitaneCesty.TabIndex = 41;
            this.buttonSpocitaneCesty.Text = "Spočítané cesty";
            this.buttonSpocitaneCesty.UseVisualStyleBackColor = true;
            this.buttonSpocitaneCesty.Click += new System.EventHandler(this.buttonSpocitaneCesty_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.buttonStart);
            this.panelMenu.Controls.Add(this.buttonNastaveni);
            this.panelMenu.Controls.Add(this.buttonSpocitaneCesty);
            this.panelMenu.Location = new System.Drawing.Point(172, 122);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 201);
            this.panelMenu.TabIndex = 42;
            // 
            // buttonZpet
            // 
            this.buttonZpet.Location = new System.Drawing.Point(3, 3);
            this.buttonZpet.Name = "buttonZpet";
            this.buttonZpet.Size = new System.Drawing.Size(75, 23);
            this.buttonZpet.TabIndex = 43;
            this.buttonZpet.Text = "Zpět";
            this.buttonZpet.UseVisualStyleBackColor = true;
            this.buttonZpet.Click += new System.EventHandler(this.buttonZpet_Click);
            // 
            // buttonDalsi
            // 
            this.buttonDalsi.Location = new System.Drawing.Point(502, 3);
            this.buttonDalsi.Name = "buttonDalsi";
            this.buttonDalsi.Size = new System.Drawing.Size(75, 23);
            this.buttonDalsi.TabIndex = 44;
            this.buttonDalsi.Text = "Další";
            this.buttonDalsi.UseVisualStyleBackColor = true;
            this.buttonDalsi.Click += new System.EventHandler(this.buttonDalsi_Click);
            // 
            // panelNavigacniBtny
            // 
            this.panelNavigacniBtny.Controls.Add(this.buttonDalsi);
            this.panelNavigacniBtny.Controls.Add(this.buttonZpet);
            this.panelNavigacniBtny.Location = new System.Drawing.Point(12, 395);
            this.panelNavigacniBtny.Name = "panelNavigacniBtny";
            this.panelNavigacniBtny.Size = new System.Drawing.Size(577, 30);
            this.panelNavigacniBtny.TabIndex = 45;
            // 
            // UvodniStranka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(601, 437);
            this.Controls.Add(this.panelNavigacniBtny);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UvodniStranka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cestovní náhrady";
            this.panelMenu.ResumeLayout(false);
            this.panelNavigacniBtny.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonNastaveni;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonSpocitaneCesty;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonZpet;
        private System.Windows.Forms.Button buttonDalsi;
        private System.Windows.Forms.Panel panelNavigacniBtny;
    }
}

