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
            this.zahranici1.Size = new System.Drawing.Size(543, 323);
            this.zahranici1.TabIndex = 40;
            // 
            // Udaje2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zahranici1);
            this.Controls.Add(this.numericUpDownPocetZemi);
            this.Controls.Add(this.labelPocetZemi);
            this.Name = "Udaje2";
            this.Size = new System.Drawing.Size(546, 393);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPocetZemi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Zahranici zahranici1;
        private System.Windows.Forms.Label labelPocetZemi;
        public System.Windows.Forms.NumericUpDown numericUpDownPocetZemi;
    }
}
