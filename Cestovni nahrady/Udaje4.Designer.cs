namespace Cestovni_nahrady
{
    partial class Udaje4
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
            this.numericUpDownPocetJidelZaDen = new System.Windows.Forms.NumericUpDown();
            this.comboBoxStravneSektor = new System.Windows.Forms.ComboBox();
            this.labelPocetJidel = new System.Windows.Forms.Label();
            this.checkBoxBezplatneJidlo = new System.Windows.Forms.CheckBox();
            this.labelStravne = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPocetJidelZaDen)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownPocetJidelZaDen
            // 
            this.numericUpDownPocetJidelZaDen.Location = new System.Drawing.Point(189, 119);
            this.numericUpDownPocetJidelZaDen.Name = "numericUpDownPocetJidelZaDen";
            this.numericUpDownPocetJidelZaDen.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPocetJidelZaDen.TabIndex = 29;
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
            // labelPocetJidel
            // 
            this.labelPocetJidel.AutoSize = true;
            this.labelPocetJidel.Location = new System.Drawing.Point(27, 121);
            this.labelPocetJidel.Name = "labelPocetJidel";
            this.labelPocetJidel.Size = new System.Drawing.Size(156, 13);
            this.labelPocetJidel.TabIndex = 30;
            this.labelPocetJidel.Text = "Počet bezplatných jídel za den:";
            // 
            // checkBoxBezplatneJidlo
            // 
            this.checkBoxBezplatneJidlo.AutoSize = true;
            this.checkBoxBezplatneJidlo.Location = new System.Drawing.Point(30, 91);
            this.checkBoxBezplatneJidlo.Name = "checkBoxBezplatneJidlo";
            this.checkBoxBezplatneJidlo.Size = new System.Drawing.Size(173, 17);
            this.checkBoxBezplatneJidlo.TabIndex = 28;
            this.checkBoxBezplatneJidlo.Text = "Bylo poskytnuto bezplatné jídlo";
            this.checkBoxBezplatneJidlo.UseVisualStyleBackColor = true;
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
            // Udaje4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownPocetJidelZaDen);
            this.Controls.Add(this.comboBoxStravneSektor);
            this.Controls.Add(this.labelPocetJidel);
            this.Controls.Add(this.checkBoxBezplatneJidlo);
            this.Controls.Add(this.labelStravne);
            this.Name = "Udaje4";
            this.Size = new System.Drawing.Size(532, 393);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPocetJidelZaDen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPocetJidel;
        private System.Windows.Forms.Label labelStravne;
        public System.Windows.Forms.NumericUpDown numericUpDownPocetJidelZaDen;
        public System.Windows.Forms.ComboBox comboBoxStravneSektor;
        public System.Windows.Forms.CheckBox checkBoxBezplatneJidlo;
    }
}
