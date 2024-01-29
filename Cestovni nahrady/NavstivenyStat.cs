using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cestovni_nahrady
{
    internal class NavstivenyStat
    {
        private string nazevStatu="";
        private TimeSpan casVeState=TimeSpan.Zero;
        private DateTime datumPrijezdu=DateTime.Now;
        private DateTime datumOdjezdu=DateTime.Now;

        public string NazevStatu
        {
            get { return nazevStatu;}
            set { nazevStatu = value;}
        }

        public TimeSpan CasVeState
        { 
            get { return casVeState;}
            set { casVeState = value;}
        }

        public DateTime DatumPrijezdu
        {
            get { return datumPrijezdu;}
            set { datumPrijezdu = value;}
        }

        public DateTime DatumOdjezdu
        {
            get { return datumOdjezdu;}
            set { datumOdjezdu = value;}
        }

        public NavstivenyStat(string nazevStatu, DateTime datumPrijezdu, DateTime datumOdjezdu)
        {
            this.nazevStatu = nazevStatu;
            this.datumPrijezdu = datumPrijezdu;
            this.datumOdjezdu = datumOdjezdu;
            if (datumOdjezdu >= datumPrijezdu)
            {
                this.casVeState = datumOdjezdu - datumPrijezdu;
            }
            else
            {
                MessageBox.Show("Datum návratu domů z pracovní cesty nemůže být před datem začátku!");
            }
        }
    }
}
