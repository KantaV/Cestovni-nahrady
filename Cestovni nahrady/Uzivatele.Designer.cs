namespace Cestovni_nahrady
{
    partial class Uzivatele
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
            this.labelNadpisUzivetele = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNadpisUzivetele
            // 
            this.labelNadpisUzivetele.AutoSize = true;
            this.labelNadpisUzivetele.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNadpisUzivetele.Location = new System.Drawing.Point(206, 12);
            this.labelNadpisUzivetele.Name = "labelNadpisUzivetele";
            this.labelNadpisUzivetele.Size = new System.Drawing.Size(120, 29);
            this.labelNadpisUzivetele.TabIndex = 7;
            this.labelNadpisUzivetele.Text = "Uživatelé";
            // 
            // Uzivatele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.labelNadpisUzivetele);
            this.Name = "Uzivatele";
            this.Size = new System.Drawing.Size(532, 393);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelNadpisUzivetele;
    }
}
