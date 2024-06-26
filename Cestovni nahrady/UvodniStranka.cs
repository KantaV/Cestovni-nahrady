﻿using System;
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
using static System.Windows.Forms.AxHost;

namespace Cestovni_nahrady
{
    public partial class UvodniStranka : Form
    {
        public UvodniStranka()
        {
            InitializeComponent();
            panelNavigacniBtny.Hide();
            //Nastavení musím inicializovat zde abych s ním mohl pracovatv kódu i pokud nastavení nebylo otevřeno
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
            //Zobrazit navigační buttony
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

        private double zakladniNahradaZa1Km;

        private DateTime zacatekCesty;
        private DateTime konecCesty;
        private TimeSpan delkaCesty;
        private int dniNaCeste;

        private NavstivenyStat[] navstiveneStaty;
        private bool tuzemskaCesta = true;
        private bool dataJsouSpravne = true;


        private void buttonDalsi_Click(object sender, EventArgs e)
        {
            if(vysledky.Visible)
            {
                bool byloSmazano;
                vysledky.VymazVse(out byloSmazano);
                if (byloSmazano)
                {
                    panelMenu.Show();
                    vysledky.Hide();
                    panelNavigacniBtny.Hide();
                    buttonDalsi.Text = "Další";
                    buttonDalsi.Show();
                }

            }
            else if (nastaveni.Visible)  //Funkce pro ulozeni nastaveni
            {
                AnoNeDialog anoNeDialog = new AnoNeDialog("Přejete si uložit data?");
                anoNeDialog.Text = "Uložit data";
                if(anoNeDialog.ShowDialog() == DialogResult.OK)
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
                        //Zakladni nahrada za 1km
                        bw.Write((double)nastaveni.numericUpDownZakladniNahrada.Value);
                    }
                }

            }
            else     //Pro obsluhovani vypoctu a udajovych stranek
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
                else if (indexStranky == 1)
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
                        string nazevStatu = nazevZeme.Substring(0, nazevZeme.Length - 7);
                        int cena = int.Parse(nazevZeme.Substring(nazevZeme.Length - 6, 2));
                        string mena = nazevZeme.Substring(nazevZeme.Length - 3, 3);
                        navstiveneStaty[0] = new NavstivenyStat(nazevStatu, cena, mena, prijezdDoZeme, odjezdZeZeme);
                        dataJsouSpravne = navstiveneStaty[0].UdajeJsouSpravne;

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
                            nazevStatu = nazevZeme.Substring(0, nazevZeme.Length - 7);
                            cena = int.Parse(nazevZeme.Substring(nazevZeme.Length - 6, 2));
                            mena = nazevZeme.Substring(nazevZeme.Length - 3, 3);
                            navstiveneStaty[i] = new NavstivenyStat(nazevStatu, cena, mena, prijezdDoZeme, odjezdZeZeme);
                            if (dataJsouSpravne) dataJsouSpravne = navstiveneStaty[i].UdajeJsouSpravne;   //podmínka aby se nemohla proměnná opravit nedobře
                            if (navstiveneStaty[i - 1].DatumCasOdjezdu > navstiveneStaty[i].DatumCasPrijedzu)
                            {
                                dataJsouSpravne = false;
                                MessageBox.Show("Příjezd do " + navstiveneStaty[i].NazevStatu + " nemůže být před odjezdem z " + navstiveneStaty[i - 1].NazevStatu);
                            }

                            //MessageBox.Show(navstiveneStaty[i].NazevStatu + " " + navstiveneStaty[i].CasVeState);
                        }

