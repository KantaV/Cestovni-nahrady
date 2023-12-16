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
        private double cena;
        private double spotrebovano;

        public PohonneHmoty(string pohonnaHmota, double cena, double spotrebovano)
        {
            this.pohonnaHmota= pohonnaHmota;
            this.cena = cena;
            this.spotrebovano = spotrebovano;
        }

        public double CenaZaPohonneHmoty()
        {
            return cena*spotrebovano;
        }

        public double Cena { get { return cena; }}

        public string PohonnaHmota {
            get { return pohonnaHmota;}
            set 
            { 
                //Nastavim pohonnou hmotu a podle ni jeji cenu
                pohonnaHmota = value;
                switch (pohonnaHmota)
                {
                    case "Natural 95":
                        cena=41.2;
                        break;
                    case "Natural 98":
                        cena = 45.4;
                        break;
                    case "Nafta":
                        cena = 44.1;
                        break;
                     case "Elektřina":
                        cena = 6;
                        break;
                    case "LPG (plyn)":
                        cena= 0;        //Není zákonem uvedeno je potřeba doložit účtenku
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
