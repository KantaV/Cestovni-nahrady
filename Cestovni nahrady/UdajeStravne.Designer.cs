namespace Cestovni_nahrady
{
    partial class UdajeStravne
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
            this.comboBoxStravneSektor = new System.Windows.Forms.ComboBox();
            this.checkBoxBezplatneJidlo = new System.Windows.Forms.CheckBox();
            this.labelStravne = new System.Windows.Forms.Label();
            this.jidlaZaDen1 = new Cestovni_nahrady.JidlaZaDen();
            this.SuspendLayout();
            // 
            // comboBoxStravneSektor
            // 
            this.comboBoxStravneSektor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStravneSektor.FormattingEnabled = true;
            this.comboBoxStravneSektor.Items.AddRange(new object[] {
            "Privátní sektor",
            "Veřejný sektor"});
            this.comboBoxStravneSektor.Location = new System.Drawing.Point(126, 28);
            this.comboBoxStravneSektor.Name = "comboBoxStravneSektor";
            this.comboBoxStravneSektor.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStravneSektor.TabIndex = 27;
            // 
            // checkBoxBezplatneJidlo
            // 
            this.checkBoxBezplatneJidlo.AutoSize = true;
            this.checkBoxBezplatneJidlo.Location = new System.Drawing.Point(40, 67);
            this.checkBoxBezplatneJidlo.Name = "checkBoxBezplatneJidlo";
            this.checkBoxBezplatneJidlo.Size = new System.Drawing.Size(173, 17);
            this.checkBoxBezplatneJidlo.TabIndex = 28;
            this.checkBoxBezplatneJidlo.Text = "Bylo poskytnuto bezplatné jídlo";
            this.checkBoxBezplatneJidlo.UseVisualStyleBackColor = true;
            this.checkBoxBezplatneJidlo.CheckedChanged += new System.EventHandler(this.checkBoxBezplatneJidlo_CheckedChanged);
            // 
            // labelStravne
            // 
            this.labelStravne.AutoSize = true;
            this.labelStravne.Location = new System.Drawing.Point(37, 29);
            this.labelStravne.Name = "labelStravne";
            this.labelStravne.Size = new System.Drawing.Size(47, 13);
            this.labelStravne.TabIndex = 26;
            this.labelStravne.Text = "Stravné:";
            // 
            // jidlaZaDen1
            // 
            this.jidlaZaDen1.AutoScroll = true;
            this.jidlaZaDen1.Location = new System.Drawing.Point(40, 110);
            this.jidlaZaDen1.Name = "jidlaZaDen1";
            this.jidlaZaDen1.Size = new System.Drawing.Size(445, 239);
            this.jidlaZaDen1.TabIndex = 31;
            // 
            // Udaje4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jidlaZaDen1);
            this.Controls.Add(this.comboBoxStravneSektor);
            this.Controls.Add(this.checkBoxBezplatneJidlo);
            this.Controls.Add(this.labelStravne);
            this.Name = "Udaje4";
            this.Size = new System.Drawing.Size(532, 393);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelStravne;
        public System.Windows.Forms.ComboBox comboBoxStravneSektor;
        public System.Windows.Forms.CheckBox checkBoxBezplatneJidlo;
        private JidlaZaDen jidlaZaDen1;
    }
}
