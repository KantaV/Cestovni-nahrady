namespace Cestovni_nahrady
{
    partial class UdajeOsobni
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
            this.dtpDatumKonceCesty = new System.Windows.Forms.DateTimePicker();
            this.labelKonecCesty = new System.Windows.Forms.Label();
            this.dtpDatumZacatkuCesty = new System.Windows.Forms.DateTimePicker();
            this.labelZacatekCesty = new System.Windows.Forms.Label();
            this.labelDatNar = new System.Windows.Forms.Label();
            this.textBoxPrijmeni = new System.Windows.Forms.TextBox();
            this.labelPrijmeni = new System.Windows.Forms.Label();
            this.textBoxJmeno = new System.Windows.Forms.TextBox();
            this.labelJmeno = new System.Windows.Forms.Label();
            this.dateTimePickerDatNar = new System.Windows.Forms.DateTimePicker();
            this.dtpCasZacatkuCesty = new System.Windows.Forms.DateTimePicker();
            this.dtpCasKonceCesty = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dtpDatumKonceCesty
            // 
            this.dtpDatumKonceCesty.Location = new System.Drawing.Point(235, 241);
            this.dtpDatumKonceCesty.Name = "dtpDatumKonceCesty";
            this.dtpDatumKonceCesty.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumKonceCesty.TabIndex = 50;
            this.dtpDatumKonceCesty.ValueChanged += new System.EventHandler(this.dtpDatumKonceCesty_ValueChanged);
            // 
            // labelKonecCesty
            // 
            this.labelKonecCesty.AutoSize = true;
            this.labelKonecCesty.Location = new System.Drawing.Point(74, 247);
            this.labelKonecCesty.Name = "labelKonecCesty";
            this.labelKonecCesty.Size = new System.Drawing.Size(145, 13);
            this.labelKonecCesty.TabIndex = 59;
            this.labelKonecCesty.Text = "Konec služební cesty (v ČR):";
            // 
            // dtpDatumZacatkuCesty
            // 
            this.dtpDatumZacatkuCesty.Location = new System.Drawing.Point(235, 149);
            this.dtpDatumZacatkuCesty.Name = "dtpDatumZacatkuCesty";
            this.dtpDatumZacatkuCesty.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumZacatkuCesty.TabIndex = 49;
            this.dtpDatumZacatkuCesty.ValueChanged += new System.EventHandler(this.dtpDatumZacatkuCesty_ValueChanged);
            // 
            // labelZacatekCesty
            // 
            this.labelZacatekCesty.AutoSize = true;
            this.labelZacatekCesty.Location = new System.Drawing.Point(74, 155);
            this.labelZacatekCesty.Name = "labelZacatekCesty";
            this.labelZacatekCesty.Size = new System.Drawing.Size(154, 13);
            this.labelZacatekCesty.TabIndex = 58;
            this.labelZacatekCesty.Text = "Začátek služební cesty (v ČR):";
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
            // dateTimePickerDatNar
            // 
            this.dateTimePickerDatNar.Location = new System.Drawing.Point(166, 96);
            this.dateTimePickerDatNar.Name = "dateTimePickerDatNar";
            this.dateTimePickerDatNar.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDatNar.TabIndex = 60;
            // 
            // dtpCasZacatkuCesty
            // 
            this.dtpCasZacatkuCesty.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCasZacatkuCesty.Location = new System.Drawing.Point(235, 175);
            this.dtpCasZacatkuCesty.Name = "dtpCasZacatkuCesty";
            this.dtpCasZacatkuCesty.Size = new System.Drawing.Size(200, 20);
            this.dtpCasZacatkuCesty.TabIndex = 61;
            this.dtpCasZacatkuCesty.ValueChanged += new System.EventHandler(this.dtpCasZacatkuCesty_ValueChanged);
            // 
            // dtpCasKonceCesty
            // 
            this.dtpCasKonceCesty.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCasKonceCesty.Location = new System.Drawing.Point(235, 267);
            this.dtpCasKonceCesty.Name = "dtpCasKonceCesty";
            this.dtpCasKonceCesty.Size = new System.Drawing.Size(200, 20);
            this.dtpCasKonceCesty.TabIndex = 62;
            this.dtpCasKonceCesty.ValueChanged += new System.EventHandler(this.dtpCasKonceCesty_ValueChanged);
            // 
            // UdajeOsobni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpCasKonceCesty);
            this.Controls.Add(this.dtpCasZacatkuCesty);
            this.Controls.Add(this.dateTimePickerDatNar);
            this.Controls.Add(this.dtpDatumKonceCesty);
            this.Controls.Add(this.labelKonecCesty);
            this.Controls.Add(this.dtpDatumZacatkuCesty);
            this.Controls.Add(this.labelZacatekCesty);
            this.Controls.Add(this.labelDatNar);
            this.Controls.Add(this.textBoxPrijmeni);
            this.Controls.Add(this.labelPrijmeni);
            this.Controls.Add(this.textBoxJmeno);
            this.Controls.Add(this.labelJmeno);
            this.Name = "UdajeOsobni";
            this.Size = new System.Drawing.Size(532, 393);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelKonecCesty;
        private System.Windows.Forms.Label labelZacatekCesty;
        private System.Windows.Forms.Label labelDatNar;
        private System.Windows.Forms.Label labelPrijmeni;
        private System.Windows.Forms.Label labelJmeno;
        public System.Windows.Forms.DateTimePicker dtpDatumKonceCesty;
        public System.Windows.Forms.DateTimePicker dtpDatumZacatkuCesty;
        public System.Windows.Forms.TextBox textBoxPrijmeni;
        public System.Windows.Forms.TextBox textBoxJmeno;
        public System.Windows.Forms.DateTimePicker dateTimePickerDatNar;
        public System.Windows.Forms.DateTimePicker dtpCasZacatkuCesty;
        public System.Windows.Forms.DateTimePicker dtpCasKonceCesty;
    }
}
