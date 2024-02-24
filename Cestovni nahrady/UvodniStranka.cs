using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cestovni_nahrady
{
    public partial class UvodniStranka : Form
    {
        public UvodniStranka()
        {
            InitializeComponent();
            panelNavigacniBtny.Hide();
            //Nastavení musím inicializovat zde abych s ním mohl pracovat i pokud nastavení nebylo otevřeno
            nastaveni = new Nastaveni();
            this.Controls.Add(nastaveni);
            nastaveni.Hide();
            vysledky = new Vysledky();
            this.Controls.Add(vysledky);
            vysledky.Hide();
        }

        private UserControl[] stranky = new UserControl[4];

        private UdajeOsobni udajeOsobni;
        private UdajeOZahranicniCeste udajeZahranicniCesta;
        private UdajePohonneHmoty udajePohonneHmoty;
        private UdajeStravne udajeStravne;
        private Nastaveni nastaveni;
        private Vysledky vysledky;

        private int indexStranky = 0;

        public void CasVeState(Panel panel, out string nazevZeme, out DateTime datumCasPrijezdu,out DateTime datumCasOdjezdu)
        {
            nazevZeme = "";
            datumCasPrijezdu = DateTime.Now;
            datumCasOdjezdu = DateTime.Now;
            DateTime casPrijezdu = DateTime.Now, casOdjezdu = DateTime.Now;
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                //rozdelim si data protoze vim v jakem poradi jsem ovladaci prvky pridal tudiz s nimi podle toho mohu pracovat
                if (panel.Controls[i] is ComboBox) nazevZeme = (panel.Controls[i] as ComboBox).Text;
                if (panel.Controls[i] is DateTimePicker)
                {
                    switch (i)
                    {
                        case 1:
                            datumCasPrijezdu = (panel.Controls[i] as DateTimePicker).Value;
                            break;
                        case 2:
                            casPrijezdu = (panel.Controls[i] as DateTimePicker).Value;
                            break;
                        case 3:
                            datumCasOdjezdu = (panel.Controls[i] as DateTimePicker).Value;
                            break;
                        case 4:
                            casOdjezdu = (panel.Controls[i] as DateTimePicker).Value;
                            break;
                        default:
                            break;
                    }
                }
            }



            TimeSpan prijezduTime = casPrijezdu.TimeOfDay;
            TimeSpan odjezduTime = casOdjezdu.TimeOfDay;

            //spojím čas i data s obou proměnných
            datumCasPrijezdu = new DateTime(datumCasPrijezdu.Year, datumCasPrijezdu.Month, datumCasPrijezdu.Day, prijezduTime.Hours, prijezduTime.Minutes, prijezduTime.Seconds);
            datumCasOdjezdu = new DateTime(datumCasOdjezdu.Year, datumCasOdjezdu.Month, datumCasOdjezdu.Day, odjezduTime.Hours, odjezduTime.Minutes, odjezduTime.Seconds);

            /* MessageBox.Show(nazevZeme+"\n" +
                 "prijezd " +datumPrijezdu+
                 "\ncas prijezd "+casPrijezdu+
                 "\nodjezd "+datumOdjezdu+
                 "\ncas odjezd "+casOdjezdu);*/
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            //Inicializace jednotlivych stranek a nastrkani jich do pole
            udajeOsobni = new UdajeOsobni();
            stranky[0] = udajeOsobni;
            this.Controls.Add(stranky[0]);
            stranky[0].Hide();

            udajeZahranicniCesta = new UdajeOZahranicniCeste();
            stranky[1] = udajeZahranicniCesta;
            this.Controls.Add(stranky[1]);
            stranky[1].Hide();

            udajePohonneHmoty = new UdajePohonneHmoty();
            stranky[2] = udajePohonneHmoty;
            this.Controls.Add(stranky[2]);
            stranky[2].Hide();

            udajeStravne = new UdajeStravne();
            stranky[3] = udajeStravne;
            this.Controls.Add(stranky[3]);
            stranky[3].Hide();

            //Schovat menu
            panelMenu.Hide();
            stranky[indexStranky].Show();
            panelNavigacniBtny.Show();

        }

        private void buttonSpocitaneCesty_Click(object sender, EventArgs e)
        {
            vysledky = new Vysledky();
            this.Controls.Add(vysledky);
            vysledky.Show();
            panelMenu.Hide();
            panelNavigacniBtny.Show();
            buttonDalsi.Text = "Vymazat vše";
        }

        private void buttonNastaveni_Click(object sender, EventArgs e)
        {
            nastaveni = new Nastaveni();
            this.Controls.Add(nastaveni);
            panelMenu.Hide();
            nastaveni.Show();
            buttonDalsi.Text = "Uložit";
            panelNavigacniBtny.Show();
        }

        private void buttonZpet_Click(object sender, EventArgs e)
        {
            if (vysledky.Visible)
            {
                panelMenu.Show();
                vysledky.Hide();
                panelNavigacniBtny.Hide();
                buttonDalsi.Text = "Další";
                buttonDalsi.Show();
            }
            else if (nastaveni.Visible)  //Funkce buttonu pro obsluhovani nastaveni
            {
                nastaveni.Hide();
                panelNavigacniBtny.Hide();
                buttonDalsi.Text = "Další";
                panelMenu.Show();
            }
            else        //Funkce buttonu pro obsluhovani udajovych stranek
            {
                //Změna textu buttonu
                if (buttonDalsi.Text != "Další") buttonDalsi.Text = "Další";
                //Postarání se o samotné stránky
                stranky[indexStranky].Hide();
                if (indexStranky > 0)
                {
                    --indexStranky;
                    stranky[indexStranky].Show();
                }
                else
                {
                    panelNavigacniBtny.Hide();
                    panelMenu.Show();
                }
            }
         
        }

        private double priSekt5az12;
        private double priSekt12az18;
        private double priSekt18aVic;

        private double verSekt5az12;
        private double verSekt12az18;
        private double verSekt18aVic;

        private DateTime zacatekCesty;
        private DateTime konecCesty;
        private TimeSpan delkaCesty;

        NavstivenyStat[] navstiveneStaty;
        bool tuzemskaCesta = true;
        bool dataJsouSpravne = true;

        private void buttonDalsi_Click(object sender, EventArgs e)
        {
            if(vysledky.Visible)
            {
                vysledky.VymazVse();
            }
            else if (nastaveni.Visible)  //Funkce pro ulozeni nastaveni
            {

                //Zapsat nastaveni do souboru aby hodnoty zustaly i po vypnuti aplikace
                using (FileStream fs = new FileStream("nastaveni.dat", FileMode.Create, FileAccess.Write))
                {
                    BinaryWriter bw = new BinaryWriter(fs);
                    //Privatni
                    bw.Write((double)nastaveni.numericupordown5az12Priv.Value);
                    bw.Write((double)nastaveni.numericUpDown12az18Priv.Value);
                    bw.Write((double)nastaveni.numericUpDown18aVicePriv.Value);
                    //Verejny
                    bw.Write((double)nastaveni.numericUp5az12Ver.Value);
                    bw.Write((double)nastaveni.numericUp12az18Ver.Value);
                    bw.Write((double)nastaveni.numericUp18aViceVer.Value);
                }
                
                //Update rozhrani
                nastaveni.Hide();
                panelNavigacniBtny.Hide();
                buttonDalsi.Text = "Další";
                panelMenu.Show();
            }
            else                //Pro obsluhovani vypoctu a udajovych stranek
            {
                dataJsouSpravne = true;
                if (indexStranky == 0)
                {
                    //Aktivuje se při příchodu na druhou stránku
                    zacatekCesty = udajeOsobni.dtpDatumZacatkuCesty.Value.Date + udajeOsobni.dtpCasZacatkuCesty.Value.TimeOfDay;
                    konecCesty = udajeOsobni.dtpDatumKonceCesty.Value.Date + udajeOsobni.dtpCasKonceCesty.Value.TimeOfDay;
                    udajeZahranicniCesta.labelCelkZacatekCesty.Text ="Celkový začátek cesty: "+ zacatekCesty.ToString();
                    udajeZahranicniCesta.labelCelkKonecCesty.Text ="Celkový konec cesty: "+ konecCesty.ToString();
                }
                else if (indexStranky ==1)
                {
                    //Aktivuje se při příchodu na třetí stránku
                    navstiveneStaty = new NavstivenyStat[udajeZahranicniCesta.pocet];
                    //Ošetření počet států
                    if (udajeZahranicniCesta.numericUpDownPocetZemi.Value > 0)
                    {
                        tuzemskaCesta = false;
                        string nazevZeme = "";
                        DateTime prijezdDoZeme = DateTime.Now, odjezdZeZeme = DateTime.Now;
                        if (udajeZahranicniCesta.zahranici.Controls[0] is Panel) CasVeState((udajeZahranicniCesta.zahranici.Controls[0] as Panel), out nazevZeme, out prijezdDoZeme, out odjezdZeZeme);
                        string[] stringUdajeOState = nazevZeme.Split(' ');
                        navstiveneStaty[0] = new NavstivenyStat(stringUdajeOState[0], int.Parse(stringUdajeOState[stringUdajeOState.Length - 2]), stringUdajeOState[stringUdajeOState.Length - 1], prijezdDoZeme, odjezdZeZeme);
                        MessageBox.Show(navstiveneStaty[0].NazevStatu + " " + navstiveneStaty[0].CasVeState);

                        //Otestuju příjezd do první zahraniční země
                        if (zacatekCesty > navstiveneStaty[0].DatumCasPrijedzu)
                        {
                            dataJsouSpravne = false;
                            MessageBox.Show("Datum příjezdu do země " + navstiveneStaty[0].NazevStatu + " nemůže být před ÚPLNÝM začátkem cesty!");
                        }

                        //Zjistim kazdy navstiveny stat a delku pobytu v nem
                        for (int i = 1; i < udajeZahranicniCesta.zahranici.Controls.Count; i++)
                        {
                            nazevZeme = "";
                            prijezdDoZeme = DateTime.Now;
                            odjezdZeZeme = DateTime.Now;
                            if (udajeZahranicniCesta.zahranici.Controls[i] is Panel) CasVeState((udajeZahranicniCesta.zahranici.Controls[i] as Panel), out nazevZeme, out prijezdDoZeme, out odjezdZeZeme);
                            stringUdajeOState = nazevZeme.Split(' ');
                            navstiveneStaty[i] = new NavstivenyStat(stringUdajeOState[0], int.Parse(stringUdajeOState[stringUdajeOState.Length - 2]), stringUdajeOState[stringUdajeOState.Length - 1], prijezdDoZeme, odjezdZeZeme);
                            if (!navstiveneStaty[i].UdajeJsouSpravne) dataJsouSpravne = false;
                            if (navstiveneStaty[i - 1].DatumCasOdjezdu > navstiveneStaty[i].DatumCasPrijedzu)
                            {
                                dataJsouSpravne = false;
                                MessageBox.Show("Příjezd do " + navstiveneStaty[i].NazevStatu + " nemůže být před odjezdem z " + navstiveneStaty[i - 1].NazevStatu);
                            }
                            
                            MessageBox.Show(navstiveneStaty[i].NazevStatu + " " + navstiveneStaty[i].CasVeState);
                        }

                        //Otestuju odjezd z poslední zahraniční země
                        if (konecCesty < navstiveneStaty[navstiveneStaty.Length-1].DatumCasOdjezdu)
                        {
                            dataJsouSpravne = false;
                            MessageBox.Show("Datum odjezdu ze země " + navstiveneStaty[navstiveneStaty.Length-1].NazevStatu + " nemůže být po ÚPLNÉM konci cesty!");
                        }
                    }
                }
                else if (indexStranky == 2)
                {
                    //Aktivuje se při příchodu na poslední stránku

                    delkaCesty = konecCesty - zacatekCesty;
                    //Spočítání délky cesty abych získal počet dní
                    udajeStravne.Vygeneruj(delkaCesty.Days+1);
                    //Změna textu buttonu
                    buttonDalsi.Text = "Vypočítej";
                }

                if (indexStranky < stranky.Length - 1)
                {
                    //Testuji zda jdou data zadána správně a pokud ne, nepustím uživatele dál
                    if (dataJsouSpravne)
                    {
                        stranky[indexStranky].Hide();
                        ++indexStranky;
                        stranky[indexStranky].Show();
                    }
                }
                else
                {
                    //Zde bude celý kód výpočtů
                    try
                    {
                        //Načtení proběhne podle hodnot v souboru
                        using (FileStream fs = new FileStream("nastaveni.dat", FileMode.Open, FileAccess.Read))
                        {
                            BinaryReader br = new BinaryReader(fs);
                            //Privatni sektor
                            priSekt5az12 =br.ReadDouble();
                            priSekt12az18 = br.ReadDouble();
                            priSekt18aVic = br.ReadDouble();
                            //Verejny sektor
                            verSekt5az12 = br.ReadDouble();
                            verSekt12az18 = br.ReadDouble();
                            verSekt18aVic = br.ReadDouble();
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        //Pokud soubor neexistuje např byl smazán vytvoří se nový s původními hodnotami
                        using (FileStream fs = new FileStream("nastaveni.dat", FileMode.Create, FileAccess.Write))
                        {
                            BinaryWriter bw = new BinaryWriter(fs);
                            //Hodnoty pro privatni sektor
                            bw.Write(129.0);
                            bw.Write(196.0);
                            bw.Write(307.0);
                            //Hodnoty pro verejny sektor
                            bw.Write(129.0);
                            bw.Write(196.0);
                            bw.Write(307.0);
                        }
                        priSekt5az12 = 129;
                        priSekt12az18 = 196;
                        priSekt18aVic = 307;

                        verSekt5az12 = 129;
                        verSekt12az18 = 196;
                        verSekt18aVic = 307;
                    }

                    try
                    {
                        //Osobní údaje
                        string jmeno = udajeOsobni.textBoxJmeno.Text;
                        string prijmeni = udajeOsobni.textBoxPrijmeni.Text;
                        DateTime datNar = udajeOsobni.dateTimePickerDatNar.Value;


                        //Rozdělení sektoru
                        string sektor;
                        if (udajeStravne.comboBoxStravneSektor.SelectedIndex == 0) sektor = "privatni";
                        else sektor = "verejny";

                        PohonneHmoty pohonnaHmota;
                        int[] jidelZaDen;
                        jidelZaDen = new int[delkaCesty.Days + 1];
                        int pocetNalezenychNumericUpDownu = 0;
                        //Naplnim pole jidel za den, kazdy index pole je jeden den
                        for (int i = 0; i < udajeStravne.jidlaZaDen1.Controls.Count; i++)
                        {
                            if (udajeStravne.jidlaZaDen1.Controls[i] is NumericUpDown)
                            {
                                if (udajeStravne.checkBoxBezplatneJidlo.Checked) jidelZaDen[pocetNalezenychNumericUpDownu] = int.Parse((udajeStravne.jidlaZaDen1.Controls[i] as NumericUpDown).Value.ToString());
                                else jidelZaDen[pocetNalezenychNumericUpDownu] = 0;
                                pocetNalezenychNumericUpDownu++;
                            }
                        }

                        //Finální výpočty
                        double cenaZaPohonneHmoty = 0;
                        double zkratit = 0;
                        string staty="";
                        double cenaZaTuzemskouCestu=0;
                        double cenaZaZahranicniStravne=0;
                        if (tuzemskaCesta)
                        {
                            //Účtuji pohonné hmoty jedině pokud zaměstnanec cestoval svým vozem
                            if (udajePohonneHmoty.comboBoxZpusobPrepravy.SelectedIndex != 0)
                            {
                                double najetychKm = double.Parse(udajePohonneHmoty.textBoxPocetNajetychKm.Text);

                                //Podle zákona
                                if (udajePohonneHmoty.comboBoxZpsbVypoctuPohHmot.SelectedIndex == 0)
                                {
                                    pohonnaHmota = new PohonneHmoty(udajePohonneHmoty.comboBoxTypPohonnychHmot.Text,
                                    double.Parse(udajePohonneHmoty.numericUpDownSpotreba.Value.ToString()));
                                }
                                else  //Podle účtenky
                                {
                                    pohonnaHmota = new PohonneHmoty(double.Parse(udajePohonneHmoty.numericUpDownSpotreba.Value.ToString()),
                                    double.Parse(udajePohonneHmoty.textBoxPrumernaPohonneHmotyCena.Text));
                                }
                                double zakladniNahrada = 5.6;
                                switch (udajePohonneHmoty.comboBoxZpusobPrepravy.SelectedIndex)
                                {
                                    case 1: //Vlastní automobil
                                        {
                                            cenaZaPohonneHmoty += zakladniNahrada * najetychKm;
                                            break;
                                        }
                                    case 2: //Vlastní automobil s přívěsem
                                        {
                                            cenaZaPohonneHmoty += (zakladniNahrada * 1.15) * najetychKm;
                                            break;
                                        }
                                    case 3: //Vlastní motorkou
                                        {
                                            cenaZaPohonneHmoty += 1.4 * najetychKm;
                                            break;
                                        }
                                    case 4: //Vlastním nákladním vozem, autobusem, traktorem
                                        {
                                            cenaZaPohonneHmoty += (zakladniNahrada * 2) * najetychKm;
                                            break;
                                        }
                                    default:
                                        MessageBox.Show("Chyba");
                                        break;
                                }
                                cenaZaPohonneHmoty += pohonnaHmota.CenaZaPohonneHmoty();
                                //MessageBox.Show(cenaZaPohonneHmoty.ToString());
                            }
                            double cenaZaStravne= CenaZaTuzemskouCestu(zacatekCesty, konecCesty, sektor, jidelZaDen, priSekt5az12,
                                priSekt12az18, priSekt18aVic, verSekt5az12, verSekt12az18, verSekt18aVic);
                            //MessageBox.Show("Proplatit" + cenaZaPohonneHmoty+cenaZaStravne);
                            cenaZaTuzemskouCestu = cenaZaPohonneHmoty + cenaZaStravne;

                            try
                            {
                                using (FileStream fs = new FileStream("uzivatele.dat", FileMode.Append, FileAccess.Write))
                                {
                                    BinaryWriter bw = new BinaryWriter(fs);
                                    bw.Write(jmeno);
                                    bw.Write(prijmeni);
                                    bw.Write(datNar.Date.ToString("d.M.yyyy"));
                                    bw.Write(tuzemskaCesta);
                                    bw.Write(cenaZaTuzemskouCestu);
                                    bw.Write((double)0);
                                    bw.Write("Žádné");
                                    double cenaCelkem = cenaZaTuzemskouCestu + cenaZaZahranicniStravne;
                                    bw.Write(cenaCelkem);
                                }
                            }
                            catch (FileNotFoundException)
                            {
                                using (FileStream fs = new FileStream("uzivatele.dat", FileMode.Create, FileAccess.Write))
                                {
                                    BinaryWriter bw = new BinaryWriter(fs);
                                    bw.Write(jmeno);
                                    bw.Write(prijmeni);
                                    bw.Write(datNar.Date.ToString("d.M.yyyy"));
                                    bw.Write(tuzemskaCesta);
                                    bw.Write(cenaZaTuzemskouCestu);
                                    bw.Write((double)0);
                                    bw.Write("Žádné");
                                    double cenaCelkem = cenaZaTuzemskouCestu + cenaZaZahranicniStravne;
                                    bw.Write(cenaCelkem);
                                }
                            }

                        }
                        else //Zahraniční cesta
                        {
                            TimeSpan casNezOpustilCesko = navstiveneStaty[0].DatumCasPrijedzu-zacatekCesty;
                            //Nez dojede do zahranici
                            cenaZaTuzemskouCestu = CenaZaTuzemskouCestu(zacatekCesty, navstiveneStaty[0].DatumCasPrijedzu, sektor,
                                jidelZaDen,priSekt5az12,priSekt12az18,priSekt18aVic,verSekt5az12,verSekt12az18,verSekt18aVic);

                            int denCelkove = casNezOpustilCesko.Days;
                            int hodinPrvniDen = 0;
                            int hodinPosledniDen = 0;
                            cenaZaZahranicniStravne = 0;


                            for (int i = 0; i < navstiveneStaty.Length; i++)
                            {
                                if (navstiveneStaty[i].DatumCasPrijedzu.Date == navstiveneStaty[i].DatumCasOdjezdu.Date)  //Pokud se jedna o jednodenni cestu
                                {
                                    hodinPrvniDen = navstiveneStaty[i].DatumCasOdjezdu.Hour - navstiveneStaty[i].DatumCasPrijedzu.Hour;
                                    hodinPosledniDen = 0;
                                }
                                else     //Cesta delsi nez 1 den
                                {
                                    hodinPrvniDen = 24 - navstiveneStaty[i].DatumCasPrijedzu.Hour;
                                    hodinPosledniDen = navstiveneStaty[i].DatumCasOdjezdu.Hour;
                                }
                                double zakladniSazba=0;
                                int den = 0;            
                                zkratit = 0;
                                bool posledniDen;
                                do
                                {
                                    posledniDen = false;
                                    if (den == 0)   //Při prvním dni
                                    {
                                        if (hodinPrvniDen >= 18)
                                        {
                                            zakladniSazba = navstiveneStaty[i].CenaZaDenVeStatePrevedeno;
                                            zkratit = jidelZaDen[denCelkove] * 0.25;    //pri rozsahu 18 a vice hodin se za kazde jidlo odecita 
                                            if (zkratit > 1) zkratit = 1;       //25% stravneho
                                            cenaZaZahranicniStravne += zakladniSazba - zakladniSazba * zkratit;
                                        }
                                        else if (hodinPrvniDen >= 12)
                                        {
                                            zakladniSazba = navstiveneStaty[i].CenaZaDenVeStatePrevedeno*((double)2 /3);

                                            zkratit = jidelZaDen[denCelkove] * 0.35;    //pri rozsahu 12 az 18 hodin se za kazde jidlo odecita 
                                            if (zkratit > 1) zkratit = 1;       //35% stravneho
                                            cenaZaZahranicniStravne += zakladniSazba - zakladniSazba * zkratit;
                                        }
                                        else if (hodinPrvniDen >= 1)
                                        {
                                            zakladniSazba = navstiveneStaty[i].CenaZaDenVeStatePrevedeno*((double)1/3);
                                            zkratit = jidelZaDen[denCelkove] * 0.7;    //pri rozsahu 5 az 12 hodin se za kazde jidlo odecita 
                                            if(zkratit > 1) zkratit = 1;       //70% stravneho
                                            cenaZaZahranicniStravne += zakladniSazba - zakladniSazba * zkratit;
                                        }
                                    }
                                    else if (den == navstiveneStaty[i].CasVeState.Days) //Při posledním dni, pouze pokud je více dní
                                    {
                                        posledniDen = true;
                                        if (hodinPosledniDen >= 18)
                                        {
                                            zakladniSazba = navstiveneStaty[i].CenaZaDenVeStatePrevedeno;
                                            zkratit = jidelZaDen[denCelkove] * 0.25;    //pri rozsahu 18 a vice hodin se za kazde jidlo odecita 
                                            if (zkratit > 1) zkratit = 1;       //25% stravneho
                                            cenaZaZahranicniStravne += zakladniSazba - zakladniSazba * zkratit;
                                        }
                                        else if (hodinPosledniDen >= 12)
                                        {
                                            zakladniSazba = navstiveneStaty[i].CenaZaDenVeStatePrevedeno * ((double)2 / 3);
                                            zkratit = jidelZaDen[denCelkove] * 0.35;    //pri rozsahu 12 az 18 hodin se za kazde jidlo odecita 
                                            if (zkratit > 1) zkratit = 1;       //35% stravneho
                                            cenaZaZahranicniStravne += zakladniSazba - zakladniSazba * zkratit;
                                        }
                                        else if (hodinPosledniDen >= 1)
                                        {
                                            zakladniSazba = navstiveneStaty[i].CenaZaDenVeStatePrevedeno * ((double)1 / 3);
                                            zkratit = jidelZaDen[denCelkove] * 0.7;    //pri rozsahu 5 az 12 hodin se za kazde jidlo odecita 
                                            if (zkratit > 1) zkratit = 1;       //70% stravneho
                                            cenaZaZahranicniStravne += zakladniSazba - zakladniSazba * zkratit;
                                        }
                                    }
                                    else    //Všechny ostatní "mezidny" (každý automaticky trvá 24 hodin)
                                    {
                                        zakladniSazba = navstiveneStaty[i].CenaZaDenVeStatePrevedeno;
                                        zkratit = jidelZaDen[denCelkove] * 0.25;    //pri rozsahu 18 a vice hodin se za kazde jidlo odecita 
                                        if (zkratit > 1) zkratit = 1;       //25% stravneho
                                        cenaZaZahranicniStravne += zakladniSazba - zakladniSazba * zkratit;
                                    }
                                    if (!posledniDen)
                                    {
                                        ++den;      //Posunu den ale jen pokud není poslední protože pokud je poslední, potřebuji si toto datum ještě nechat  
                                        ++denCelkove; //pro vykonání cesty v jiném státě ve zbytku tohoto dne
                                    }

                                } while (den < navstiveneStaty[i].CasVeState.Days + 1&&!posledniDen);
                            }
                           //MessageBox.Show(cenaZaZahranicniStravne.ToString());

                            //Pote co bude dojizdet ze zahranici
                            cenaZaTuzemskouCestu += CenaZaTuzemskouCestu(navstiveneStaty[navstiveneStaty.Length-1].DatumCasOdjezdu, konecCesty, sektor,
                            jidelZaDen, priSekt5az12, priSekt12az18, priSekt18aVic, verSekt5az12, verSekt12az18, verSekt18aVic);

                            staty = "";
                            foreach (NavstivenyStat stat in navstiveneStaty)
                            {
                                staty+= stat.NazevStatu+", ";
                            }
                            char[] koncoveZnaky = { ' ', ',' };
                            staty = staty.Trim(koncoveZnaky);


                            try
                            {
                                using (FileStream fs = new FileStream("uzivatele.dat", FileMode.Append, FileAccess.Write))
                                {
                                    BinaryWriter bw = new BinaryWriter(fs);
                                    bw.Write(jmeno);
                                    bw.Write(prijmeni);
                                    bw.Write(datNar.Date.ToString("d.M.yyyy"));
                                    bw.Write(tuzemskaCesta);
                                    bw.Write(cenaZaTuzemskouCestu);
                                    bw.Write(cenaZaZahranicniStravne);
                                    bw.Write(staty);
                                    double cenaCelkem = cenaZaTuzemskouCestu + cenaZaZahranicniStravne;
                                    bw.Write(cenaCelkem);
                                }
                            }
                            catch (FileNotFoundException)
                            {
                                using (FileStream fs = new FileStream("uzivatele.dat", FileMode.Create, FileAccess.Write))
                                {
                                    BinaryWriter bw = new BinaryWriter(fs);
                                    bw.Write(jmeno);
                                    bw.Write(prijmeni);
                                    bw.Write(datNar.Date.ToString("d.M.yyyy"));
                                    bw.Write(tuzemskaCesta);
                                    bw.Write(cenaZaTuzemskouCestu);
                                    bw.Write(cenaZaZahranicniStravne);
                                    bw.Write(staty);
                                    double cenaCelkem = cenaZaTuzemskouCestu + cenaZaZahranicniStravne;
                                    bw.Write(cenaCelkem);
                                }
                            }
                        }

                        stranky[indexStranky].Hide();
                        indexStranky = 0;
                        vysledky = new Vysledky(true);
                        this.Controls.Add(vysledky);
                        vysledky.Show();
                        panelMenu.Hide();
                        panelNavigacniBtny.Show();
                        buttonDalsi.Hide();
                        buttonDalsi.Text = "Další";

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }

                }
            }

           
        }

        private double CenaZaTuzemskouCestu(DateTime zacatekTuzemskeCesty,
           DateTime konecTuzemskeCesty, string sektor, int[] jidelZaDen,
           double priSekt5az12,double priSekt12az18, double priSekt18aVic,
           double verSekt5az12, double verSekt12az18, double verSekt18aVic)
        {
            //Stravne
            TimeSpan delkaCesty = konecTuzemskeCesty - zacatekTuzemskeCesty;
            int hodinPrvniDen = 0;
            int hodinPosledniDen = 0;
            double vyplatitPenez = 0;
            if (delkaCesty.TotalHours < 24) //Pokud cesta netrva pres 24 hodin ale neni v jeden den
            {
                hodinPrvniDen = delkaCesty.Hours;
                //MessageBox.Show(hodinPrvniDen.ToString());
            }
            else if (zacatekTuzemskeCesty.Date == konecTuzemskeCesty.Date)  //Pokud se jedna o jednodenni cestu
            {
                hodinPrvniDen = konecTuzemskeCesty.Hour - zacatekTuzemskeCesty.Hour;
                hodinPosledniDen = 0;
            }
            else                    //Cesta delsi nez 1 den
            {
                hodinPrvniDen = 24 - zacatekTuzemskeCesty.Hour;
                hodinPosledniDen = konecTuzemskeCesty.Hour;
            }


            int den = 0;
            double zkratit = 0;
            do
            {
                if (sektor == "privatni") //Privatni sektor
                {
                    if (den == 0)   //Při prvním dni
                    {
                        if (hodinPrvniDen >= 18)
                        {
                            zkratit = jidelZaDen[den] * 0.25;    //pri rozsahu 18 a vice hodin se za kazde jidlo odecita 
                            if (zkratit > 1) zkratit = 1;       //25% stravneho
                            vyplatitPenez += priSekt18aVic - priSekt18aVic * zkratit;
                        }
                        else if (hodinPrvniDen >= 12)
                        {
                            zkratit = jidelZaDen[den] * 0.35;    //pri rozsahu 12 az 18 hodin se za kazde jidlo odecita 
                            if (zkratit > 1) zkratit = 1;       //35% stravneho
                            vyplatitPenez += priSekt12az18 - priSekt12az18 * zkratit;
                        }
                        else if (hodinPrvniDen >= 5)
                        {
                            zkratit = jidelZaDen[den] * 0.7;    //pri rozsahu 5 az 12 hodin se za kazde jidlo odecita 
                            if (zkratit > 1) zkratit = 1;       //70% stravneho
                            vyplatitPenez += priSekt5az12 - priSekt5az12 * zkratit;
                        }
                    }
                    else if (den == delkaCesty.Days) //Při posledním dni, pouze pokud je více dní
                    {
                        if (hodinPosledniDen >= 18)
                        {
                            zkratit = jidelZaDen[den] * 0.25;    //pri rozsahu 18 a vice hodin se za kazde jidlo odecita 
                            if (zkratit > 1) zkratit = 1;       //25% stravneho
                            vyplatitPenez += priSekt18aVic - priSekt18aVic * zkratit;
                        }
                        else if (hodinPosledniDen >= 12)
                        {
                            zkratit = jidelZaDen[den] * 0.35;    //pri rozsahu 12 az 18 hodin se za kazde jidlo odecita 
                            if (zkratit > 1) zkratit = 1;       //35% stravneho
                            vyplatitPenez += priSekt12az18 - priSekt12az18 * zkratit;
                        }
                        else if (hodinPosledniDen >= 5)
                        {
                            zkratit = jidelZaDen[den] * 0.7;    //pri rozsahu 5 az 12 hodin se za kazde jidlo odecita 
                            if (zkratit > 1) zkratit = 1;       //70% stravneho
                            vyplatitPenez += priSekt5az12 - priSekt5az12 * zkratit;
                        }
                    }
                    else    //Všechny ostatní "mezidny" (každý automaticky trvá 24 hodin)
                    {
                        zkratit = jidelZaDen[den] * 0.25;    //pri rozsahu 18 a vice hodin se za kazde jidlo odecita 
                        if (zkratit > 1) zkratit = 1;       //25% stravneho
                        vyplatitPenez += priSekt18aVic - priSekt18aVic * zkratit;
                    }

                }
                else     //Verejny sektor
                {
                    if (den == 0)   //Při prvním dni
                    {
                        if (hodinPrvniDen >= 18)
                        {
                            zkratit = jidelZaDen[den] * 0.25;    //pri rozsahu 18 a vice hodin se za kazde jidlo odecita 
                            if (zkratit > 1) zkratit = 1;       //25% stravneho
                            vyplatitPenez += verSekt18aVic - verSekt18aVic * zkratit;
                        }
                        else if (hodinPrvniDen >= 12)
                        {
                            zkratit = jidelZaDen[den] * 0.35;    //pri rozsahu 12 az 18 hodin se za kazde jidlo odecita 
                            if (zkratit > 1) zkratit = 1;       //35% stravneho
                            vyplatitPenez += verSekt12az18 - verSekt12az18 * zkratit;
                        }
                        else if (hodinPrvniDen >= 5)
                        {
                            zkratit = jidelZaDen[den] * 0.7;    //pri rozsahu 5 az 12 hodin se za kazde jidlo odecita 
                            if (zkratit > 1) zkratit = 1;       //70% stravneho
                            vyplatitPenez += verSekt5az12 - verSekt5az12 * zkratit;
                        }
                    }
                    else if (den == delkaCesty.Days) //Při posledním dni, pouze pokud je více dní
                    {
                        if (hodinPosledniDen >= 18)
                        {
                            zkratit = jidelZaDen[den] * 0.25;    //pri rozsahu 18 a vice hodin se za kazde jidlo odecita 
                            if (zkratit > 1) zkratit = 1;       //25% stravneho
                            vyplatitPenez += verSekt18aVic - verSekt18aVic * zkratit;
                        }
                        else if (hodinPosledniDen >= 12)
                        {
                            zkratit = jidelZaDen[den] * 0.35;    //pri rozsahu 12 az 18 hodin se za kazde jidlo odecita 
                            if (zkratit > 1) zkratit = 1;       //35% stravneho
                            vyplatitPenez += verSekt12az18 - verSekt12az18 * zkratit;
                        }
                        else if (hodinPosledniDen >= 5)
                        {
                            zkratit = jidelZaDen[den] * 0.7;    //pri rozsahu 5 az 12 hodin se za kazde jidlo odecita 
                            if (zkratit > 1) zkratit = 1;       //70% stravneho
                            vyplatitPenez += verSekt5az12 - verSekt5az12 * zkratit;
                        }
                    }
                    else    //Všechny ostatní "mezidny" (každý automaticky trvá 24 hodin)
                    {
                        zkratit = jidelZaDen[den] * 0.25;    //pri rozsahu 18 a vice hodin se za kazde jidlo odecita 
                        if (zkratit > 1) zkratit = 1;       //25% stravneho
                        vyplatitPenez += verSekt18aVic - verSekt18aVic * zkratit;
                    }

                }
                ++den;      //Posunu den
            } while (den < delkaCesty.Days + 1);
            return vyplatitPenez;
        }







        /*
        * kam uživatel bude zadávat jednotlivé ceny z různých benzínek které navštívil protože
        * pokud navšívil více benzínek bere se pro výpočet aritmetický průměr
        * 
        * upravit max hodnotu v nastavovani u numericupanddownu
        * 
        * https://www.uctovani.net/kalkulacka-zahranicni-cesty-stravne-kapesne.php
        * https://money.cz/novinky-a-tipy/mzdy-a-personalistika/cestovni-nahrady-2022-kolik-zaplatite-kdyz-zamestnance-vyslete-na-sluzebni-cestu/
        * https://www.mfcr.cz/cs/kontrola-a-regulace/legislativa/legislativni-dokumenty/2022/vyhlaska-c-462-2021-sb-49677
        * https://blog.videolektor.cz/stravne-pri-soubehu-tuzemske-a-zahranicni-pracovni-cesty/
        * https://ppropo.mpsv.cz/XXII23Cestovninahradyprizahranic
        * https://www.behounek.eu/l/sazby-cestovnich-nahrad/
        */
    }
}
