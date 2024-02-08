namespace Cestovni_nahrady
{
    partial class Uzivatele
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
            this.labelNadpisJmeno = new System.Windows.Forms.Label();
            this.labelNadpisPrijmeni = new System.Windows.Forms.Label();
            this.labelNadpisTuzemskaCesta = new System.Windows.Forms.Label();
            this.labelNadpisCenaZaTuzemskouCestu = new System.Windows.Forms.Label();
            this.labelNadpisZahranicniCestaCena = new System.Windows.Forms.Label();
            this.labelNadpisNavstiveneStaty = new System.Windows.Forms.Label();
            this.labelNadpisCelkem = new System.Windows.Forms.Label();
            this.labelNadpisUzivetele = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNadpisJmeno
            // 
            this.labelNadpisJmeno.AutoSize = true;
            this.labelNadpisJmeno.Location = new System.Drawing.Point(50, 55);
            this.labelNadpisJmeno.Name = "labelNadpisJmeno";
            this.labelNadpisJmeno.Size = new System.Drawing.Size(41, 13);
            this.labelNadpisJmeno.TabIndex = 0;
            this.labelNadpisJmeno.Text = "Jméno:";
            // 
            // labelNadpisPrijmeni
            // 
            this.labelNadpisPrijmeni.AutoSize = true;
            this.labelNadpisPrijmeni.Location = new System.Drawing.Point(50, 77);
            this.labelNadpisPrijmeni.Name = "labelNadpisPrijmeni";
            this.labelNadpisPrijmeni.Size = new System.Drawing.Size(51, 13);
            this.labelNadpisPrijmeni.TabIndex = 1;
            this.labelNadpisPrijmeni.Text = "Příjmení:";
            // 
            // labelNadpisTuzemskaCesta
            // 
            this.labelNadpisTuzemskaCesta.AutoSize = true;
            this.labelNadpisTuzemskaCesta.Location = new System.Drawing.Point(50, 100);
            this.labelNadpisTuzemskaCesta.Name = "labelNadpisTuzemskaCesta";
            this.labelNadpisTuzemskaCesta.Size = new System.Drawing.Size(88, 13);
            this.labelNadpisTuzemskaCesta.TabIndex = 2;
            this.labelNadpisTuzemskaCesta.Text = "Tuzemská cesta:";
            // 
            // labelNadpisCenaZaTuzemskouCestu
            // 
            this.labelNadpisCenaZaTuzemskouCestu.AutoSize = true;
            this.labelNadpisCenaZaTuzemskouCestu.Location = new System.Drawing.Point(50, 122);
            this.labelNadpisCenaZaTuzemskouCestu.Name = "labelNadpisCenaZaTuzemskouCestu";
            this.labelNadpisCenaZaTuzemskouCestu.Size = new System.Drawing.Size(115, 13);
            this.labelNadpisCenaZaTuzemskouCestu.TabIndex = 3;
            this.labelNadpisCenaZaTuzemskouCestu.Text = "Tuzemská cesta cena:";
            // 
            // labelNadpisZahranicniCestaCena
            // 
            this.labelNadpisZahranicniCestaCena.AutoSize = true;
            this.labelNadpisZahranicniCestaCena.Location = new System.Drawing.Point(50, 146);
            this.labelNadpisZahranicniCestaCena.Name = "labelNadpisZahranicniCestaCena";
            this.labelNadpisZahranicniCestaCena.Size = new System.Drawing.Size(118, 13);
            this.labelNadpisZahranicniCestaCena.TabIndex = 4;
            this.labelNadpisZahranicniCestaCena.Text = "Zahraniční cesta cena:";
            // 
            // labelNadpisNavstiveneStaty
            // 
            this.labelNadpisNavstiveneStaty.AutoSize = true;
            this.labelNadpisNavstiveneStaty.Location = new System.Drawing.Point(50, 170);
            this.labelNadpisNavstiveneStaty.Name = "labelNadpisNavstiveneStaty";
            this.labelNadpisNavstiveneStaty.Size = new System.Drawing.Size(91, 13);
            this.labelNadpisNavstiveneStaty.TabIndex = 5;
            this.labelNadpisNavstiveneStaty.Text = "Navštívené státy:";
            // 
            // labelNadpisCelkem
            // 
            this.labelNadpisCelkem.AutoSize = true;
            this.labelNadpisCelkem.Location = new System.Drawing.Point(50, 195);
            this.labelNadpisCelkem.Name = "labelNadpisCelkem";
            this.labelNadpisCelkem.Size = new System.Drawing.Size(85, 13);
            this.labelNadpisCelkem.TabIndex = 6;
            this.labelNadpisCelkem.Text = "Celkem proplatit:";
            // 
            // labelNadpisUzivetele
            // 
            this.labelNadpisUzivetele.AutoSize = true;
            this.labelNadpisUzivetele.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNadpisUzivetele.Location = new System.Drawing.Point(206, 12);
            this.labelNadpisUzivetele.Name = "labelNadpisUzivetele";
            this.labelNadpisUzivetele.Size = new System.Drawing.Size(120, 29);
            this.labelNadpisUzivetele.TabIndex = 7;
            this.labelNadpisUzivetele.Text = "Uživatelé";
            // 
            // Uzivatele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelNadpisUzivetele);
            this.Controls.Add(this.labelNadpisCelkem);
            this.Controls.Add(this.labelNadpisNavstiveneStaty);
            this.Controls.Add(this.labelNadpisZahranicniCestaCena);
            this.Controls.Add(this.labelNadpisCenaZaTuzemskouCestu);
            this.Controls.Add(this.labelNadpisTuzemskaCesta);
            this.Controls.Add(this.labelNadpisPrijmeni);
            this.Controls.Add(this.labelNadpisJmeno);
            this.Name = "Uzivatele";
            this.Size = new System.Drawing.Size(532, 393);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNadpisJmeno;
        private System.Windows.Forms.Label labelNadpisPrijmeni;
        private System.Windows.Forms.Label labelNadpisTuzemskaCesta;
        private System.Windows.Forms.Label labelNadpisCenaZaTuzemskouCestu;
        private System.Windows.Forms.Label labelNadpisZahranicniCestaCena;
        private System.Windows.Forms.Label labelNadpisNavstiveneStaty;
        private System.Windows.Forms.Label labelNadpisCelkem;
        private System.Windows.Forms.Label labelNadpisUzivetele;
    }
}
