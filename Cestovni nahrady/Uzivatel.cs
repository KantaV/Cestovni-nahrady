using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cestovni_nahrady
{
    internal class Uzivatel
    {
        private string jmeno;
        private string prijmeni;
        private DateTime datumNarozeni;
        private bool tuzemskaCesta;
        private double cenaZaTuzemskouCestu;
        private double cenaZaZahranicniCestu;
        private string navstiveneStaty;

        public string Jmeno { get { return jmeno; } }
        public string Prijmeni { get { return prijmeni; } }
        public DateTime DatumNarozeni { get { return datumNarozeni; } }
        public bool TuzemskaCesta { get { return tuzemskaCesta; } }
        public double CenaZaTuzemskouCestu { get { return cenaZaTuzemskouCestu; } }
        public double CenaZaZahranicniCestu { get { return cenaZaZahranicniCestu; } }
        public string NavstiveneStaty { get { return navstiveneStaty; } }

        public double CelkemProplatit {get { return cenaZaTuzemskouCestu + cenaZaZahranicniCestu; } }

        public Uzivatel(string jmeno, string prijmeni,DateTime datumNarozeni, bool tuzemskaCesta, double
            cenaZaTuzemskouCestu, double cenaZaZahranicniCestu, string navstiveneStaty)
        {
            this.jmeno = jmeno;
            this.prijmeni = prijmeni;
            this.datumNarozeni = datumNarozeni;
            this.tuzemskaCesta = tuzemskaCesta;
            this.cenaZaTuzemskouCestu = cenaZaTuzemskouCestu;
            this.cenaZaZahranicniCestu = cenaZaZahranicniCestu;
            this.navstiveneStaty = navstiveneStaty;
        }
    }
}
