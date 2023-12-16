using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        */
    }
}
