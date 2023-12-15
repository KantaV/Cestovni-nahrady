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
    
        }

        private void buttonNastaveni_Click(object sender, EventArgs e)
        {
            Nastaveni nastevni = new Nastaveni();
            nastevni.ShowDialog();
        }



        //Buttony na otestovani jednotlivych formu nez je propojim, pozdeji smazat

        private void button1Debug_Click(object sender, EventArgs e)
        {
            UdajeOCeste1 udajeOCeste1 = new UdajeOCeste1();
            udajeOCeste1.ShowDialog();
        }

        private void button2NaDebug_Click(object sender, EventArgs e)
        {
            UdajeOCeste2Zahranici udajeOCeste2Zahranici = new UdajeOCeste2Zahranici();
            udajeOCeste2Zahranici.ShowDialog();
        }

        private void buttonNaDebug3_Click(object sender, EventArgs e)
        {
            UdajeOCeste3PohonneHmoty udajeOCeste3PohonneHmoty = new UdajeOCeste3PohonneHmoty();
            udajeOCeste3PohonneHmoty.ShowDialog();
        }

        private void buttonNaDebug4_Click(object sender, EventArgs e)
        {
            UdajeOCeste4Stravne udajeOCeste4Stravne = new UdajeOCeste4Stravne();
            udajeOCeste4Stravne.ShowDialog();
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
