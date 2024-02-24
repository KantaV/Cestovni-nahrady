namespace Cestovni_nahrady
{
    partial class AnoNeDialog
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
            this.labelZprava = new System.Windows.Forms.Label();
            this.buttonAno = new System.Windows.Forms.Button();
            this.buttonNE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelZprava
            // 
            this.labelZprava.AutoSize = true;
            this.labelZprava.Location = new System.Drawing.Point(63, 24);
            this.labelZprava.Name = "labelZprava";
            this.labelZprava.Size = new System.Drawing.Size(41, 13);
            this.labelZprava.TabIndex = 0;
            this.labelZprava.Text = "Zprava";
            // 
            // buttonAno
            // 
            this.buttonAno.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAno.Location = new System.Drawing.Point(46, 73);
            this.buttonAno.Name = "buttonAno";
            this.buttonAno.Size = new System.Drawing.Size(75, 23);
            this.buttonAno.TabIndex = 1;
            this.buttonAno.Text = "OK";
            this.buttonAno.UseVisualStyleBackColor = true;
            // 
            // buttonNE
            // 
            this.buttonNE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonNE.Location = new System.Drawing.Point(178, 73);
            this.buttonNE.Name = "buttonNE";
            this.buttonNE.Size = new System.Drawing.Size(75, 23);
            this.buttonNE.TabIndex = 2;
            this.buttonNE.Text = "Zrušit";
            this.buttonNE.UseVisualStyleBackColor = true;
            // 
            // AnoNeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 125);
            this.Controls.Add(this.buttonNE);
            this.Controls.Add(this.buttonAno);
            this.Controls.Add(this.labelZprava);
            this.Name = "AnoNeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VymazVseDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelZprava;
        private System.Windows.Forms.Button buttonAno;
        private System.Windows.Forms.Button buttonNE;
    }
}