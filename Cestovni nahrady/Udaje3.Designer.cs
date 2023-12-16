namespace Cestovni_nahrady
{
    partial class Udaje3
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
            this.comboBoxPohonneHmotyZpsb = new System.Windows.Forms.ComboBox();
            this.labelTypPohHmt = new System.Windows.Forms.Label();
            this.comboBoxZpusobPrepravy = new System.Windows.Forms.ComboBox();
            this.labelPrumerCena = new System.Windows.Forms.Label();
            this.textBoxPrumernaPohonneHmotyCena = new System.Windows.Forms.TextBox();
            this.comboBoxTypPohonnychHmot = new System.Windows.Forms.ComboBox();
            this.labelPohonneHmoty = new System.Windows.Forms.Label();
            this.labelCestoval = new System.Windows.Forms.Label();
            this.labelPocetKm = new System.Windows.Forms.Label();
            this.textBoxPocetNajetychKm = new System.Windows.Forms.TextBox();
            this.labelSpotrebovano = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxPohonneHmotyZpsb
            // 
            this.comboBoxPohonneHmotyZpsb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPohonneHmotyZpsb.FormattingEnabled = true;
            this.comboBoxPohonneHmotyZpsb.Items.AddRange(new object[] {
            "Dle zákona",
            "Dle účtenky"});
            this.comboBoxPohonneHmotyZpsb.Location = new System.Drawing.Point(217, 95);
            this.comboBoxPohonneHmotyZpsb.Name = "comboBoxPohonneHmotyZpsb";
            this.comboBoxPohonneHmotyZpsb.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPohonneHmotyZpsb.TabIndex = 55;
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
            "Služebním vozem",
            "Vlastním automobilem",
            "Vlastním automobilem s přivěsem",
            "Vlastní motorkou",
            "Vlastním nákladním vozem, autobusem, traktorem"});
            this.comboBoxZpusobPrepravy.Location = new System.Drawing.Point(83, 67);
            this.comboBoxZpusobPrepravy.Name = "comboBoxZpusobPrepravy";
            this.comboBoxZpusobPrepravy.Size = new System.Drawing.Size(255, 21);
            this.comboBoxZpusobPrepravy.TabIndex = 54;
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
            // labelPohonneHmoty
            // 
            this.labelPohonneHmoty.AutoSize = true;
            this.labelPohonneHmoty.Location = new System.Drawing.Point(26, 95);
            this.labelPohonneHmoty.Name = "labelPohonneHmoty";
            this.labelPohonneHmoty.Size = new System.Drawing.Size(84, 13);
            this.labelPohonneHmoty.TabIndex = 53;
            this.labelPohonneHmoty.Text = "Pohonné hmoty:";
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
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(218, 229);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 61;
            // 
            // Udaje3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.labelSpotrebovano);
            this.Controls.Add(this.comboBoxPohonneHmotyZpsb);
            this.Controls.Add(this.labelTypPohHmt);
            this.Controls.Add(this.comboBoxZpusobPrepravy);
            this.Controls.Add(this.labelPrumerCena);
            this.Controls.Add(this.textBoxPrumernaPohonneHmotyCena);
            this.Controls.Add(this.comboBoxTypPohonnychHmot);
            this.Controls.Add(this.labelPohonneHmoty);
            this.Controls.Add(this.labelCestoval);
            this.Controls.Add(this.labelPocetKm);
            this.Controls.Add(this.textBoxPocetNajetychKm);
            this.Name = "Udaje3";
            this.Size = new System.Drawing.Size(532, 393);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTypPohHmt;
        private System.Windows.Forms.Label labelPrumerCena;
        private System.Windows.Forms.Label labelPohonneHmoty;
        private System.Windows.Forms.Label labelCestoval;
        private System.Windows.Forms.Label labelPocetKm;
        public System.Windows.Forms.ComboBox comboBoxPohonneHmotyZpsb;
        public System.Windows.Forms.ComboBox comboBoxZpusobPrepravy;
        public System.Windows.Forms.TextBox textBoxPrumernaPohonneHmotyCena;
        public System.Windows.Forms.ComboBox comboBoxTypPohonnychHmot;
        public System.Windows.Forms.TextBox textBoxPocetNajetychKm;
        private System.Windows.Forms.Label labelSpotrebovano;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
