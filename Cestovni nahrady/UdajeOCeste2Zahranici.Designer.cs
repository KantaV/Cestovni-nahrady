namespace Cestovni_nahrady
{
    partial class UdajeOCeste2Zahranici
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
            this.numericUpDownPocetZemi = new System.Windows.Forms.NumericUpDown();
            this.labelPocetZemi = new System.Windows.Forms.Label();
            this.buttonDalsi = new System.Windows.Forms.Button();
            this.buttonZpet = new System.Windows.Forms.Button();
            this.zahranici1 = new Cestovni_nahrady.Zahranici();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPocetZemi)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownPocetZemi
            // 
            this.numericUpDownPocetZemi.Location = new System.Drawing.Point(299, 7);
            this.numericUpDownPocetZemi.Name = "numericUpDownPocetZemi";
            this.numericUpDownPocetZemi.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPocetZemi.TabIndex = 35;
            this.numericUpDownPocetZemi.ValueChanged += new System.EventHandler(this.numericUpDownPocetZemi_ValueChanged);
            // 
            // labelPocetZemi
            // 
            this.labelPocetZemi.AutoSize = true;
            this.labelPocetZemi.Location = new System.Drawing.Point(96, 9);
            this.labelPocetZemi.Name = "labelPocetZemi";
            this.labelPocetZemi.Size = new System.Drawing.Size(197, 13);
            this.labelPocetZemi.TabIndex = 36;
            this.labelPocetZemi.Text = "Počet navštívených zahraničních zemí:";
            // 
            // buttonDalsi
            // 
            this.buttonDalsi.Location = new System.Drawing.Point(443, 319);
            this.buttonDalsi.Name = "buttonDalsi";
            this.buttonDalsi.Size = new System.Drawing.Size(75, 23);
            this.buttonDalsi.TabIndex = 38;
            this.buttonDalsi.Text = "Další";
            this.buttonDalsi.UseVisualStyleBackColor = true;
            // 
            // buttonZpet
            // 
            this.buttonZpet.Location = new System.Drawing.Point(12, 319);
            this.buttonZpet.Name = "buttonZpet";
            this.buttonZpet.Size = new System.Drawing.Size(75, 23);
            this.buttonZpet.TabIndex = 39;
            this.buttonZpet.Text = "Zpět";
            this.buttonZpet.UseVisualStyleBackColor = true;
            // 
            // zahranici1
            // 
            this.zahranici1.AutoScroll = true;
            this.zahranici1.Location = new System.Drawing.Point(0, 33);
            this.zahranici1.Name = "zahranici1";
            this.zahranici1.Size = new System.Drawing.Size(532, 280);
            this.zahranici1.TabIndex = 37;
            // 
            // UdajeOCeste2Zahranici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 354);
            this.Controls.Add(this.buttonZpet);
            this.Controls.Add(this.buttonDalsi);
            this.Controls.Add(this.zahranici1);
            this.Controls.Add(this.numericUpDownPocetZemi);
            this.Controls.Add(this.labelPocetZemi);
            this.Name = "UdajeOCeste2Zahranici";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UdajeOCeste2";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPocetZemi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownPocetZemi;
        private System.Windows.Forms.Label labelPocetZemi;
        private Zahranici zahranici1;
        private System.Windows.Forms.Button buttonDalsi;
        private System.Windows.Forms.Button buttonZpet;
    }
}