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
                        labelJmeno.Text = "Jméno a příjmení: " + br.ReadString()+" "+br.ReadString();
                        labelJmeno.Location = new Point(0, 40);

                        Label labelDatNar = new Label();
                        labelDatNar.AutoSize = true;
                        labelDatNar.Text = "Datum narození: " + br.ReadString();
                        labelDatNar.Location = new Point(0, 60 );

                        Label labelDatPrijezdOdjezd = new Label();
                        labelDatPrijezdOdjezd.AutoSize = true;
                        labelDatPrijezdOdjezd.Text = "Datum odjezdu - datum příjezdu: " + br.ReadString()+" - "+br.ReadString()+" (Počet dní: "+br.ReadInt32()+")";
                        labelDatPrijezdOdjezd.Location = new Point(0, 80);

                        Label labelNavstivStaty = new Label();
                        labelNavstivStaty.AutoSize = true;
                        labelNavstivStaty.Text = "Navštívené zahraniční státy: " + br.ReadString();
                        labelNavstivStaty.Location = new Point(0, 100);



                        Label labelSektor=new Label();
                        labelSektor.AutoSize = true;
                        if(br.ReadString()=="privatni") labelSektor.Text = "Sektor: privátní," + (br.ReadBoolean() ? " byla poskytnuta strava" : " nebyla poskytnuta strava");
                        else labelSektor.Text = "Sektor: veřejný," + (br.ReadBoolean() ? " byla poskytnuta strava" : " nebyla poskytnuta strava");
                        labelSektor.Location = new Point(0, 160);

                        Label labelCenaZaTuzemskouCestu= new Label();
                        labelCenaZaTuzemskouCestu.AutoSize = true;
                        labelCenaZaTuzemskouCestu.Text = "Cena za tuzemskou cestu: " + br.ReadDouble()+" Kč";
                        labelCenaZaTuzemskouCestu.Location = new Point(0, 180);

                        Label labelCenaZaZahCestu = new Label();
                        labelCenaZaZahCestu.AutoSize = true;
                        labelCenaZaZahCestu.Text = "Cena za zahraniční cestu: " + br.ReadDouble()+" Kč";
                        labelCenaZaZahCestu.Location = new Point(0, 200 );

                    
                        Label labelCenaCelkem = new Label();
                        labelCenaCelkem.AutoSize = true;
                        labelCenaCelkem.Text = "Celková cena: " + br.ReadDouble()+" Kč";
                        labelCenaCelkem.Location = new Point(0, 220  );
                        ++i;

                        panelUzivatele.Controls.Add(labelNadpisVysledek);
                        panelUzivatele.Controls.Add(labelJmeno);
                        panelUzivatele.Controls.Add(labelDatNar);
                        panelUzivatele.Controls.Add(labelDatPrijezdOdjezd);
                        panelUzivatele.Controls.Add(labelNavstivStaty);
                        panelUzivatele.Controls.Add(labelSektor);
                        panelUzivatele.Controls.Add(labelCenaZaTuzemskouCestu);
                        panelUzivatele.Controls.Add(labelCenaZaZahCestu);
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
                        br.ReadString();    //Zacatek cesty
                        br.ReadString();    //Konec cesty
                        br.ReadInt32();    //Delka cesty
                        br.ReadString();    //Navstivene staty
                        br.ReadString();
                        br.ReadBoolean();
                        br.ReadDouble();
                        br.ReadDouble();
                        br.ReadDouble();
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
                            panelUzivatele.Location = new Point(50, 70);

                            Label labelJmeno = new Label();
                            labelJmeno.AutoSize = true;
                            labelJmeno.Text = "Jméno a příjmení: " + br.ReadString() + " " + br.ReadString();
                            labelJmeno.Location = new Point(0, 40);

                            Label labelDatNar = new Label();
                            labelDatNar.AutoSize = true;
                            labelDatNar.Text = "Datum narození: " + br.ReadString();
                            labelDatNar.Location = new Point(0, 60);

                            Label labelDatPrijezdOdjezd = new Label();
                            labelDatPrijezdOdjezd.AutoSize = true;
                            labelDatPrijezdOdjezd.Text = "Datum odjezdu - datum příjezdu: " + br.ReadString() + " - " + br.ReadString() + " (Počet dní: " + br.ReadInt32() + ")";
                            labelDatPrijezdOdjezd.Location = new Point(0, 80);

                            Label labelVypocetSpotreba = new Label();
                            labelVypocetSpotreba.AutoSize = true;
                            labelVypocetSpotreba.Text = "Spotřebováno * cena za litr/kw: " + br.ReadDouble() + " * " + br.ReadDouble() + " = " + br.ReadDouble();
                            labelVypocetSpotreba.Location = new Point(0, 140);

                            Label labelSektor = new Label();
                            labelSektor.AutoSize = true;
                            if (br.ReadString() == "privatni") labelSektor.Text = "Sektor: privátní," + (br.ReadBoolean() ? " byla poskytnuta strava" : " nebyla poskytnuta strava");
                            else labelSektor.Text = "Sektor: veřejný," + (br.ReadBoolean() ? " byla poskytnuta strava" : " nebyla poskytnuta strava");
                            labelSektor.Location = new Point(0, 160);

                            Label labelCenaZaTuzemskouCestu = new Label();
                            labelCenaZaTuzemskouCestu.AutoSize = true;
                            labelCenaZaTuzemskouCestu.Text = "Cena za tuzemskou cestu: " + br.ReadDouble() + " Kč";
                            labelCenaZaTuzemskouCestu.Location = new Point(0, 180);

                            Label labelCenaZaZahCestu = new Label();
                            labelCenaZaZahCestu.AutoSize = true;
                            labelCenaZaZahCestu.Text = "Cena za zahraniční cestu: " + br.ReadDouble() + " Kč";
                            labelCenaZaZahCestu.Location = new Point(0, 200);


                            Label labelCenaCelkem = new Label();
                            labelCenaCelkem.AutoSize = true;
                            labelCenaCelkem.Text = "Celková cena: " + br.ReadDouble() + " Kč";
                            labelCenaCelkem.Location = new Point(0, 220);
                            ++i;

                            panelUzivatele.Controls.Add(labelJmeno);
                            panelUzivatele.Controls.Add(labelDatNar);
                            panelUzivatele.Controls.Add(labelDatPrijezdOdjezd);
                            panelUzivatele.Controls.Add(labelVypocetSpotreba);
                            panelUzivatele.Controls.Add(labelSektor);
                            panelUzivatele.Controls.Add(labelCenaZaTuzemskouCestu);
                            panelUzivatele.Controls.Add(labelCenaZaZahCestu);
                            panelUzivatele.Controls.Add(labelCenaCelkem);

                            this.Controls.Add(panelUzivatele);
                        }
                        else
                        {
                            br.ReadString();    //Jmeno
                            br.ReadString();    //Prijemni  
                            br.ReadString();    //Datum narozeni
                            br.ReadString();    //Zacatek cesty
                            br.ReadString();    //Konec cesty
                            br.ReadInt32();    //Delka cesty
                            br.ReadString();    //Navstivene staty
                            br.ReadString();
                            br.ReadBoolean();
                            br.ReadDouble();
                            br.ReadDouble();
                            br.ReadDouble();
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
