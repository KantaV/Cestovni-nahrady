namespace Cestovni_nahrady
{
    partial class UdajeOZahranicniCeste
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
            this.numericUpDownPocetZemi = new System.Windows.Forms.NumericUpDown();
            this.labelPocetZemi = new System.Windows.Forms.Label();
            this.zahranici1 = new Cestovni_nahrady.Zahranici();
            this.labelCelkZacatekCesty = new System.Windows.Forms.Label();
            this.labelCelkKonecCesty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPocetZemi)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownPocetZemi
            // 
            this.numericUpDownPocetZemi.Location = new System.Drawing.Point(302, 4);
            this.numericUpDownPocetZemi.Name = "numericUpDownPocetZemi";
            this.numericUpDownPocetZemi.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPocetZemi.TabIndex = 38;
            this.numericUpDownPocetZemi.ValueChanged += new System.EventHandler(this.numericUpDownPocetZemi_ValueChanged);
            // 
            // labelPocetZemi
            // 
            this.labelPocetZemi.AutoSize = true;
            this.labelPocetZemi.Location = new System.Drawing.Point(99, 6);
            this.labelPocetZemi.Name = "labelPocetZemi";
            this.labelPocetZemi.Size = new System.Drawing.Size(197, 13);
            this.labelPocetZemi.TabIndex = 39;
            this.labelPocetZemi.Text = "Počet navštívených zahraničních zemí:";
            // 
            // zahranici1
            // 
            this.zahranici1.AutoScroll = true;
            this.zahranici1.Location = new System.Drawing.Point(3, 30);
            this.zahranici1.Name = "zahranici1";
            this.zahranici1.Size = new System.Drawing.Size(594, 323);
            this.zahranici1.TabIndex = 40;
            // 
            // labelCelkZacatekCesty
            // 
            this.labelCelkZacatekCesty.AutoSize = true;
            this.labelCelkZacatekCesty.Location = new System.Drawing.Point(15, 370);
            this.labelCelkZacatekCesty.Name = "labelCelkZacatekCesty";
            this.labelCelkZacatekCesty.Size = new System.Drawing.Size(117, 13);
            this.labelCelkZacatekCesty.TabIndex = 41;
            this.labelCelkZacatekCesty.Text = "Celkový začátek cesty:";
            // 
            // labelCelkKonecCesty
            // 
            this.labelCelkKonecCesty.AutoSize = true;
            this.labelCelkKonecCesty.Location = new System.Drawing.Point(380, 370);
            this.labelCelkKonecCesty.Name = "labelCelkKonecCesty";
            this.labelCelkKonecCesty.Size = new System.Drawing.Size(112, 13);
            this.labelCelkKonecCesty.TabIndex = 42;
            this.labelCelkKonecCesty.Text = "Celkový konec cesty: ";
            // 
            // UdajeOZahranicniCeste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCelkKonecCesty);
            this.Controls.Add(this.labelCelkZacatekCesty);
            this.Controls.Add(this.zahranici1);
            this.Controls.Add(this.numericUpDownPocetZemi);
            this.Controls.Add(this.labelPocetZemi);
            this.Name = "UdajeOZahranicniCeste";
            this.Size = new System.Drawing.Size(600, 393);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPocetZemi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Zahranici zahranici1;
        private System.Windows.Forms.Label labelPocetZemi;
        public System.Windows.Forms.NumericUpDown numericUpDownPocetZemi;
        public System.Windows.Forms.Label labelCelkZacatekCesty;
        public System.Windows.Forms.Label labelCelkKonecCesty;
    }
}
