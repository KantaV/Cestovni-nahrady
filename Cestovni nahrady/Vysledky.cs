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
    public partial class Vysledky : UserControl
    {
        public Vysledky()
        {
            InitializeComponent();
            Vygeneruj(labelNadpisUzivetele);
        }

        public Vysledky(bool jeVysledek)
        {
            InitializeComponent();
            VygenerujPosledni(labelNadpisUzivetele);
        }

        Panel panelUzivatele;

        public void Vygeneruj(Label labelNadpis)
        {
            int i = 0;
            try
            {
                using (FileStream fs = new FileStream("uzivatele.dat", FileMode.Open, FileAccess.Read))
                {
                    BinaryReader br = new BinaryReader(fs);
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        panelUzivatele = new Panel();
                        panelUzivatele.Height = 200;
                        panelUzivatele.AutoSize= true;
                        panelUzivatele.Location = new Point(50,100+ (i *250));

                        Label labelNadpisVysledek = new Label();
                        labelNadpisVysledek.AutoSize = true;
                        labelNadpisVysledek.Text = "Výpočet č." + (i + 1);
                        labelNadpisVysledek.Font = new Font(labelNadpisVysledek.Font.FontFamily, 14, FontStyle.Bold | FontStyle.Underline);
                        labelNadpisVysledek.Location = new Point(0, 0);

                        Label labelJmeno = new Label();
                        labelJmeno.AutoSize = true;
                        labelJmeno.Text = "Jméno: " + br.ReadString();
                        labelJmeno.Location = new Point(0, 40);

                        Label labelPrijmeni = new Label();
                        labelPrijmeni.AutoSize = true;
                        labelPrijmeni.Text = "Příjmení: " + br.ReadString();
                        labelPrijmeni.Location = new Point(0, 60 );

                        Label labelDatNar = new Label();
                        labelDatNar.AutoSize = true;
                        labelDatNar.Text = "Datum narození: " + br.ReadString();
                        labelDatNar.Location = new Point(0, 80);

                        Label labelTuzemskaCesta = new Label();
                        labelTuzemskaCesta.AutoSize = true;
                        if (br.ReadBoolean()) labelTuzemskaCesta.Text = "Tuzemská cesta: Ano";
                        else labelTuzemskaCesta.Text = "Tuzemská cesta: Ne";
                        labelTuzemskaCesta.Location = new Point(0, 100 );

                        Label labelCenaZaTuzCestu = new Label();
                        labelCenaZaTuzCestu.AutoSize = true;
                        labelCenaZaTuzCestu.Text = "Cena za tuzemskou cestu: " + br.ReadDouble() + " Kč";
                        labelCenaZaTuzCestu.Location = new Point(0, 120 );

                        Label labelCenaZaZahCestu = new Label();
                        labelCenaZaZahCestu.AutoSize = true;
                        labelCenaZaZahCestu.Text = "Cena za zahraniční cestu: " + br.ReadDouble()+" Kč";
                        labelCenaZaZahCestu.Location = new Point(0, 140 );

                        Label labelNavstivStaty = new Label();
                        labelNavstivStaty.AutoSize = true;
                        labelNavstivStaty.Text = "Navštívené zahraniční státy: " + br.ReadString();
                        labelNavstivStaty.Location = new Point(0, 160 );

                        Label labelCenaCelkem = new Label();
                        labelCenaCelkem.AutoSize = true;
                        labelCenaCelkem.Text = "Celková cena: " + br.ReadDouble()+" Kč";
                        labelCenaCelkem.Location = new Point(0, 180  );
                        ++i;

                        panelUzivatele.Controls.Add(labelNadpisVysledek);
                        panelUzivatele.Controls.Add(labelJmeno);
                        panelUzivatele.Controls.Add(labelPrijmeni);
                        panelUzivatele.Controls.Add(labelDatNar);
                        panelUzivatele.Controls.Add(labelTuzemskaCesta);
                        panelUzivatele.Controls.Add(labelCenaZaTuzCestu);
                        panelUzivatele.Controls.Add(labelCenaZaZahCestu);
                        panelUzivatele.Controls.Add(labelNavstivStaty);
                        panelUzivatele.Controls.Add(labelCenaCelkem);

                        this.Controls.Add(panelUzivatele);
                    }
                }

                labelNadpis.Text = "Výsledky";
            }
            catch (FileNotFoundException)
            {
                labelNadpis.Text = "Zatím žádné výsledky";
            }
           
       
        }

        public void VymazVse(out bool byloSmazano)
        {
            AnoNeDialog vymazVseDialog = new AnoNeDialog("Opravdu si přejete vymazat vše?");
            vymazVseDialog.Text = "Vymazat vše";
            if (vymazVseDialog.ShowDialog() == DialogResult.OK)
            {
                byloSmazano = true;
                File.Delete("uzivatele.dat");
            }
            else byloSmazano = false;
        }

        public void VygenerujPosledni(Label labelNadpis)
        {
            try
            {
                using (FileStream fs = new FileStream("uzivatele.dat", FileMode.Open, FileAccess.Read))
                {
                    BinaryReader br = new BinaryReader(fs);

                    int pocetVysledku = 0;
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        br.ReadString();    //Jmeno
                        br.ReadString();    //Prijemni  
                        br.ReadString();    //Datum narozeni
                        br.ReadBoolean();   //Jedna se o tuzemskou cestu
                        br.ReadDouble();    //Cena tuz cesta
                        br.ReadDouble();    //Cena zahr cesta
                        br.ReadString();    //Navstivene staty
                        br.ReadDouble();    //Celkem cena
                        ++pocetVysledku;
                    }

                    br.BaseStream.Position = 0;
                    int i = 0;
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        if (i == pocetVysledku - 1)
                        {
                            panelUzivatele = new Panel();
                            panelUzivatele.Height = 200;
                            panelUzivatele.AutoSize = true;
                            panelUzivatele.Location = new Point(50, 100);

                            Label labelJmeno = new Label();
                            labelJmeno.AutoSize = true;
                            labelJmeno.Text = "Jméno: " + br.ReadString();
                            labelJmeno.Location = new Point(0, 0);

                            Label labelPrijmeni = new Label();
                            labelPrijmeni.AutoSize = true;
                            labelPrijmeni.Text = "Příjmení: " + br.ReadString();
                            labelPrijmeni.Location = new Point(0, 20);

                            Label labelDatNar = new Label();
                            labelDatNar.AutoSize = true;
                            labelDatNar.Text = "Datum narození: " + br.ReadString();
                            labelDatNar.Location = new Point(0, 40);

                            Label labelTuzemskaCesta = new Label();
                            labelTuzemskaCesta.AutoSize = true;
                            if (br.ReadBoolean()) labelTuzemskaCesta.Text = "Tuzemská cesta: Ano";
                            else labelTuzemskaCesta.Text = "Tuzemská cesta: Ne";
                            labelTuzemskaCesta.Location = new Point(0, 60);

                            Label labelCenaZaTuzCestu = new Label();
                            labelCenaZaTuzCestu.AutoSize = true;
                            labelCenaZaTuzCestu.Text = "Cena za tuzemskou cestu: " + br.ReadDouble() + " Kč";
                            labelCenaZaTuzCestu.Location = new Point(0, 80);

                            Label labelCenaZaZahCestu = new Label();
                            labelCenaZaZahCestu.AutoSize = true;
                            labelCenaZaZahCestu.Text = "Cena za zahraniční cestu: " + br.ReadDouble() + " Kč";
                            labelCenaZaZahCestu.Location = new Point(0, 100);

                            Label labelNavstivStaty = new Label();
                            labelNavstivStaty.AutoSize = true;
                            labelNavstivStaty.Text = "Navštívené zahraniční státy: " + br.ReadString();
                            labelNavstivStaty.Location = new Point(0, 120);

                            Label labelCenaCelkem = new Label();
                            labelCenaCelkem.AutoSize = true;
                            labelCenaCelkem.Text = "Celková cena: " + br.ReadDouble() + " Kč";
                            labelCenaCelkem.Location = new Point(0, 140);

                            panelUzivatele.Controls.Add(labelJmeno);
                            panelUzivatele.Controls.Add(labelPrijmeni);
                            panelUzivatele.Controls.Add(labelDatNar);
                            panelUzivatele.Controls.Add(labelTuzemskaCesta);
                            panelUzivatele.Controls.Add(labelCenaZaTuzCestu);
                            panelUzivatele.Controls.Add(labelCenaZaZahCestu);
                            panelUzivatele.Controls.Add(labelNavstivStaty);
                            panelUzivatele.Controls.Add(labelCenaCelkem);

                            this.Controls.Add(panelUzivatele);
                        }
                        else
                        {
                            br.ReadString();    //Jmeno
                            br.ReadString();    //Prijemni  
                            br.ReadString();    //Datum narozeni
                            br.ReadBoolean();   //Jedna se o tuzemskou cestu
                            br.ReadDouble();    //Cena tuz cesta
                            br.ReadDouble();    //Cena zahr cesta
                            br.ReadString();    //Navstivene staty
                            br.ReadDouble();    //Celkem cena
                        }
                        ++i;
                    }
                    labelNadpis.Text = "Výsledek"; 
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }
    }
}
