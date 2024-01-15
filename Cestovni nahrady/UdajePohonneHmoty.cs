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

        private void comboBoxTypPohonnychHmot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTypPohonnychHmot.SelectedIndex == 3) labelSpotrebovano.Text = "Spotřebováno v kilowatthodinách:";
            else labelSpotrebovano.Text = "Spotřebováno v litrech:";
        }

        private void comboBoxZpsbVypoctuPohHmot_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboBoxZpusobPrepravy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxZpusobPrepravy.SelectedIndex == 0)
            {
                comboBoxZpsbVypoctuPohHmot.Enabled = false;
                comboBoxTypPohonnychHmot.Enabled = false;
                numericUpDownSpotreba.Enabled = false;
                textBoxPrumernaPohonneHmotyCena.Enabled = false;
            }
            else
            {
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
