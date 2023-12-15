namespace Cestovni_nahrady
{
    partial class UdajeOCeste3PohonneHmoty
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
            this.comboBoxPohonneHmotyZpsb = new System.Windows.Forms.ComboBox();
            this.labelTypPohHmt = new System.Windows.Forms.Label();
            this.comboBoxZpusobPrepravy = new System.Windows.Forms.ComboBox();
            this.labelPrumerCena = new System.Windows.Forms.Label();
            this.textBoxPrumernaPohonneHmotyCena = new System.Windows.Forms.TextBox();
            this.comboBoxTypPohonnychHmot = new System.Windows.Forms.ComboBox();
            this.labelPohonneHmoty = new System.Windows.Forms.Label();
            this.labelCestoval = new System.Windows.Forms.Label();
            this.labelPocetKm = new System.Windows.Forms.Label();
            this.textBoxPocetNajetychKm = new System.Windows.Forms.TextBox();
            this.buttonZpet = new System.Windows.Forms.Button();
            this.buttonDalsi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxPohonneHmotyZpsb
            // 
            this.comboBoxPohonneHmotyZpsb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPohonneHmotyZpsb.FormattingEnabled = true;
            this.comboBoxPohonneHmotyZpsb.Items.AddRange(new object[] {
            "Dle zákona",
            "Dle účtenky"});
            this.comboBoxPohonneHmotyZpsb.Location = new System.Drawing.Point(217, 87);
            this.comboBoxPohonneHmotyZpsb.Name = "comboBoxPohonneHmotyZpsb";
            this.comboBoxPohonneHmotyZpsb.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPohonneHmotyZpsb.TabIndex = 45;
            // 
            // labelTypPohHmt
            // 
            this.labelTypPohHmt.AutoSize = true;
            this.labelTypPohHmt.Location = new System.Drawing.Point(20, 164);
            this.labelTypPohHmt.Name = "labelTypPohHmt";
            this.labelTypPohHmt.Size = new System.Drawing.Size(104, 13);
            this.labelTypPohHmt.TabIndex = 49;
            this.labelTypPohHmt.Text = "Typ pohonné hmoty:";
            // 
            // comboBoxZpusobPrepravy
            // 
            this.comboBoxZpusobPrepravy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZpusobPrepravy.FormattingEnabled = true;
            this.comboBoxZpusobPrepravy.Items.AddRange(new object[] {
            "Služebním vozem",
            "Vlastním automobilem",
            "Vlastním automobilem s přivěsem",
            "Vlastní motorkou",
            "Vlastním nákladním vozem, autobusem, traktorem"});
            this.comboBoxZpusobPrepravy.Location = new System.Drawing.Point(83, 59);
            this.comboBoxZpusobPrepravy.Name = "comboBoxZpusobPrepravy";
            this.comboBoxZpusobPrepravy.Size = new System.Drawing.Size(255, 21);
            this.comboBoxZpusobPrepravy.TabIndex = 44;
            // 
            // labelPrumerCena
            // 
            this.labelPrumerCena.AutoSize = true;
            this.labelPrumerCena.Location = new System.Drawing.Point(20, 192);
            this.labelPrumerCena.Name = "labelPrumerCena";
            this.labelPrumerCena.Size = new System.Drawing.Size(82, 13);
            this.labelPrumerCena.TabIndex = 47;
            this.labelPrumerCena.Text = "Průměrná cena:";
            // 
            // textBoxPrumernaPohonneHmotyCena
            // 
            this.textBoxPrumernaPohonneHmotyCena.Enabled = false;
            this.textBoxPrumernaPohonneHmotyCena.Location = new System.Drawing.Point(137, 188);
            this.textBoxPrumernaPohonneHmotyCena.Name = "textBoxPrumernaPohonneHmotyCena";
            this.textBoxPrumernaPohonneHmotyCena.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrumernaPohonneHmotyCena.TabIndex = 46;
            this.textBoxPrumernaPohonneHmotyCena.Text = "0";
            // 
            // comboBoxTypPohonnychHmot
            // 
            this.comboBoxTypPohonnychHmot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypPohonnychHmot.FormattingEnabled = true;
            this.comboBoxTypPohonnychHmot.Items.AddRange(new object[] {
            "Natural 95",
            "Natural 98",
            "Nafta",
            "Elektřina",
            "LPG (plyn)"});
            this.comboBoxTypPohonnychHmot.Location = new System.Drawing.Point(137, 161);
            this.comboBoxTypPohonnychHmot.Name = "comboBoxTypPohonnychHmot";
            this.comboBoxTypPohonnychHmot.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTypPohonnychHmot.TabIndex = 48;
            // 
            // labelPohonneHmoty
            // 
            this.labelPohonneHmoty.AutoSize = true;
            this.labelPohonneHmoty.Location = new System.Drawing.Point(26, 87);
            this.labelPohonneHmoty.Name = "labelPohonneHmoty";
            this.labelPohonneHmoty.Size = new System.Drawing.Size(84, 13);
            this.labelPohonneHmoty.TabIndex = 42;
            this.labelPohonneHmoty.Text = "Pohonné hmoty:";
            // 
            // labelCestoval
            // 
            this.labelCestoval.AutoSize = true;
            this.labelCestoval.Location = new System.Drawing.Point(26, 62);
            this.labelCestoval.Name = "labelCestoval";
            this.labelCestoval.Size = new System.Drawing.Size(51, 13);
            this.labelCestoval.TabIndex = 41;
            this.labelCestoval.Text = "Cestoval:";
            // 
            // labelPocetKm
            // 
            this.labelPocetKm.AutoSize = true;
            this.labelPocetKm.Location = new System.Drawing.Point(26, 24);
            this.labelPocetKm.Name = "labelPocetKm";
            this.labelPocetKm.Size = new System.Drawing.Size(98, 13);
            this.labelPocetKm.TabIndex = 40;
            this.labelPocetKm.Text = "Počet najetých km:";
            // 
            // textBoxPocetNajetychKm
            // 
            this.textBoxPocetNajetychKm.Location = new System.Drawing.Point(127, 21);
            this.textBoxPocetNajetychKm.Name = "textBoxPocetNajetychKm";
            this.textBoxPocetNajetychKm.Size = new System.Drawing.Size(100, 20);
            this.textBoxPocetNajetychKm.TabIndex = 10;
            // 
            // buttonZpet
            // 
            this.buttonZpet.Location = new System.Drawing.Point(12, 319);
            this.buttonZpet.Name = "buttonZpet";
            this.buttonZpet.Size = new System.Drawing.Size(75, 23);
            this.buttonZpet.TabIndex = 50;
            this.buttonZpet.Text = "Zpět";
            this.buttonZpet.UseVisualStyleBackColor = true;
            // 
            // buttonDalsi
            // 
            this.buttonDalsi.Location = new System.Drawing.Point(429, 319);
            this.buttonDalsi.Name = "buttonDalsi";
            this.buttonDalsi.Size = new System.Drawing.Size(75, 23);
            this.buttonDalsi.TabIndex = 51;
            this.buttonDalsi.Text = "Další";
            this.buttonDalsi.UseVisualStyleBackColor = true;
            // 
            // UdajeOCeste3PohonneHmoty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 354);
            this.Controls.Add(this.buttonDalsi);
            this.Controls.Add(this.buttonZpet);
            this.Controls.Add(this.comboBoxPohonneHmotyZpsb);
            this.Controls.Add(this.labelTypPohHmt);
            this.Controls.Add(this.comboBoxZpusobPrepravy);
            this.Controls.Add(this.labelPrumerCena);
            this.Controls.Add(this.textBoxPrumernaPohonneHmotyCena);
            this.Controls.Add(this.comboBoxTypPohonnychHmot);
            this.Controls.Add(this.labelPohonneHmoty);
            this.Controls.Add(this.labelCestoval);
            this.Controls.Add(this.labelPocetKm);
            this.Controls.Add(this.textBoxPocetNajetychKm);
            this.Name = "UdajeOCeste3PohonneHmoty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UdajeOCeste3PohonneHmoty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPohonneHmotyZpsb;
        private System.Windows.Forms.Label labelTypPohHmt;
        private System.Windows.Forms.ComboBox comboBoxZpusobPrepravy;
        private System.Windows.Forms.Label labelPrumerCena;
        private System.Windows.Forms.TextBox textBoxPrumernaPohonneHmotyCena;
        private System.Windows.Forms.ComboBox comboBoxTypPohonnychHmot;
        private System.Windows.Forms.Label labelPohonneHmoty;
        private System.Windows.Forms.Label labelCestoval;
        private System.Windows.Forms.Label labelPocetKm;
        private System.Windows.Forms.TextBox textBoxPocetNajetychKm;
        private System.Windows.Forms.Button buttonZpet;
        private System.Windows.Forms.Button buttonDalsi;
    }
}