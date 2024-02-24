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
    public partial class UdajeOsobni : UserControl
    {
        public UdajeOsobni()
        {
            InitializeComponent();
            dtpCasKonceCesty.Value=DateTime.Now.AddSeconds(1);
        }

        private bool DatumySedi(DateTime datumZacatek, DateTime datumKonec, DateTime casZacatek, DateTime casKonec)
        {
            DateTime zacatekCesty = datumZacatek.Date + casZacatek.TimeOfDay;
            DateTime konecCesty = datumKonec.Date + casKonec.TimeOfDay;
            if (konecCesty < zacatekCesty)
            {
                return false;
            }
            else return true;
        }

        private void dtpDatumKonceCesty_ValueChanged(object sender, EventArgs e)
        {
            if (!DatumySedi(dtpDatumZacatkuCesty.Value, dtpDatumKonceCesty.Value, dtpCasZacatkuCesty.Value, dtpCasKonceCesty.Value))
            {
                MessageBox.Show("Konec cesty nemůže nastat před jejím začátkem!");
                dtpDatumKonceCesty.Value = dtpDatumZacatkuCesty.Value;
            }
        }

        private void dtpDatumZacatkuCesty_ValueChanged(object sender, EventArgs e)
        {
            if (!DatumySedi(dtpDatumZacatkuCesty.Value, dtpDatumKonceCesty.Value, dtpCasZacatkuCesty.Value, dtpCasKonceCesty.Value))
            {
                MessageBox.Show("Začátek cesty nemůže nastat před jejím koncem!");
                dtpDatumZacatkuCesty.Value = dtpDatumKonceCesty.Value;
            }
        }

        private void dtpCasZacatkuCesty_ValueChanged(object sender, EventArgs e)
        {
            if (!DatumySedi(dtpDatumZacatkuCesty.Value, dtpDatumKonceCesty.Value, dtpCasZacatkuCesty.Value, dtpCasKonceCesty.Value))
            {
                MessageBox.Show("Začátek cesty nemůže nastat před jejím koncem!");
                dtpCasZacatkuCesty.Value = dtpCasKonceCesty.Value;
            }
        }

        private void dtpCasKonceCesty_ValueChanged(object sender, EventArgs e)
        {
            if (!DatumySedi(dtpDatumZacatkuCesty.Value, dtpDatumKonceCesty.Value, dtpCasZacatkuCesty.Value, dtpCasKonceCesty.Value))
            {
                MessageBox.Show("Konec cesty nemůže nastat před jejím začátkem!");
                dtpCasKonceCesty.Value = dtpCasZacatkuCesty.Value;
            }
        }
    }
}
