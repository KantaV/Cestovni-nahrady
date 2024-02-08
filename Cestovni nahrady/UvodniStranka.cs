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
            uzivatele = new Uzivatele();
            this.Controls.Add(uzivatele);
            uzivatele.Hide();
        }

        private UserControl[] stranky = new UserControl[4];

        private UdajeOsobni udajeOsobni;
        private UdajeOZahranicniCeste udajeZahranicniCesta;
        private UdajePohonneHmoty udajePohonneHmoty;
        private UdajeStravne udajeStravne;
        private Nastaveni nastaveni;
        private Uzivatele uzivatele;

        private int indexStranky = 0;

        public void CasVeState(Panel panel, out string nazevZeme, out DateTime datumPrijezdu,out DateTime datumOdjezdu)
        {
            nazevZeme = "";
            TimeSpan cas = TimeSpan.Zero;
            datumPrijezdu = DateTime.Now;
            datumOdjezdu = DateTime.Now;
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
                            datumPrijezdu = (panel.Controls[i] as DateTimePicker).Value;
                            break;
                        case 2:
                            casPrijezdu = (panel.Controls[i] as DateTimePicker).Value;
                            break;
                        case 3:
                            datumOdjezdu = (panel.Controls[i] as DateTimePicker).Value;
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
            datumPrijezdu = new DateTime(datumPrijezdu.Year, datumPrijezdu.Month, datumPrijezdu.Day, prijezduTime.Hours, prijezduTime.Minutes, prijezduTime.Seconds);
            datumOdjezdu = new DateTime(datumOdjezdu.Year, datumOdjezdu.Month, datumOdjezdu.Day, odjezduTime.Hours, odjezduTime.Minutes, odjezduTime.Seconds);

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

        private void buttonUzivatele_Click(object sender, EventArgs e)
        {
            uzivatele=new Uzivatele();
            this.Controls.Add(uzivatele);
            panelMenu.Hide();
            panelNavigacniBtny.Show();
            buttonDalsi.Hide();
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
            if (uzivatele.Visible)
            {
                panelMenu.Show();
                uzivatele.Hide();
                panelNavigacniBtny.Hide();
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


        private void buttonDalsi_Click(object sender, EventArgs e)
        {
            if (nastaveni.Visible)  //Funkce pro ulozeni nastaveni
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
                if (indexStranky == stranky.Length - 2)
                {
                    //Aktivuje se při příchodu na poslední stránku
                    zacatekCesty = udajeOsobni.dtpDatumZacatkuCesty.Value.Date + udajeOsobni.dtpCasZacatkuCesty.Value.TimeOfDay;
                    konecCesty = udajeOsobni.dtpDatumKonceCesty.Value.Date + udajeOsobni.dtpCasKonceCesty.Value.TimeOfDay;
                    delkaCesty = konecCesty - zacatekCesty;
                    //Spočítání délky cesty abych získal počet dní
                    udajeStravne.Vygeneruj(delkaCesty.Days+1);
                    //Změna textu buttonu
                    buttonDalsi.Text = "Vypočítej";
                }
                //Postarání se o samotné stránky
                if (indexStranky < stranky.Length - 1)
                {
                    stranky[indexStranky].Hide();
                    ++indexStranky;
                    stranky[indexStranky].Show();
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

                        bool tuzemskaCesta = true;

                        NavstivenyStat[] navstiveneStaty = new NavstivenyStat[udajeZahranicniCesta.pocet];
                        //Ošetření počet států
                        if (udajeZahranicniCesta.numericUpDownPocetZemi.Value > 0)
                        {
                            tuzemskaCesta = false;
                            //Zjistim kazdy navstiveny stat a delku pobytu v nem
                            for (int i = 0; i < udajeZahranicniCesta.zahranici.Controls.Count; i++)
                            {

                                string nazevZeme = "";
                                DateTime prijezdDoZeme= DateTime.Now,odjezdZeZeme=DateTime.Now;
                                TimeSpan casVeState = TimeSpan.Zero;
                                if (udajeZahranicniCesta.zahranici.Controls[i] is Panel) CasVeState((udajeZahranicniCesta.zahranici.Controls[i] as Panel), out nazevZeme,out prijezdDoZeme, out odjezdZeZeme);
                                string[] stringUdajeOState = nazevZeme.Split(' ');
                                navstiveneStaty[i] = new NavstivenyStat(stringUdajeOState[0],int.Parse(stringUdajeOState[stringUdajeOState.Length-2]),stringUdajeOState[stringUdajeOState.Length-1],prijezdDoZeme,odjezdZeZeme);
                                MessageBox.Show(navstiveneStaty[i].NazevStatu + " " + navstiveneStaty[i].CasVeState) ;
                            }
                        }


                        //Rozdělení sektoru
                        string sektor;
                        if (udajeStravne.comboBoxStravneSektor.SelectedIndex == 0) sektor = "privatni";
                        else sektor = "verejny";

                        double najetychKm = double.Parse(udajePohonneHmoty.textBoxPocetNajetychKm.Text);

                        PohonneHmoty pohonnaHmota = new PohonneHmoty(udajePohonneHmoty.comboBoxTypPohonnychHmot.Text, double.Parse(udajePohonneHmoty.numericUpDownSpotreba.Value.ToString()));

                        int[] jidelZaDen;
                        jidelZaDen = new int[delkaCesty.Days + 1];
                        int pocetNalezenychNumericUpDownu = 0;
                        //Naplnim pole jidel za den, kazdy index pole je jeden den
                        for (int i = 0; i < udajeStravne.jidlaZaDen1.Controls.Count; i++)
                        {
                            if (udajeStravne.jidlaZaDen1.Controls[i] is NumericUpDown)
                            {
                                jidelZaDen[pocetNalezenychNumericUpDownu] = int.Parse((udajeStravne.jidlaZaDen1.Controls[i] as NumericUpDown).Value.ToString());
                                pocetNalezenychNumericUpDownu++;
                            }
                        }

                        //Finální výpočty
                        double cenaZaPohonneHmoty = 0;
                        double zkratit = 0;
                        if (tuzemskaCesta)
                        {
                            //Účtuji pohonné hmoty jedině pokud zaměstnanec cestoval svým vozem
                            if (udajePohonneHmoty.comboBoxZpusobPrepravy.SelectedIndex != 0)
                            {
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
                                //Podle zákona
                                if (udajePohonneHmoty.comboBoxZpsbVypoctuPohHmot.SelectedIndex == 0)
                                {
                                    cenaZaPohonneHmoty += pohonnaHmota.CenaZaPohonneHmoty();
                                    //MessageBox.Show(vyplatitPenez.ToString());
                                }
                                else  //Podle účtenky
                                {
                                    double prumerCenaZUctenek = double.Parse(udajePohonneHmoty.textBoxPrumernaPohonneHmotyCena.Text);
                                    cenaZaPohonneHmoty += prumerCenaZUctenek * pohonnaHmota.Spotrebovano;
                                    //MessageBox.Show(vyplatitPenez.ToString());
                                }
                            }
                            double cenaZaStravne= CenaZaTuzemskouCestu(zacatekCesty, konecCesty, sektor, jidelZaDen, priSekt5az12,
                                priSekt12az18, priSekt18aVic, verSekt5az12, verSekt12az18, verSekt18aVic);
                            MessageBox.Show("Proplatit" + cenaZaPohonneHmoty+cenaZaStravne);

                        }
                        else //Zahraniční cesta
                        {
                            TimeSpan casNezOpustilCesko = navstiveneStaty[0].DatumPrijezdu-zacatekCesty;
                            //Nez dojede do zahranici
                            double cenaZaTuzemskeSttavne = CenaZaTuzemskouCestu(zacatekCesty, navstiveneStaty[0].DatumPrijezdu, sektor,
                                jidelZaDen,priSekt5az12,priSekt12az18,priSekt18aVic,verSekt5az12,verSekt12az18,verSekt18aVic);
                            int denCelkove = casNezOpustilCesko.Days;
                            int hodinPrvniDen = 0;
                            int hodinPosledniDen = 0;
                            double cenaZaZahranicniStravne = 0;


                            //Vypocet mozna neni presny idk nesedi to podle kalkulacky z internetu
                            for (int i = 0; i < navstiveneStaty.Length; i++)
                            {
                                if (navstiveneStaty[i].DatumPrijezdu.Date == navstiveneStaty[i].DatumOdjezdu.Date)  //Pokud se jedna o jednodenni cestu
                                {
                                    hodinPrvniDen = navstiveneStaty[i].DatumOdjezdu.Hour - navstiveneStaty[i].DatumPrijezdu.Hour;
                                    hodinPosledniDen = 0;
                                }
                                else     //Cesta delsi nez 1 den
                                {
                                    hodinPrvniDen = 24 - navstiveneStaty[i].DatumPrijezdu.Hour;
                                    hodinPosledniDen = navstiveneStaty[i].DatumOdjezdu.Hour;
                                }

                                double zakladniSazba;
                                int den = 0;            //ZKRACOVANI ZATIM NEBUDE FUNGOVAT!!
                                do
                                {
                                    if (den == 0)   //Při prvním dni
                                    {
                                        if (hodinPrvniDen > 18)
                                        {
                                            zakladniSazba = navstiveneStaty[i].CenaZaDenVeStatePrevedeno;
                                            zkratit = jidelZaDen[den] * 0.25;    //pri rozsahu 18 a vice hodin se za kazde jidlo odecita 
                                            if (zkratit > 1) zkratit = 1;       //25% stravneho
                                            cenaZaZahranicniStravne += zakladniSazba - zakladniSazba * zkratit;
                                        }
                                        else if (hodinPrvniDen > 12)
                                        {
                                            zakladniSazba = navstiveneStaty[i].CenaZaDenVeStatePrevedeno*(2/3);

                                            zkratit = jidelZaDen[den] * 0.35;    //pri rozsahu 12 az 18 hodin se za kazde jidlo odecita 
                                            if (zkratit > 1) zkratit = 1;       //35% stravneho
                                            cenaZaZahranicniStravne += zakladniSazba - zakladniSazba * zkratit;
                                        }
                                        else if (hodinPrvniDen > 1)
                                        {
                                            zakladniSazba = navstiveneStaty[i].CenaZaDenVeStatePrevedeno*(1/3);
                                            zkratit = jidelZaDen[den] * 0.7;    //pri rozsahu 5 az 12 hodin se za kazde jidlo odecita 
                                            if (zkratit > 1) zkratit = 1;       //70% stravneho
                                            cenaZaZahranicniStravne += zakladniSazba - zakladniSazba * zkratit;
                                        }
                                    }
                                    else if (den == navstiveneStaty[i].CasVeState.Days) //Při posledním dni, pouze pokud je více dní
                                    {
                                        if (hodinPosledniDen > 18)
                                        {
                                            zakladniSazba = navstiveneStaty[i].CenaZaDenVeStatePrevedeno;
                                            zkratit = jidelZaDen[den] * 0.25;    //pri rozsahu 18 a vice hodin se za kazde jidlo odecita 
                                            if (zkratit > 1) zkratit = 1;       //25% stravneho
                                            cenaZaZahranicniStravne += zakladniSazba - zakladniSazba * zkratit;
                                        }
                                        else if (hodinPosledniDen > 12)
                                        {
                                            zakladniSazba = navstiveneStaty[i].CenaZaDenVeStatePrevedeno * (2 / 3);
                                            zkratit = jidelZaDen[den] * 0.35;    //pri rozsahu 12 az 18 hodin se za kazde jidlo odecita 
                                            if (zkratit > 1) zkratit = 1;       //35% stravneho
                                            cenaZaZahranicniStravne += zakladniSazba - zakladniSazba * zkratit;
                                        }
                                        else if (hodinPosledniDen > 5)
                                        {
                                            zakladniSazba = navstiveneStaty[i].CenaZaDenVeStatePrevedeno * (1 / 3);
                                            zkratit = jidelZaDen[den] * 0.7;    //pri rozsahu 5 az 12 hodin se za kazde jidlo odecita 
                                            if (zkratit > 1) zkratit = 1;       //70% stravneho
                                            cenaZaZahranicniStravne += zakladniSazba - zakladniSazba * zkratit;
                                        }
                                    }
                                    else    //Všechny ostatní "mezidny" (každý automaticky trvá 24 hodin)
                                    {
                                        zakladniSazba = navstiveneStaty[i].CenaZaDenVeStatePrevedeno;
                                        zkratit = jidelZaDen[den] * 0.25;    //pri rozsahu 18 a vice hodin se za kazde jidlo odecita 
                                        if (zkratit > 1) zkratit = 1;       //25% stravneho
                                        cenaZaZahranicniStravne += zakladniSazba - zakladniSazba * zkratit;
                                    }
                                    ++den;      //Posunu den
                                } while (den < navstiveneStaty[i].CasVeState.Days + 1);
                            }
                            MessageBox.Show(cenaZaZahranicniStravne.ToString());

                            //Pote co bude dojizdet ze zahranici
                            cenaZaTuzemskeSttavne += CenaZaTuzemskouCestu(navstiveneStaty[navstiveneStaty.Length-1].DatumOdjezdu, konecCesty, sektor,
                            jidelZaDen, priSekt5az12, priSekt12az18, priSekt18aVic, verSekt5az12, verSekt12az18, verSekt18aVic);

                        }
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
