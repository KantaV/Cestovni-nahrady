namespace Cestovni_nahrady
{
    partial class UdajePohonneHmoty
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

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxZpsbVypoctuPohHmot = new System.Windows.Forms.ComboBox();
            this.labelTypPohHmt = new System.Windows.Forms.Label();
            this.comboBoxZpusobPrepravy = new System.Windows.Forms.ComboBox();
            this.labelPrumerCena = new System.Windows.Forms.Label();
            this.textBoxPrumernaPohonneHmotyCena = new System.Windows.Forms.TextBox();
            this.comboBoxTypPohonnychHmot = new System.Windows.Forms.ComboBox();
            this.labelZpusobVypoctu = new System.Windows.Forms.Label();
            this.labelCestoval = new System.Windows.Forms.Label();
            this.labelPocetKm = new System.Windows.Forms.Label();
            this.textBoxPocetNajetychKm = new System.Windows.Forms.TextBox();
            this.labelSpotrebovano = new System.Windows.Forms.Label();
            this.numericUpDownSpotreba = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpotreba)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxZpsbVypoctuPohHmot
            // 
            this.comboBoxZpsbVypoctuPohHmot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZpsbVypoctuPohHmot.FormattingEnabled = true;
            this.comboBoxZpsbVypoctuPohHmot.Items.AddRange(new object[] {
            "Dle zákona",
            "Dle účtenky"});
            this.comboBoxZpsbVypoctuPohHmot.Location = new System.Drawing.Point(217, 95);
            this.comboBoxZpsbVypoctuPohHmot.Name = "comboBoxZpsbVypoctuPohHmot";
            this.comboBoxZpsbVypoctuPohHmot.Size = new System.Drawing.Size(121, 21);
            this.comboBoxZpsbVypoctuPohHmot.TabIndex = 55;
            this.comboBoxZpsbVypoctuPohHmot.SelectedIndexChanged += new System.EventHandler(this.comboBoxZpsbVypoctuPohHmot_SelectedIndexChanged);
            // 
            // labelTypPohHmt
            // 
            this.labelTypPohHmt.AutoSize = true;
            this.labelTypPohHmt.Location = new System.Drawing.Point(26, 189);
            this.labelTypPohHmt.Name = "labelTypPohHmt";
            this.labelTypPohHmt.Size = new System.Drawing.Size(104, 13);
            this.labelTypPohHmt.TabIndex = 59;
            this.labelTypPohHmt.Text = "Typ pohonné hmoty:";
            // 
            // comboBoxZpusobPrepravy
            // 
            this.comboBoxZpusobPrepravy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZpusobPrepravy.FormattingEnabled = true;
            this.comboBoxZpusobPrepravy.Items.AddRange(new object[] {
            "Služebním dopravním prostředkem",
            "Vlastním automobilem",
            "Vlastním automobilem s přivěsem",
            "Vlastní motorkou",
            "Vlastním nákladním vozem, autobusem, traktorem"});
            this.comboBoxZpusobPrepravy.Location = new System.Drawing.Point(83, 67);
            this.comboBoxZpusobPrepravy.Name = "comboBoxZpusobPrepravy";
            this.comboBoxZpusobPrepravy.Size = new System.Drawing.Size(255, 21);
            this.comboBoxZpusobPrepravy.TabIndex = 54;
            this.comboBoxZpusobPrepravy.SelectedIndexChanged += new System.EventHandler(this.comboBoxZpusobPrepravy_SelectedIndexChanged);
            // 
            // labelPrumerCena
            // 
            this.labelPrumerCena.AutoSize = true;
            this.labelPrumerCena.Location = new System.Drawing.Point(26, 274);
            this.labelPrumerCena.Name = "labelPrumerCena";
            this.labelPrumerCena.Size = new System.Drawing.Size(82, 13);
            this.labelPrumerCena.TabIndex = 57;
            this.labelPrumerCena.Text = "Průměrná cena:";
            // 
            // textBoxPrumernaPohonneHmotyCena
            // 
            this.textBoxPrumernaPohonneHmotyCena.Enabled = false;
            this.textBoxPrumernaPohonneHmotyCena.Location = new System.Drawing.Point(218, 271);
            this.textBoxPrumernaPohonneHmotyCena.Name = "textBoxPrumernaPohonneHmotyCena";
            this.textBoxPrumernaPohonneHmotyCena.Size = new System.Drawing.Size(120, 20);
            this.textBoxPrumernaPohonneHmotyCena.TabIndex = 56;
            this.textBoxPrumernaPohonneHmotyCena.Text = "0";
            // 
            // comboBoxTypPohonnychHmot
            // 
            this.comboBoxTypPohonnychHmot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypPohonnychHmot.FormattingEnabled = true;
            this.comboBoxTypPohonnychHmot.Items.AddRange(new object[] {
            "Natural 95",
            "Natural 98",
            "Nafta",
            "Elektřina",
            "LPG (plyn)"});
            this.comboBoxTypPohonnychHmot.Location = new System.Drawing.Point(217, 186);
            this.comboBoxTypPohonnychHmot.Name = "comboBoxTypPohonnychHmot";
            this.comboBoxTypPohonnychHmot.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTypPohonnychHmot.TabIndex = 58;
            this.comboBoxTypPohonnychHmot.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypPohonnychHmot_SelectedIndexChanged);
            // 
            // labelZpusobVypoctu
            // 
            this.labelZpusobVypoctu.AutoSize = true;
            this.labelZpusobVypoctu.Location = new System.Drawing.Point(26, 103);
            this.labelZpusobVypoctu.Name = "labelZpusobVypoctu";
            this.labelZpusobVypoctu.Size = new System.Drawing.Size(87, 13);
            this.labelZpusobVypoctu.TabIndex = 53;
            this.labelZpusobVypoctu.Text = "Způsob výpočtu:";
            // 
            // labelCestoval
            // 
            this.labelCestoval.AutoSize = true;
            this.labelCestoval.Location = new System.Drawing.Point(26, 70);
            this.labelCestoval.Name = "labelCestoval";
            this.labelCestoval.Size = new System.Drawing.Size(51, 13);
            this.labelCestoval.TabIndex = 52;
            this.labelCestoval.Text = "Cestoval:";
            // 
            // labelPocetKm
            // 
            this.labelPocetKm.AutoSize = true;
            this.labelPocetKm.Location = new System.Drawing.Point(26, 30);
            this.labelPocetKm.Name = "labelPocetKm";
            this.labelPocetKm.Size = new System.Drawing.Size(98, 13);
            this.labelPocetKm.TabIndex = 51;
            this.labelPocetKm.Text = "Počet najetých km:";
            // 
            // textBoxPocetNajetychKm
            // 
            this.textBoxPocetNajetychKm.Location = new System.Drawing.Point(127, 27);
            this.textBoxPocetNajetychKm.Name = "textBoxPocetNajetychKm";
            this.textBoxPocetNajetychKm.Size = new System.Drawing.Size(100, 20);
            this.textBoxPocetNajetychKm.TabIndex = 50;
            // 
            // labelSpotrebovano
            // 
            this.labelSpotrebovano.AutoSize = true;
            this.labelSpotrebovano.Location = new System.Drawing.Point(26, 229);
            this.labelSpotrebovano.Name = "labelSpotrebovano";
            this.labelSpotrebovano.Size = new System.Drawing.Size(97, 13);
            this.labelSpotrebovano.TabIndex = 60;
            this.labelSpotrebovano.Text = "Spotřebováno litrů:";
            // 
            // numericUpDownSpotreba
            // 
            this.numericUpDownSpotreba.Location = new System.Drawing.Point(218, 229);
            this.numericUpDownSpotreba.Name = "numericUpDownSpotreba";
            this.numericUpDownSpotreba.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSpotreba.TabIndex = 61;
            // 
            // Udaje3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownSpotreba);
            this.Controls.Add(this.labelSpotrebovano);
            this.Controls.Add(this.comboBoxZpsbVypoctuPohHmot);
            this.Controls.Add(this.labelTypPohHmt);
            this.Controls.Add(this.comboBoxZpusobPrepravy);
            this.Controls.Add(this.labelPrumerCena);
            this.Controls.Add(this.textBoxPrumernaPohonneHmotyCena);
            this.Controls.Add(this.comboBoxTypPohonnychHmot);
            this.Controls.Add(this.labelZpusobVypoctu);
            this.Controls.Add(this.labelCestoval);
            this.Controls.Add(this.labelPocetKm);
            this.Controls.Add(this.textBoxPocetNajetychKm);
            this.Name = "Udaje3";
            this.Size = new System.Drawing.Size(532, 393);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpotreba)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTypPohHmt;
        private System.Windows.Forms.Label labelPrumerCena;
        private System.Windows.Forms.Label labelZpusobVypoctu;
        private System.Windows.Forms.Label labelCestoval;
        private System.Windows.Forms.Label labelPocetKm;
        public System.Windows.Forms.ComboBox comboBoxZpsbVypoctuPohHmot;
        public System.Windows.Forms.ComboBox comboBoxZpusobPrepravy;
        public System.Windows.Forms.TextBox textBoxPrumernaPohonneHmotyCena;
        public System.Windows.Forms.ComboBox comboBoxTypPohonnychHmot;
        public System.Windows.Forms.TextBox textBoxPocetNajetychKm;
        private System.Windows.Forms.Label labelSpotrebovano;
        public System.Windows.Forms.NumericUpDown numericUpDownSpotreba;
    }
}
