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
    public partial class UdajePohonneHmoty : UserControl
    {
        public UdajePohonneHmoty()
        {
            InitializeComponent();
            comboBoxTypPohonnychHmot.SelectedIndex = 0;
            comboBoxZpsbVypoctuPohHmot.SelectedIndex = 0;
            comboBoxZpusobPrepravy.SelectedIndex = 0;
        }

        public double CenaZaPohonneHmoty(double zakladniNahrada)
        {
            //Účtuji pohonné hmoty jedině pokud zaměstnanec cestoval svým vozem
            if (comboBoxZpusobPrepravy.SelectedIndex != 0)
            {
                double najetychKm = double.Parse(textBoxPocetNajetychKm.Text);
                double cenaZaPohonneHmoty = 0;
                PohonneHmoty pohonnaHmota;


                //Podle zákona
                if (comboBoxZpsbVypoctuPohHmot.SelectedIndex == 0)
                {
                    pohonnaHmota = new PohonneHmoty(comboBoxTypPohonnychHmot.Text,
                    double.Parse(numericUpDownSpotreba.Value.ToString()));
                }
                else  //Podle účtenky
                {
                    pohonnaHmota = new PohonneHmoty(double.Parse(numericUpDownSpotreba.Value.ToString()),
                    double.Parse(textBoxPrumernaPohonneHmotyCena.Text));
                }
                switch (comboBoxZpusobPrepravy.SelectedIndex)
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
                return cenaZaPohonneHmoty;
            }
            else return 0;
        }

        private void comboBoxTypPohonnychHmot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTypPohonnychHmot.SelectedIndex == 3) labelSpotrebovano.Text = "Spotřebováno v kilowatthodinách:";
            else labelSpotrebovano.Text = "Spotřebováno v litrech:";
            if (comboBoxTypPohonnychHmot.SelectedIndex == 4)    //index 4 je ostatní takže uživatel může zadat pouze hodnotu z účtenky
            {
                comboBoxZpsbVypoctuPohHmot.SelectedIndex = 1;
                comboBoxZpsbVypoctuPohHmot.Enabled= false;
                textBoxPrumernaPohonneHmotyCena.Enabled = true;
            }
            else
            {
                comboBoxZpsbVypoctuPohHmot.Enabled= true;
                textBoxPrumernaPohonneHmotyCena.Enabled = false;
                comboBoxZpsbVypoctuPohHmot.SelectedIndex = 0;
            }
        }

        private void comboBoxZpsbVypoctuPohHmot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxTypPohonnychHmot.SelectedIndex != 4)
            {
                if (comboBoxZpsbVypoctuPohHmot.SelectedIndex == 0)
                {
                    comboBoxTypPohonnychHmot.Enabled = true;
                    textBoxPrumernaPohonneHmotyCena.Enabled = false;
                }
                else
                {
                    comboBoxTypPohonnychHmot.Enabled = false;
                    textBoxPrumernaPohonneHmotyCena.Enabled = true;
                }
            }
      
        }

        private void comboBoxZpusobPrepravy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxZpusobPrepravy.SelectedIndex == 0)
            {
                textBoxPocetNajetychKm.Enabled= false;
                comboBoxZpsbVypoctuPohHmot.Enabled = false;
                comboBoxTypPohonnychHmot.Enabled = false;
                numericUpDownSpotreba.Enabled = false;
                textBoxPrumernaPohonneHmotyCena.Enabled = false;
            }
            else
            {
                textBoxPocetNajetychKm.Enabled = true;
                comboBoxZpsbVypoctuPohHmot.Enabled = true;
                numericUpDownSpotreba.Enabled = true;
                if (comboBoxZpsbVypoctuPohHmot.SelectedIndex == 0)
                {
                    comboBoxTypPohonnychHmot.Enabled = true;
                    textBoxPrumernaPohonneHmotyCena.Enabled = false;
                }
                else
                {
                    comboBoxTypPohonnychHmot.Enabled = false;
                    textBoxPrumernaPohonneHmotyCena.Enabled = true;
                }
            }
        }
    }
}
