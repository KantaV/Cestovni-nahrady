namespace Cestovni_nahrady
{
    partial class Udaje1
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
            this.comboBoxPosledniDenHodin.Location = new System.Drawing.Point(302, 269);
            this.comboBoxPosledniDenHodin.Name = "comboBoxPosledniDenHodin";
            this.comboBoxPosledniDenHodin.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPosledniDenHodin.TabIndex = 52;
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
            this.comboBoxPrvniDenHodin.Location = new System.Drawing.Point(302, 236);
            this.comboBoxPrvniDenHodin.Name = "comboBoxPrvniDenHodin";
            this.comboBoxPrvniDenHodin.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPrvniDenHodin.TabIndex = 51;
            // 
            // labelPosledniNaCeste
            // 
            this.labelPosledniNaCeste.AutoSize = true;
            this.labelPosledniNaCeste.Location = new System.Drawing.Point(74, 272);
            this.labelPosledniNaCeste.Name = "labelPosledniNaCeste";
            this.labelPosledniNaCeste.Size = new System.Drawing.Size(222, 13);
            this.labelPosledniNaCeste.TabIndex = 54;
            this.labelPosledniNaCeste.Text = "Počet hodin na cestě poslední pracovní den:";
            // 
            // labelPrvniNaCeste
            // 
            this.labelPrvniNaCeste.AutoSize = true;
            this.labelPrvniNaCeste.Location = new System.Drawing.Point(74, 236);
            this.labelPrvniNaCeste.Name = "labelPrvniNaCeste";
            this.labelPrvniNaCeste.Size = new System.Drawing.Size(206, 13);
            this.labelPrvniNaCeste.TabIndex = 53;
            this.labelPrvniNaCeste.Text = "Počet hodin na cestě první pracovní den:";
            // 
            // dtpKonecCesty
            // 
            this.dtpKonecCesty.Location = new System.Drawing.Point(201, 183);
            this.dtpKonecCesty.Name = "dtpKonecCesty";
            this.dtpKonecCesty.Size = new System.Drawing.Size(200, 20);
            this.dtpKonecCesty.TabIndex = 50;
            // 
            // labelKonecCesty
            // 
            this.labelKonecCesty.AutoSize = true;
            this.labelKonecCesty.Location = new System.Drawing.Point(74, 184);
            this.labelKonecCesty.Name = "labelKonecCesty";
            this.labelKonecCesty.Size = new System.Drawing.Size(112, 13);
            this.labelKonecCesty.TabIndex = 59;
            this.labelKonecCesty.Text = "Konec služební cesty:";
            // 
            // dtpZacatekCesty
            // 
            this.dtpZacatekCesty.Location = new System.Drawing.Point(201, 154);
            this.dtpZacatekCesty.Name = "dtpZacatekCesty";
            this.dtpZacatekCesty.Size = new System.Drawing.Size(200, 20);
            this.dtpZacatekCesty.TabIndex = 49;
            // 
            // labelZacatekCesty
            // 
            this.labelZacatekCesty.AutoSize = true;
            this.labelZacatekCesty.Location = new System.Drawing.Point(74, 155);
            this.labelZacatekCesty.Name = "labelZacatekCesty";
            this.labelZacatekCesty.Size = new System.Drawing.Size(121, 13);
            this.labelZacatekCesty.TabIndex = 58;
            this.labelZacatekCesty.Text = "Začátek služební cesty:";
            // 
            // textBoxDatNar
            // 
            this.textBoxDatNar.Location = new System.Drawing.Point(166, 99);
            this.textBoxDatNar.Name = "textBoxDatNar";
            this.textBoxDatNar.Size = new System.Drawing.Size(100, 20);
            this.textBoxDatNar.TabIndex = 48;
            // 
            // labelDatNar
            // 
            this.labelDatNar.AutoSize = true;
            this.labelDatNar.Location = new System.Drawing.Point(74, 102);
            this.labelDatNar.Name = "labelDatNar";
            this.labelDatNar.Size = new System.Drawing.Size(86, 13);
            this.labelDatNar.TabIndex = 57;
            this.labelDatNar.Text = "Datum narození:";
            // 
            // textBoxPrijmeni
            // 
            this.textBoxPrijmeni.Location = new System.Drawing.Point(166, 70);
            this.textBoxPrijmeni.Name = "textBoxPrijmeni";
            this.textBoxPrijmeni.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrijmeni.TabIndex = 47;
            // 
            // labelPrijmeni
            // 
            this.labelPrijmeni.AutoSize = true;
            this.labelPrijmeni.Location = new System.Drawing.Point(74, 75);
            this.labelPrijmeni.Name = "labelPrijmeni";
            this.labelPrijmeni.Size = new System.Drawing.Size(51, 13);
            this.labelPrijmeni.TabIndex = 56;
            this.labelPrijmeni.Text = "Příjmení:";
            // 
            // textBoxJmeno
            // 
            this.textBoxJmeno.Location = new System.Drawing.Point(166, 43);
            this.textBoxJmeno.Name = "textBoxJmeno";
            this.textBoxJmeno.Size = new System.Drawing.Size(100, 20);
            this.textBoxJmeno.TabIndex = 46;
            // 
            // labelJmeno
            // 
            this.labelJmeno.AutoSize = true;
            this.labelJmeno.Location = new System.Drawing.Point(74, 46);
            this.labelJmeno.Name = "labelJmeno";
            this.labelJmeno.Size = new System.Drawing.Size(41, 13);
            this.labelJmeno.TabIndex = 55;
            this.labelJmeno.Text = "Jméno:";
            // 
            // Udaje1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "Udaje1";
            this.Size = new System.Drawing.Size(532, 393);
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
    }
}
