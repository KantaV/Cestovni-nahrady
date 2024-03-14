using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cestovni_nahrady
{
    internal class PohonneHmoty
    {
        private string pohonnaHmota;
        private double cenaZaLneboKW;
        private double spotrebovano;


        public PohonneHmoty(string pohonnaHmota,double spotrebovano)      
        {
            this.pohonnaHmota= pohonnaHmota;
            this.spotrebovano= spotrebovano;
            switch (pohonnaHmota)
            {
                case "Natural 95":
                    this.cenaZaLneboKW = 41.2;
                    break;
                case "Natural 98":
                    this.cenaZaLneboKW = 45.4;
                    break;
                case "Nafta":
                    this.cenaZaLneboKW = 44.1;
                    break;
                case "Elektřina":
                    this.cenaZaLneboKW = 6;
                    break;
                default:
                    this.cenaZaLneboKW = 0;
                    break;
            }
        }

        public PohonneHmoty(double spotrebovano,double cena)        
        {
            this.spotrebovano = spotrebovano;
            this.cenaZaLneboKW = cena;
        }

        public double CenaZaPohonneHmoty()
        {
            return cenaZaLneboKW*spotrebovano;
        }
    }
}
