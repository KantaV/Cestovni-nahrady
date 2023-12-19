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
    public partial class Udaje3 : UserControl
    {
        public Udaje3()
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
                numericUpDownSpotreba.Enabled = true;
                textBoxPrumernaPohonneHmotyCena.Enabled = false;
            }
            else
            {
                comboBoxTypPohonnychHmot.Enabled = false;
                numericUpDownSpotreba.Enabled = false;
                textBoxPrumernaPohonneHmotyCena.Enabled = true;
            }
        }
    }
}
