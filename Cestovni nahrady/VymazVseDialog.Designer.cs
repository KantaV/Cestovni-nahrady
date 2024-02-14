namespace Cestovni_nahrady
{
    partial class VymazVseDialog
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
            this.labelVymazVse = new System.Windows.Forms.Label();
            this.buttonAno = new System.Windows.Forms.Button();
            this.buttonNE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelVymazVse
            // 
            this.labelVymazVse.AutoSize = true;
            this.labelVymazVse.Location = new System.Drawing.Point(63, 24);
            this.labelVymazVse.Name = "labelVymazVse";
            this.labelVymazVse.Size = new System.Drawing.Size(162, 13);
            this.labelVymazVse.TabIndex = 0;
            this.labelVymazVse.Text = "Opravdu si přejete vymazat vše?";
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
            // VymazVseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 125);
            this.Controls.Add(this.buttonNE);
            this.Controls.Add(this.buttonAno);
            this.Controls.Add(this.labelVymazVse);
            this.Name = "VymazVseDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VymazVseDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVymazVse;
        private System.Windows.Forms.Button buttonAno;
        private System.Windows.Forms.Button buttonNE;
    }
}