                        //Otestuju odjezd z poslední zahraniční země
                        if (konecCesty < navstiveneStaty[navstiveneStaty.Length - 1].DatumCasOdjezdu)
                        {
                            dataJsouSpravne = false;
                            MessageBox.Show("Datum odjezdu ze země " + navstiveneStaty[navstiveneStaty.Length - 1].NazevStatu + " nemůže být po ÚPLNÉM konci cesty!");
                        }
                    }
                    else tuzemskaCesta = true;
                }
                else if (indexStranky == 2)
                {
                    //Aktivuje se při příchodu na poslední stránku

                    delkaCesty = konecCesty - zacatekCesty;
                    //Spočítání délky cesty abych získal počet dní
                    if (konecCesty.TimeOfDay<zacatekCesty.TimeOfDay&&zacatekCesty.Date!=konecCesty.Date) dniNaCeste = delkaCesty.Days + 2;
                    else dniNaCeste = delkaCesty.Days+1;
                    udajeStravne.jidlaZaDen1.Vygeneruj(dniNaCeste, zacatekCesty);

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
                            //Zakladni nahrada za 1km
                            zakladniNahradaZa1Km= br.ReadDouble();
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
                            //Zakladni nahrada za 1km
                            bw.Write(5.6);
                        }
                        priSekt5az12 = 129;
                        priSekt12az18 = 196;
                        priSekt18aVic = 307;

                        verSekt5az12 = 129;
                        verSekt12az18 = 196;
                        verSekt18aVic = 307;

                        zakladniNahradaZa1Km = 5.6;
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

                        int[] jidelZaDen=udajeStravne.jidlaZaDen1.NaplnPoleJidlaZaDen(dniNaCeste, udajeStravne.checkBoxBezplatneJidlo.Checked);

                        //Finální výpočty
                        double cenaZaPohonneHmoty = 0;
                        double zkratit = 0;
                        string staty="";
                        double cenaZaTuzemskouCestu=0;
                        double cenaZaZahranicniStravne=0;
                        if (tuzemskaCesta)
                        {
                            staty = "Žádné";
                            cenaZaPohonneHmoty = udajePohonneHmoty.CenaZaPohonneHmoty(zakladniNahradaZa1Km,out dataJsouSpravne);
                            double cenaZaStravne= CenaZaTuzemskouCestu(zacatekCesty, konecCesty, sektor, jidelZaDen, priSekt5az12,
                                priSekt12az18, priSekt18aVic, verSekt5az12, verSekt12az18, verSekt18aVic);
                            cenaZaTuzemskouCestu = cenaZaPohonneHmoty + cenaZaStravne;
                        }
                        else //Zahraniční cesta
                        {
                            cenaZaPohonneHmoty = udajePohonneHmoty.CenaZaPohonneHmoty(zakladniNahradaZa1Km,out dataJsouSpravne);
                            TimeSpan casNezOpustilCesko = navstiveneStaty[0].DatumCasPrijedzu-zacatekCesty;
                            //Nez dojede do zahranici
                            cenaZaTuzemskouCestu = CenaZaTuzemskouCestu(zacatekCesty, navstiveneStaty[0].DatumCasPrijedzu, sektor,
                                jidelZaDen,priSekt5az12,priSekt12az18,priSekt18aVic,verSekt5az12,verSekt12az18,verSekt18aVic);

                            int denCelkove = casNezOpustilCesko.Days;
                            int hodinPrvniDen = 0;
                            int hodinPosledniDen = 0;
                            cenaZaZahranicniStravne = 0;
                            int dnyNavic = 1;
                            staty = "";

                            for (int i = 0; i < navstiveneStaty.Length; i++)
                            {
                                int dniVeState = navstiveneStaty[i].CasVeState.Days;
                                double zakladniSazba = 0;
                                int den = 0;
                                zkratit = 0;
                                bool posledniDen;


                                dnyNavic = 1;
                                if (navstiveneStaty[i].DatumCasOdjezdu.TimeOfDay < navstiveneStaty[i].DatumCasPrijedzu.TimeOfDay)
                                {
                                    dniVeState += 1;
                                }

                            
                                if (navstiveneStaty[i].DatumCasPrijedzu.Date == navstiveneStaty[i].DatumCasOdjezdu.Date)  //Pokud se jedna o jednodenni cestu
                                {
                                    hodinPrvniDen = navstiveneStaty[i].DatumCasOdjezdu.Hour - navstiveneStaty[i].DatumCasPrijedzu.Hour;
                                    hodinPosledniDen = 0;
                                }
                                else if (navstiveneStaty[i].CasVeState.TotalHours < 24)
                                {
                                    dnyNavic = 2;    //pokud cesta netrva 24 hodin ale muzeme mit napr prvni den 2 hodiny cesty a druhy 19,
                                                     //vlastnost .Days na vrati hodnotu dni 0, 
                                                     //i kdyz ve skutecnosti potrebujeme pocitat se dny dvema
                                    hodinPrvniDen = 24 - navstiveneStaty[i].DatumCasPrijedzu.Hour;
                                    hodinPosledniDen = navstiveneStaty[i].DatumCasOdjezdu.Hour;
                                }
                                else     //Cesta delsi nez 1 den
                                {
                                    hodinPrvniDen = 24 - navstiveneStaty[i].DatumCasPrijedzu.Hour;
                                    hodinPosledniDen = navstiveneStaty[i].DatumCasOdjezdu.Hour;
                                }
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
                                    else if (den == dniVeState) //Při posledním dni, pouze pokud je více dní
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
                                } while (den < dniVeState + dnyNavic&&!posledniDen);
                                staty += navstiveneStaty[i].NazevStatu + ", ";
                            }
                            //MessageBox.Show(cenaZaZahranicniStravne.ToString());

                            //Pote co bude dojizdet ze zahranici
                            cenaZaTuzemskouCestu += CenaZaTuzemskouCestu(navstiveneStaty[navstiveneStaty.Length-1].DatumCasOdjezdu,
                            konecCesty, sektor,jidelZaDen, priSekt5az12, priSekt12az18, priSekt18aVic, verSekt5az12, verSekt12az18,
                            verSekt18aVic);
                            cenaZaTuzemskouCestu += cenaZaPohonneHmoty;
                            char[] koncoveZnaky = { ' ', ',' };
                            staty = staty.Trim(koncoveZnaky);
                        }


                        try
                        {
                            using (FileStream fs = new FileStream("uzivatele.dat", FileMode.Append, FileAccess.Write))
                            {
                                BinaryWriter bw = new BinaryWriter(fs);
                                bw.Write(jmeno);   //string
                                bw.Write(prijmeni);    //string
                                bw.Write(datNar.Date.ToString("d.M.yyyy"));    //string
                                bw.Write(zacatekCesty.Date.ToShortDateString()); //string
                                bw.Write(konecCesty.Date.ToShortDateString());   //string
                                bw.Write(dniNaCeste);   //int
                                bw.Write(staty);   //string

                                bw.Write(sektor);   //string
                                bw.Write(udajeStravne.checkBoxBezplatneJidlo.Checked);  //bool

                                bw.Write(cenaZaTuzemskouCestu); //double
                                bw.Write(cenaZaZahranicniStravne);  //double
                                double cenaCelkem = cenaZaTuzemskouCestu + cenaZaZahranicniStravne;
                                bw.Write(cenaCelkem);   //double
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            using (FileStream fs = new FileStream("uzivatele.dat", FileMode.Create, FileAccess.Write))
                            {
                                BinaryWriter bw = new BinaryWriter(fs);
                                bw.Write(jmeno);   //string
                                bw.Write(prijmeni);    //string
                                bw.Write(datNar.Date.ToString("d.M.yyyy"));    //string
                                bw.Write(zacatekCesty.Date.ToShortDateString()); //string
                                bw.Write(konecCesty.Date.ToShortDateString());   //string
                                bw.Write(dniNaCeste);   //int
                                bw.Write(staty);   //string


                                bw.Write(sektor);   //string
                                bw.Write(udajeStravne.checkBoxBezplatneJidlo.Checked);  //bool

                                bw.Write(cenaZaTuzemskouCestu); //double
                                bw.Write(cenaZaZahranicniStravne);  //double
                                double cenaCelkem = cenaZaTuzemskouCestu + cenaZaZahranicniStravne;
                                bw.Write(cenaCelkem);   //double
                            }
                        }

                        if (dataJsouSpravne)
                        {
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
            int dniNavic = 0;
            double vyplatitPenez = 0;

        

            if (zacatekTuzemskeCesty.Date == konecTuzemskeCesty.Date)  //Pokud se jedna o jednodenni cestu
            {
                hodinPrvniDen = konecTuzemskeCesty.Hour - zacatekTuzemskeCesty.Hour;
                hodinPosledniDen = 0;
            }
            else if (delkaCesty.TotalHours < 24) //Pokud cesta netrva pres 24 hodin ale neni v jeden den
            {
                //hodinPrvniDen = (int)delkaCesty.TotalHours;
                hodinPrvniDen = 24 - zacatekTuzemskeCesty.Hour;
                hodinPosledniDen = konecTuzemskeCesty.Hour;
                dniNavic += 1;
                //MessageBox.Show(hodinPrvniDen.ToString());
            }
            else if (konecTuzemskeCesty.TimeOfDay < zacatekTuzemskeCesty.TimeOfDay)
            {
                dniNavic += 1;
                hodinPrvniDen = 24 - zacatekTuzemskeCesty.Hour;
                hodinPosledniDen = konecTuzemskeCesty.Hour;
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
                    else if (den == delkaCesty.Days + dniNavic) //Při posledním dni, pouze pokud je více dní
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
                    else if (den == delkaCesty.Days + dniNavic) //Při posledním dni, pouze pokud je více dní
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
            } while (den < delkaCesty.Days +1+dniNavic);
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
        * https://www.mfcr.cz/cs/kontrola-a-regulace/legislativa/legislativni-dokumenty/2023/vyhlaska-c-341-2023-sb-53892
        * https://blog.videolektor.cz/stravne-pri-soubehu-tuzemske-a-zahranicni-pracovni-cesty/
        * https://ppropo.mpsv.cz/XXII23Cestovninahradyprizahranic
        * https://www.behounek.eu/l/sazby-cestovnich-nahrad/
        */
    }
}
