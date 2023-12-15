namespace Cestovni_nahrady
{
    partial class UdajeOCeste1
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
            this.comboBoxPosledniDenHodin = new System.Windows.Forms.ComboBox();
            this.comboBoxPrvniDenHodin = new System.Windows.Forms.ComboBox();
            this.labelPosledniNaCeste = new System.Windows.Forms.Label();
            this.labelPrvniNaCeste = new System.Windows.Forms.Label();
            this.dtpKonecCesty = new System.Windows.Forms.DateTimePicker();
            this.labelKonecCesty = new System.Windows.Forms.Label();
            this.dtpZacatekCesty = new System.Windows.Forms.DateTimePicker();
            this.labelZacatekCesty = new System.Windows.Forms.Label();
            this.textBoxDatNar = new System.Windows.Forms.TextBox();
            this.labelDatNar = new System.Windows.Forms.Label();
            this.textBoxPrijmeni = new System.Windows.Forms.TextBox();
            this.labelPrijmeni = new System.Windows.Forms.Label();
            this.textBoxJmeno = new System.Windows.Forms.TextBox();
            this.labelJmeno = new System.Windows.Forms.Label();
            this.buttonZpet = new System.Windows.Forms.Button();
            this.buttonDalsi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxPosledniDenHodin
            // 
            this.comboBoxPosledniDenHodin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPosledniDenHodin.FormattingEnabled = true;
            this.comboBoxPosledniDenHodin.Items.AddRange(new object[] {
            "Méně než 5 hodin",
            "5 až 12 hodin",
            "12 až 18 hodin",
            "18 a více hodin"});
            this.comboBoxPosledniDenHodin.Location = new System.Drawing.Point(297, 266);
            this.comboBoxPosledniDenHodin.Name = "comboBoxPosledniDenHodin";
            this.comboBoxPosledniDenHodin.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPosledniDenHodin.TabIndex = 38;
            // 
            // comboBoxPrvniDenHodin
            // 
            this.comboBoxPrvniDenHodin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrvniDenHodin.FormattingEnabled = true;
            this.comboBoxPrvniDenHodin.Items.AddRange(new object[] {
            "Méně než 5 hodin",
            "5 až 12 hodin",
            "12 až 18 hodin",
            "18 a více hodin"});
            this.comboBoxPrvniDenHodin.Location = new System.Drawing.Point(297, 233);
            this.comboBoxPrvniDenHodin.Name = "comboBoxPrvniDenHodin";
            this.comboBoxPrvniDenHodin.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPrvniDenHodin.TabIndex = 37;
            // 
            // labelPosledniNaCeste
            // 
            this.labelPosledniNaCeste.AutoSize = true;
            this.labelPosledniNaCeste.Location = new System.Drawing.Point(69, 269);
            this.labelPosledniNaCeste.Name = "labelPosledniNaCeste";
            this.labelPosledniNaCeste.Size = new System.Drawing.Size(222, 13);
            this.labelPosledniNaCeste.TabIndex = 40;
            this.labelPosledniNaCeste.Text = "Počet hodin na cestě poslední pracovní den:";
            // 
            // labelPrvniNaCeste
            // 
            this.labelPrvniNaCeste.AutoSize = true;
            this.labelPrvniNaCeste.Location = new System.Drawing.Point(69, 233);
            this.labelPrvniNaCeste.Name = "labelPrvniNaCeste";
            this.labelPrvniNaCeste.Size = new System.Drawing.Size(206, 13);
            this.labelPrvniNaCeste.TabIndex = 39;
            this.labelPrvniNaCeste.Text = "Počet hodin na cestě první pracovní den:";
            // 
            // dtpKonecCesty
            // 
            this.dtpKonecCesty.Location = new System.Drawing.Point(196, 180);
            this.dtpKonecCesty.Name = "dtpKonecCesty";
            this.dtpKonecCesty.Size = new System.Drawing.Size(200, 20);
            this.dtpKonecCesty.TabIndex = 36;
            // 
            // labelKonecCesty
            // 
            this.labelKonecCesty.AutoSize = true;
            this.labelKonecCesty.Location = new System.Drawing.Point(69, 181);
            this.labelKonecCesty.Name = "labelKonecCesty";
            this.labelKonecCesty.Size = new System.Drawing.Size(112, 13);
            this.labelKonecCesty.TabIndex = 45;
            this.labelKonecCesty.Text = "Konec služební cesty:";
            // 
            // dtpZacatekCesty
            // 
            this.dtpZacatekCesty.Location = new System.Drawing.Point(196, 151);
            this.dtpZacatekCesty.Name = "dtpZacatekCesty";
            this.dtpZacatekCesty.Size = new System.Drawing.Size(200, 20);
            this.dtpZacatekCesty.TabIndex = 35;
            // 
            // labelZacatekCesty
            // 
            this.labelZacatekCesty.AutoSize = true;
            this.labelZacatekCesty.Location = new System.Drawing.Point(69, 152);
            this.labelZacatekCesty.Name = "labelZacatekCesty";
            this.labelZacatekCesty.Size = new System.Drawing.Size(121, 13);
            this.labelZacatekCesty.TabIndex = 44;
            this.labelZacatekCesty.Text = "Začátek služební cesty:";
            // 
            // textBoxDatNar
            // 
            this.textBoxDatNar.Location = new System.Drawing.Point(161, 96);
            this.textBoxDatNar.Name = "textBoxDatNar";
            this.textBoxDatNar.Size = new System.Drawing.Size(100, 20);
            this.textBoxDatNar.TabIndex = 34;
            // 
            // labelDatNar
            // 
            this.labelDatNar.AutoSize = true;
            this.labelDatNar.Location = new System.Drawing.Point(69, 99);
            this.labelDatNar.Name = "labelDatNar";
            this.labelDatNar.Size = new System.Drawing.Size(86, 13);
            this.labelDatNar.TabIndex = 43;
            this.labelDatNar.Text = "Datum narození:";
            // 
            // textBoxPrijmeni
            // 
            this.textBoxPrijmeni.Location = new System.Drawing.Point(161, 67);
            this.textBoxPrijmeni.Name = "textBoxPrijmeni";
            this.textBoxPrijmeni.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrijmeni.TabIndex = 33;
            // 
            // labelPrijmeni
            // 
            this.labelPrijmeni.AutoSize = true;
            this.labelPrijmeni.Location = new System.Drawing.Point(69, 72);
            this.labelPrijmeni.Name = "labelPrijmeni";
            this.labelPrijmeni.Size = new System.Drawing.Size(51, 13);
            this.labelPrijmeni.TabIndex = 42;
            this.labelPrijmeni.Text = "Příjmení:";
            // 
            // textBoxJmeno
            // 
            this.textBoxJmeno.Location = new System.Drawing.Point(161, 40);
            this.textBoxJmeno.Name = "textBoxJmeno";
            this.textBoxJmeno.Size = new System.Drawing.Size(100, 20);
            this.textBoxJmeno.TabIndex = 32;
            // 
            // labelJmeno
            // 
            this.labelJmeno.AutoSize = true;
            this.labelJmeno.Location = new System.Drawing.Point(69, 43);
            this.labelJmeno.Name = "labelJmeno";
            this.labelJmeno.Size = new System.Drawing.Size(41, 13);
            this.labelJmeno.TabIndex = 41;
            this.labelJmeno.Text = "Jméno:";
            // 
            // buttonZpet
            // 
            this.buttonZpet.Location = new System.Drawing.Point(12, 321);
            this.buttonZpet.Name = "buttonZpet";
            this.buttonZpet.Size = new System.Drawing.Size(75, 23);
            this.buttonZpet.TabIndex = 46;
            this.buttonZpet.Text = "Zpět";
            this.buttonZpet.UseVisualStyleBackColor = true;
            // 
            // buttonDalsi
            // 
            this.buttonDalsi.Location = new System.Drawing.Point(429, 321);
            this.buttonDalsi.Name = "buttonDalsi";
            this.buttonDalsi.Size = new System.Drawing.Size(75, 23);
            this.buttonDalsi.TabIndex = 47;
            this.buttonDalsi.Text = "Další";
            this.buttonDalsi.UseVisualStyleBackColor = true;
            // 
            // UdajeOCeste1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 354);
            this.Controls.Add(this.buttonDalsi);
            this.Controls.Add(this.buttonZpet);
            this.Controls.Add(this.comboBoxPosledniDenHodin);
            this.Controls.Add(this.comboBoxPrvniDenHodin);
            this.Controls.Add(this.labelPosledniNaCeste);
            this.Controls.Add(this.labelPrvniNaCeste);
            this.Controls.Add(this.dtpKonecCesty);
            this.Controls.Add(this.labelKonecCesty);
            this.Controls.Add(this.dtpZacatekCesty);
            this.Controls.Add(this.labelZacatekCesty);
            this.Controls.Add(this.textBoxDatNar);
            this.Controls.Add(this.labelDatNar);
            this.Controls.Add(this.textBoxPrijmeni);
            this.Controls.Add(this.labelPrijmeni);
            this.Controls.Add(this.textBoxJmeno);
            this.Controls.Add(this.labelJmeno);
            this.Name = "UdajeOCeste1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UdajeOCeste1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPosledniDenHodin;
        private System.Windows.Forms.ComboBox comboBoxPrvniDenHodin;
        private System.Windows.Forms.Label labelPosledniNaCeste;
        private System.Windows.Forms.Label labelPrvniNaCeste;
        private System.Windows.Forms.DateTimePicker dtpKonecCesty;
        private System.Windows.Forms.Label labelKonecCesty;
        private System.Windows.Forms.DateTimePicker dtpZacatekCesty;
        private System.Windows.Forms.Label labelZacatekCesty;
        private System.Windows.Forms.TextBox textBoxDatNar;
        private System.Windows.Forms.Label labelDatNar;
        private System.Windows.Forms.TextBox textBoxPrijmeni;
        private System.Windows.Forms.Label labelPrijmeni;
        private System.Windows.Forms.TextBox textBoxJmeno;
        private System.Windows.Forms.Label labelJmeno;
        private System.Windows.Forms.Button buttonZpet;
        private System.Windows.Forms.Button buttonDalsi;
    }
}