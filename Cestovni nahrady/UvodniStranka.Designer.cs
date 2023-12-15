namespace Cestovni_nahrady
{
    partial class UvodniStranka
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

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonNastaveni = new System.Windows.Forms.Button();
            this.button1Debug = new System.Windows.Forms.Button();
            this.button2NaDebug = new System.Windows.Forms.Button();
            this.buttonNaDebug3 = new System.Windows.Forms.Button();
            this.buttonNaDebug4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNastaveni
            // 
            this.buttonNastaveni.Location = new System.Drawing.Point(429, 319);
            this.buttonNastaveni.Name = "buttonNastaveni";
            this.buttonNastaveni.Size = new System.Drawing.Size(75, 23);
            this.buttonNastaveni.TabIndex = 17;
            this.buttonNastaveni.Text = "Nastavení";
            this.buttonNastaveni.UseVisualStyleBackColor = true;
            this.buttonNastaveni.Click += new System.EventHandler(this.buttonNastaveni_Click);
            // 
            // button1Debug
            // 
            this.button1Debug.Location = new System.Drawing.Point(176, 89);
            this.button1Debug.Name = "button1Debug";
            this.button1Debug.Size = new System.Drawing.Size(155, 23);
            this.button1Debug.TabIndex = 40;
            this.button1Debug.Text = "btn na debug uoc1";
            this.button1Debug.UseVisualStyleBackColor = true;
            this.button1Debug.Click += new System.EventHandler(this.button1Debug_Click);
            // 
            // button2NaDebug
            // 
            this.button2NaDebug.Location = new System.Drawing.Point(176, 129);
            this.button2NaDebug.Name = "button2NaDebug";
            this.button2NaDebug.Size = new System.Drawing.Size(156, 23);
            this.button2NaDebug.TabIndex = 41;
            this.button2NaDebug.Text = "btn na debug uoc2z";
            this.button2NaDebug.UseVisualStyleBackColor = true;
            this.button2NaDebug.Click += new System.EventHandler(this.button2NaDebug_Click);
            // 
            // buttonNaDebug3
            // 
            this.buttonNaDebug3.Location = new System.Drawing.Point(176, 174);
            this.buttonNaDebug3.Name = "buttonNaDebug3";
            this.buttonNaDebug3.Size = new System.Drawing.Size(155, 23);
            this.buttonNaDebug3.TabIndex = 42;
            this.buttonNaDebug3.Text = "btn na debug uoc3ph";
            this.buttonNaDebug3.UseVisualStyleBackColor = true;
            this.buttonNaDebug3.Click += new System.EventHandler(this.buttonNaDebug3_Click);
            // 
            // buttonNaDebug4
            // 
            this.buttonNaDebug4.Location = new System.Drawing.Point(176, 212);
            this.buttonNaDebug4.Name = "buttonNaDebug4";
            this.buttonNaDebug4.Size = new System.Drawing.Size(156, 23);
            this.buttonNaDebug4.TabIndex = 43;
            this.buttonNaDebug4.Text = "btn na debug uoc4s";
            this.buttonNaDebug4.UseVisualStyleBackColor = true;
            this.buttonNaDebug4.Click += new System.EventHandler(this.buttonNaDebug4_Click);
            // 
            // UvodniStranka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(516, 354);
            this.Controls.Add(this.buttonNaDebug4);
            this.Controls.Add(this.buttonNaDebug3);
            this.Controls.Add(this.button2NaDebug);
            this.Controls.Add(this.button1Debug);
            this.Controls.Add(this.buttonNastaveni);
            this.Name = "UvodniStranka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonNastaveni;
        private System.Windows.Forms.Button button1Debug;
        private System.Windows.Forms.Button button2NaDebug;
        private System.Windows.Forms.Button buttonNaDebug3;
        private System.Windows.Forms.Button buttonNaDebug4;
    }
}

