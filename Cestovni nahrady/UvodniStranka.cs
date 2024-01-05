using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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
        }

        private UserControl[] stranky = new UserControl[4];

        private Udaje1 udaje1Stranka;
        private Udaje2 udaje2Stranka;
        private Udaje3 udaje3Stranka;
        private Udaje4 udaje4Stranka;

        private int indexStranky = 0;

        public TimeSpan CasVeState(Panel panel, out string nazevZeme)
        {
            nazevZeme = "";
            TimeSpan cas = TimeSpan.Zero;
            DateTime datumPrijezdu = DateTime.Now, casPrijezdu = DateTime.Now, datumOdjezdu = DateTime.Now, casOdjezdu = DateTime.Now;
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

            if (datumOdjezdu >= datumPrijezdu)
            {
                cas = datumOdjezdu - datumPrijezdu;
            }
            else
            {
                MessageBox.Show("Datum návratu domů z pracovní cesty nemůže být před datem začátku!");
            }

           /* MessageBox.Show(nazevZeme+"\n" +
                "prijezd " +datumPrijezdu+
                "\ncas prijezd "+casPrijezdu+
                "\nodjezd "+datumOdjezdu+
                "\ncas odjezd "+casOdjezdu);*/
            return cas;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //Inicializace jednotlivych stranek a nastrkani jich do pole
            udaje1Stranka = new Udaje1();
            stranky[0] = udaje1Stranka;
            this.Controls.Add(stranky[0]);
            stranky[0].Hide();

            udaje2Stranka = new Udaje2();
            stranky[1] = udaje2Stranka;
            this.Controls.Add(stranky[1]);
            stranky[1].Hide();

            udaje3Stranka = new Udaje3();
            stranky[2] = udaje3Stranka;
            this.Controls.Add(stranky[2]);
            stranky[2].Hide();

            udaje4Stranka = new Udaje4();
            stranky[3] = udaje4Stranka;
            this.Controls.Add(stranky[3]);
            stranky[3].Hide();

            //Schovat menu
            panelMenu.Hide();
            stranky[indexStranky].Show();
            panelNavigacniBtny.Show();

        }
        private void buttonNastaveni_Click(object sender, EventArgs e)
        {
            Nastaveni nastevni = new Nastaveni();
            nastevni.ShowDialog();
        }

        private void buttonZpet_Click(object sender, EventArgs e)
        {
            //Změna textu buttonu
            if (buttonDalsi.Text != "Další") buttonDalsi.Text = "Další";
            //Postarání se o samotné stránky
            stranky[indexStranky].Hide();
            if (indexStranky>0)
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

        private void buttonDalsi_Click(object sender, EventArgs e)
        {
            if (indexStranky == stranky.Length-2)
            {
                 //Aktivuje se při příchodu na poslední stránku
                    DateTime zacatekCesty = udaje1Stranka.dtpDatumZacatkuCesty.Value.Date + udaje1Stranka.dtpCasZacatkuCesty.Value.TimeOfDay;
                    DateTime konecCesty = udaje1Stranka.dtpDatumKonceCesty.Value + udaje1Stranka.dtpCasKonceCesty.Value.TimeOfDay;
                    TimeSpan delkaCesty = konecCesty - zacatekCesty;
                //Spočítání délky cesty abych získal počet dní
                    udaje4Stranka.Vygeneruj(delkaCesty.Days);
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
                    //Osobní údaje
                    string jmeno = udaje1Stranka.textBoxJmeno.Text;
                    string prijmeni = udaje1Stranka.textBoxPrijmeni.Text;
                    DateTime datNar = udaje1Stranka.dateTimePickerDatNar.Value;

                    bool tuzemskaCesta = true;

                    NavstivenyStat[] navstiveneStaty = new NavstivenyStat[udaje2Stranka.pocet];
                    //Ošetření počet států
                    if (udaje2Stranka.numericUpDownPocetZemi.Value>0)
                    {
                        tuzemskaCesta = false;
                        //Zjistim kazdy navstiveny stat a delku pobytu v nem
                        for (int i = 0; i < udaje2Stranka.zahranici.Controls.Count; i++)
                        {

                            string nazevZeme = "";
                            TimeSpan casVeState = TimeSpan.Zero;
                            if (udaje2Stranka.zahranici.Controls[i] is Panel) casVeState = CasVeState((udaje2Stranka.zahranici.Controls[i] as Panel), out nazevZeme);
                            navstiveneStaty[i] = new NavstivenyStat(nazevZeme, casVeState);


                            MessageBox.Show(navstiveneStaty[i].NazevStatu + " " + navstiveneStaty[i].CasVeState);
                        }
                    }
            

                    //Rozdělení sektoru
                    string sektor;
                    if (udaje4Stranka.comboBoxStravneSektor.SelectedIndex == 0) sektor = "privatni";
                    else sektor = "verejny";

                    double najetychKm = double.Parse(udaje3Stranka.textBoxPocetNajetychKm.Text);

                    PohonneHmoty pohonnaHmota = new PohonneHmoty(udaje3Stranka.comboBoxTypPohonnychHmot.Text, double.Parse(udaje3Stranka.numericUpDownSpotreba.Value.ToString()));

                    //Finální výpočty
                    double vyplatitPenez = 0;
                    if (tuzemskaCesta)
                    {
                        //Účtuji pohonné hmoty jedině pokud zaměstnanec cestoval svým vozem
                        if (udaje3Stranka.comboBoxZpusobPrepravy.SelectedIndex != 0)
                        {
                            double zakladniNahrada = 5.2;
                            switch (udaje3Stranka.comboBoxZpusobPrepravy.SelectedIndex)
                            {
                                case 1: //Vlastní automobil
                                {
                                    vyplatitPenez += zakladniNahrada * najetychKm;
                                    break;
                                }
                                case 2: //Vlastní automobil s přívěsem
                                {
                                    vyplatitPenez += (zakladniNahrada * 1.15) * najetychKm;
                                    break;
                                }
                                case 3: //Vlastní motorkou
                                {
                                    vyplatitPenez += 1.4 * najetychKm;
                                    break;
                                }
                                case 4: //Vlastním nákladním vozem, autobusem, traktorem
                                {
                                    vyplatitPenez += (zakladniNahrada * 2) * najetychKm;
                                    break;
                                }
                                default:
                                    MessageBox.Show("Chyba");
                                    break;
                            }
                            //Podle zákona
                            if (udaje3Stranka.comboBoxZpsbVypoctuPohHmot.SelectedIndex == 0)
                            {
                                vyplatitPenez += pohonnaHmota.CenaZaPohonneHmoty();
                                //MessageBox.Show(vyplatitPenez.ToString());
                            }
                            else  //Podle účtenky
                            {
                                double prumerCenaZUctenek = double.Parse(udaje3Stranka.textBoxPrumernaPohonneHmotyCena.Text);
                                vyplatitPenez += prumerCenaZUctenek * pohonnaHmota.Spotrebovano;
                                MessageBox.Show(vyplatitPenez.ToString());
                            }
                        }
                        
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
               
            }
        }


        /*
        * kam uživatel bude zadávat jednotlivé ceny z různých benzínek které navštívil protože
        * pokud navšívil více benzínek bere se pro výpočet aritmetický průměr
        * 
        * 
        * přidat nastavení pro majitele firmy aby mohl nastavit kolik bude vyplácet za stravné
        * 
        * přidat form kterej vytovori pocet dni s vyberem poctu jidla podle poctu dni
        * 
        * mozna smazat radiobuttony s poctama hodin a proste to pocitat
        * 
        * upravit max hodnotu v nastavovani u numericupanddownu
        * 
        * https://www.uctovani.net/kalkulacka-zahranicni-cesty-stravne-kapesne.php
        * https://money.cz/novinky-a-tipy/mzdy-a-personalistika/cestovni-nahrady-2022-kolik-zaplatite-kdyz-zamestnance-vyslete-na-sluzebni-cestu/
        * https://www.mfcr.cz/cs/kontrola-a-regulace/legislativa/legislativni-dokumenty/2022/vyhlaska-c-462-2021-sb-49677
        * https://blog.videolektor.cz/stravne-pri-soubehu-tuzemske-a-zahranicni-pracovni-cesty/
        * https://ppropo.mpsv.cz/XXII23Cestovninahradyprizahranic
        */
    }
}
