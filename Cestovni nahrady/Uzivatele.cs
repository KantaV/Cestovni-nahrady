using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cestovni_nahrady
{
    public partial class Uzivatele : UserControl
    {
        public Uzivatele()
        {
            InitializeComponent();
            Vygeneruj();
        }

        Panel panelUzivatele;

        public void Vygeneruj()
        {
            try
            {
                using (FileStream fs = new FileStream("uzivatele.dat", FileMode.Open, FileAccess.Read))
                {
                    BinaryReader br = new BinaryReader(fs);
                    int i = 0;
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        panelUzivatele = new Panel();
                        panelUzivatele.Height = 300;
                        panelUzivatele.Location = new Point(50, 100 + (i * 400));

                        Label labelJmeno = new Label();
                        labelJmeno.AutoSize = true;
                        labelJmeno.Text = "Jméno: " + br.ReadString();
                        labelJmeno.Location = new Point(0, 0 + (i * 35));

                        Label labelPrijmeni = new Label();
                        labelPrijmeni.AutoSize = true;
                        labelPrijmeni.Text = "Příjmení: " + br.ReadString();
                        labelPrijmeni.Location = new Point(0, 30 + (i * 35));

                        Label labelTuzemskaCesta = new Label();
                        labelTuzemskaCesta.AutoSize = true;
                        if (br.ReadBoolean()) labelTuzemskaCesta.Text = "Tuzemská cesta: Ano";
                        else labelTuzemskaCesta.Text = "Tuzemská cesta: Ne";
                        labelTuzemskaCesta.Location = new Point(0, 60 + (i * 35));

                        Label labelCenaZaTuzCestu = new Label();
                        labelCenaZaTuzCestu.AutoSize = true;
                        labelCenaZaTuzCestu.Text = "Cena za tuzemskou cestu: " + br.ReadDouble();
                        labelCenaZaTuzCestu.Location = new Point(0, 90 + (i * 35));

                        Label labelCenaZaZahCestu = new Label();
                        labelCenaZaZahCestu.AutoSize = true;
                        labelCenaZaZahCestu.Text = "Cena za zahraniční cestu: " + br.ReadDouble();
                        labelCenaZaZahCestu.Location = new Point(0, 120 + (i * 35));

                        Label labelNavstivStaty = new Label();
                        labelNavstivStaty.AutoSize = true;
                        labelNavstivStaty.Text = "Navštívené státy: " + br.ReadString();
                        labelNavstivStaty.Location = new Point(0, 150 + (i * 35));

                        Label labelCenaCelkem = new Label();
                        labelCenaCelkem.AutoSize = true;
                        labelCenaCelkem.Text = "Celková cena: " + br.ReadDouble();
                        labelCenaCelkem.Location = new Point(0, 180 + (i * 35));
                        ++i;

                        panelUzivatele.Controls.Add(labelJmeno);
                        panelUzivatele.Controls.Add(labelPrijmeni);
                        panelUzivatele.Controls.Add(labelTuzemskaCesta);
                        panelUzivatele.Controls.Add(labelCenaZaTuzCestu);
                        panelUzivatele.Controls.Add(labelCenaZaZahCestu);
                        panelUzivatele.Controls.Add(labelNavstivStaty);
                        panelUzivatele.Controls.Add(labelCenaCelkem);

                        this.Controls.Add(panelUzivatele);
                    }
                }
            }
            catch (Exception)
            {
                
            }
           
       
        }
    }
}
