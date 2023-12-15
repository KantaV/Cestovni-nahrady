namespace Cestovni_nahrady
{
    partial class UdajeOCeste4Stravne
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
            this.numericUpDownPocetJidelZaDen = new System.Windows.Forms.NumericUpDown();
            this.comboBoxStravne = new System.Windows.Forms.ComboBox();
            this.labelPocetJidel = new System.Windows.Forms.Label();
            this.checkBoxBezplatneJidlo = new System.Windows.Forms.CheckBox();
            this.labelStravne = new System.Windows.Forms.Label();
            this.buttonZpet = new System.Windows.Forms.Button();
            this.buttonSpocitej = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPocetJidelZaDen)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownPocetJidelZaDen
            // 
            this.numericUpDownPocetJidelZaDen.Location = new System.Drawing.Point(181, 109);
            this.numericUpDownPocetJidelZaDen.Name = "numericUpDownPocetJidelZaDen";
            this.numericUpDownPocetJidelZaDen.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPocetJidelZaDen.TabIndex = 24;
            // 
            // comboBoxStravne
            // 
            this.comboBoxStravne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStravne.FormattingEnabled = true;
            this.comboBoxStravne.Items.AddRange(new object[] {
            "Privátní sektor",
            "Veřejný sektor"});
            this.comboBoxStravne.Location = new System.Drawing.Point(118, 18);
            this.comboBoxStravne.Name = "comboBoxStravne";
            this.comboBoxStravne.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStravne.TabIndex = 22;
            // 
            // labelPocetJidel
            // 
            this.labelPocetJidel.AutoSize = true;
            this.labelPocetJidel.Location = new System.Drawing.Point(19, 111);
            this.labelPocetJidel.Name = "labelPocetJidel";
            this.labelPocetJidel.Size = new System.Drawing.Size(156, 13);
            this.labelPocetJidel.TabIndex = 25;
            this.labelPocetJidel.Text = "Počet bezplatných jídel za den:";
            // 
            // checkBoxBezplatneJidlo
            // 
            this.checkBoxBezplatneJidlo.AutoSize = true;
            this.checkBoxBezplatneJidlo.Location = new System.Drawing.Point(22, 81);
            this.checkBoxBezplatneJidlo.Name = "checkBoxBezplatneJidlo";
            this.checkBoxBezplatneJidlo.Size = new System.Drawing.Size(173, 17);
            this.checkBoxBezplatneJidlo.TabIndex = 23;
            this.checkBoxBezplatneJidlo.Text = "Bylo poskytnuto bezplatné jídlo";
            this.checkBoxBezplatneJidlo.UseVisualStyleBackColor = true;
            // 
            // labelStravne
            // 
            this.labelStravne.AutoSize = true;
            this.labelStravne.Location = new System.Drawing.Point(29, 19);
            this.labelStravne.Name = "labelStravne";
            this.labelStravne.Size = new System.Drawing.Size(47, 13);
            this.labelStravne.TabIndex = 21;
            this.labelStravne.Text = "Stravné:";
            // 
            // buttonZpet
            // 
            this.buttonZpet.Location = new System.Drawing.Point(12, 319);
            this.buttonZpet.Name = "buttonZpet";
            this.buttonZpet.Size = new System.Drawing.Size(75, 23);
            this.buttonZpet.TabIndex = 26;
            this.buttonZpet.Text = "Zpět";
            this.buttonZpet.UseVisualStyleBackColor = true;
            // 
            // buttonSpocitej
            // 
            this.buttonSpocitej.Location = new System.Drawing.Point(429, 319);
            this.buttonSpocitej.Name = "buttonSpocitej";
            this.buttonSpocitej.Size = new System.Drawing.Size(75, 23);
            this.buttonSpocitej.TabIndex = 27;
            this.buttonSpocitej.Text = "Vypočítej";
            this.buttonSpocitej.UseVisualStyleBackColor = true;
            // 
            // UdajeOCeste4Stravne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 354);
            this.Controls.Add(this.buttonSpocitej);
            this.Controls.Add(this.buttonZpet);
            this.Controls.Add(this.numericUpDownPocetJidelZaDen);
            this.Controls.Add(this.comboBoxStravne);
            this.Controls.Add(this.labelPocetJidel);
            this.Controls.Add(this.checkBoxBezplatneJidlo);
            this.Controls.Add(this.labelStravne);
            this.Name = "UdajeOCeste4Stravne";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UdajeOCeste4Stravne";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPocetJidelZaDen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownPocetJidelZaDen;
        private System.Windows.Forms.ComboBox comboBoxStravne;
        private System.Windows.Forms.Label labelPocetJidel;
        private System.Windows.Forms.CheckBox checkBoxBezplatneJidlo;
        private System.Windows.Forms.Label labelStravne;
        private System.Windows.Forms.Button buttonZpet;
        private System.Windows.Forms.Button buttonSpocitej;
    }
}